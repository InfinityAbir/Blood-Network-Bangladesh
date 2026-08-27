import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { RequestService } from '../../../core/services/request.service';
import { MatchService } from '../../../core/services/match.service';
import { BloodRequest, RequestStatus } from '../../../core/models/blood-request';
import { BloodRequestMatch } from '../../../core/models/match';
import { BloodGroupLabels } from '../../../core/models/blood-group';
import { PagedResult } from '../../../core/models/paged-result';

@Component({
  selector: 'app-requester-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatTabsModule,
    MatSnackBarModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="dashboard-container">
      <div class="dashboard-header">
        <h1>My Blood Requests</h1>
        <a mat-raised-button color="primary" routerLink="/request-blood">
          <mat-icon>add</mat-icon> New Request
        </a>
      </div>

      @if (isLoading) {
        <div class="sk-tabs">
          <div class="sk-tab-bar">
            <app-skeleton type="rect" width="60px" height="32px" />
            <app-skeleton type="rect" width="60px" height="32px" />
            <app-skeleton type="rect" width="80px" height="32px" />
          </div>
          <div class="sk-requests">
            @for (i of [1,2,3]; track i) {
              <mat-card class="sk-request-card">
                <mat-card-header>
                  <app-skeleton type="rect" width="44px" height="28px" />
                  <div>
                    <mat-card-title><app-skeleton type="line" width="180px" height="16px" /></mat-card-title>
                    <mat-card-subtitle><app-skeleton type="line" width="140px" height="12px" /></mat-card-subtitle>
                  </div>
                </mat-card-header>
                <mat-card-content>
                  <div class="sk-request-info">
                    <app-skeleton type="line" width="80px" height="12px" />
                    <app-skeleton type="rect" width="50px" height="20px" />
                    <app-skeleton type="rect" width="60px" height="20px" />
                    <app-skeleton type="line" width="100px" height="12px" />
                  </div>
                </mat-card-content>
              </mat-card>
            }
          </div>
        </div>
      } @else {
        <mat-tab-group (selectedIndexChange)="onTabChange($event)">
          <mat-tab label="All">
            <div class="tab-content">
              @if (allRequests && allRequests.items.length > 0) {
                @for (request of allRequests.items; track request.id) {
                  <mat-card class="request-card">
                    <mat-card-header>
                      <div class="blood-badge">{{ getBloodGroupLabel(request.bloodGroup) }}</div>
                      <mat-card-title>{{ request.hospitalName }}</mat-card-title>
                      <mat-card-subtitle>{{ request.districtName }} - {{ request.area || request.upazilaName }}</mat-card-subtitle>
                    </mat-card-header>
                    <mat-card-content>
                      <div class="request-info">
                        <div class="info-item">
                          <span class="label">Units:</span>
                          <span>{{ request.unitsFulfilled }}/{{ request.unitsRequired }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Urgency:</span>
                          <span class="urgency-chip" [class]="'urgency-' + request.urgency.toLowerCase()">{{ request.urgency }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Status:</span>
                          <span class="status-chip" [class]="'status-' + request.status.toLowerCase()">{{ formatStatus(request.status) }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Contact:</span>
                          <span>{{ request.contactPhone }}</span>
                        </div>
                        @if (request.patientName) {
                          <div class="info-item">
                            <span class="label">Patient:</span>
                            <span>{{ request.patientName }} ({{ request.patientRelation }})</span>
                          </div>
                        }
                        <div class="info-item">
                          <span class="label">Created:</span>
                          <span>{{ request.createdAt | date:'medium' }}</span>
                        </div>
                      </div>
                      @if (matchesMap[request.id]) {
                        <div class="matches-inline">
                          <h4>Matched Donors ({{ matchesMap[request.id].length }})</h4>
                          @for (match of matchesMap[request.id]; track match.id) {
                            <div class="match-row">
                              <span class="blood-badge small">{{ getBloodGroupLabel(match.donorBloodGroup) }}</span>
                              <span class="match-name">{{ match.donorName }}</span>
                              <span class="match-score">{{ match.matchScore }}/100</span>
                              <span class="status-chip" [class]="'response-' + match.donorResponse.toLowerCase()">{{ match.donorResponse }}</span>
                              @if (match.distanceKm != null) {
                                <span class="match-distance">{{ match.distanceKm | number:'1.1-1' }}km</span>
                              }
                            </div>
                          }
                        </div>
                      }
                    </mat-card-content>
                    <mat-card-actions align="end">
                      <button mat-button (click)="loadMatches(request.id)">
                        <mat-icon>people</mat-icon> {{ matchesMap[request.id] ? 'Hide' : 'View' }} Matches
                      </button>
                      @if (request.status === 'Open' || request.status === 'PartiallyFulfilled') {
                        <button mat-button color="warn" (click)="cancelRequest(request.id)" [disabled]="isResponding[request.id]">
                          <mat-icon>cancel</mat-icon> Cancel
                        </button>
                      }
                    </mat-card-actions>
                  </mat-card>
                }
              } @else {
                <div class="no-results">
                  <mat-icon>bloodtype</mat-icon>
                  <p>No blood requests yet</p>
                  <a mat-raised-button color="primary" routerLink="/request-blood">Create Your First Request</a>
                </div>
              }
            </div>
          </mat-tab>

          <mat-tab label="Active">
            <div class="tab-content">
              @if (activeRequests && activeRequests.items.length > 0) {
                @for (request of activeRequests.items; track request.id) {
                  <mat-card class="request-card">
                    <mat-card-header>
                      <div class="blood-badge">{{ getBloodGroupLabel(request.bloodGroup) }}</div>
                      <mat-card-title>{{ request.hospitalName }}</mat-card-title>
                      <mat-card-subtitle>{{ request.districtName }} - {{ request.area || request.upazilaName }}</mat-card-subtitle>
                    </mat-card-header>
                    <mat-card-content>
                      <div class="request-info">
                        <div class="info-item">
                          <span class="label">Units:</span>
                          <span>{{ request.unitsFulfilled }}/{{ request.unitsRequired }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Urgency:</span>
                          <span class="urgency-chip" [class]="'urgency-' + request.urgency.toLowerCase()">{{ request.urgency }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Contact:</span>
                          <span>{{ request.contactPhone }}</span>
                        </div>
                      </div>
                      @if (matchesMap[request.id]) {
                        <div class="matches-inline">
                          <h4>Matched Donors ({{ matchesMap[request.id].length }})</h4>
                          @for (match of matchesMap[request.id]; track match.id) {
                            <div class="match-row">
                              <span class="blood-badge small">{{ getBloodGroupLabel(match.donorBloodGroup) }}</span>
                              <span class="match-name">{{ match.donorName }}</span>
                              <span class="match-score">{{ match.matchScore }}/100</span>
                              <span class="status-chip" [class]="'response-' + match.donorResponse.toLowerCase()">{{ match.donorResponse }}</span>
                            </div>
                          }
                        </div>
                      }
                    </mat-card-content>
                    <mat-card-actions align="end">
                      <button mat-button (click)="loadMatches(request.id)">
                        <mat-icon>people</mat-icon> {{ matchesMap[request.id] ? 'Hide' : 'View' }} Matches
                      </button>
                      <button mat-button color="warn" (click)="cancelRequest(request.id)" [disabled]="isResponding[request.id]">
                        <mat-icon>cancel</mat-icon> Cancel
                      </button>
                    </mat-card-actions>
                  </mat-card>
                }
              } @else {
                <div class="no-results">
                  <p>No active requests</p>
                </div>
              }
            </div>
          </mat-tab>

          <mat-tab label="Fulfilled">
            <div class="tab-content">
              @if (fulfilledRequests && fulfilledRequests.items.length > 0) {
                @for (request of fulfilledRequests.items; track request.id) {
                  <mat-card class="request-card fulfilled">
                    <mat-card-header>
                      <div class="blood-badge">{{ getBloodGroupLabel(request.bloodGroup) }}</div>
                      <mat-card-title>{{ request.hospitalName }}</mat-card-title>
                      <mat-card-subtitle>{{ request.districtName }}</mat-card-subtitle>
                    </mat-card-header>
                    <mat-card-content>
                      <div class="request-info">
                        <div class="info-item">
                          <span class="label">Units:</span>
                          <span>{{ request.unitsFulfilled }}/{{ request.unitsRequired }}</span>
                        </div>
                        <div class="info-item">
                          <span class="label">Completed:</span>
                          <span>{{ request.completedAt | date:'medium' }}</span>
                        </div>
                      </div>
                    </mat-card-content>
                  </mat-card>
                }
              } @else {
                <div class="no-results">
                  <p>No fulfilled requests</p>
                </div>
              }
            </div>
          </mat-tab>
        </mat-tab-group>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .dashboard-container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .dashboard-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 24px; }
    .dashboard-header h1 { margin: 0; font-size: 24px; }
    .sk-tabs { margin-top: 16px; }
    .sk-tab-bar { display: flex; gap: 16px; margin-bottom: 24px; }
    .sk-requests { display: flex; flex-direction: column; gap: 12px; }
    .sk-request-card { min-height: 130px; }
    .sk-request-info { display: flex; flex-wrap: wrap; gap: 16px; margin-top: 12px; }
    .tab-content { padding: 16px 0; }
    .request-card { margin-bottom: 12px; }
    .request-card.fulfilled { border-left: 4px solid #2e7d32; }
    .blood-badge { background: #c62828; color: white; padding: 4px 12px; border-radius: 16px; font-weight: bold; font-size: 16px; margin-right: 12px; display: inline-block; }
    .blood-badge.small { font-size: 13px; padding: 2px 8px; margin-right: 8px; }
    .request-info { display: flex; flex-wrap: wrap; gap: 16px; margin-top: 8px; }
    .info-item { display: flex; align-items: center; gap: 4px; }
    .info-item .label { color: #666; font-size: 13px; }
    .urgency-chip, .status-chip { display: inline-block; padding: 2px 8px; border-radius: 12px; font-size: 12px; }
    .urgency-critical { background: #ffebee; color: #c62828; }
    .urgency-urgent { background: #fff3e0; color: #e65100; }
    .urgency-normal { background: #e8f5e9; color: #2e7d32; }
    .status-open { background: #e3f2fd; color: #1565c0; }
    .status-partiallyfulfilled { background: #fff3e0; color: #e65100; }
    .status-fulfilled { background: #e8f5e9; color: #2e7d32; }
    .status-cancelled { background: #f5f5f5; color: #666; }
    .status-expired { background: #f5f5f5; color: #999; }
    .response-accepted { background: #e8f5e9; color: #2e7d32; }
    .response-declined { background: #ffebee; color: #c62828; }
    .response-pending { background: #fff3e0; color: #e65100; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .no-results mat-icon { font-size: 48px; width: 48px; height: 48px; }
    .matches-inline { margin-top: 16px; padding: 12px; background: #f9f9f9; border-radius: 8px; }
    .matches-inline h4 { margin: 0 0 8px; font-size: 14px; color: #666; }
    .match-row { display: flex; align-items: center; gap: 12px; padding: 6px 0; border-bottom: 1px solid #eee; }
    .match-row:last-child { border-bottom: none; }
    .match-name { font-weight: 500; }
    .match-score { color: #666; font-size: 13px; }
    .match-distance { color: #999; font-size: 13px; margin-left: auto; }
    @media (max-width: 600px) {
      .dashboard-header { flex-direction: column; align-items: flex-start; gap: 12px; }
      .dashboard-header a { width: 100%; justify-content: center; }
    }
  `]
})
export class RequesterDashboardComponent implements OnInit {
  allRequests: PagedResult<BloodRequest> | null = null;
  activeRequests: PagedResult<BloodRequest> | null = null;
  fulfilledRequests: PagedResult<BloodRequest> | null = null;
  matchesMap: Record<string, BloodRequestMatch[]> = {};
  isLoading = true;
  isResponding: Record<string, boolean> = {};

  constructor(
    private requestService: RequestService,
    private matchService: MatchService,
    private snackBar: MatSnackBar,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadAll(1);
  }

  loadAll(page: number): void {
    this.isLoading = true;
    this.requestService.getMyRequests(undefined, page).pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (result) => { this.allRequests = result; },
      error: (e) => {
        console.debug(e);
        this.snackBar.open(e.error?.message || 'Failed to load requests.', 'Close', { duration: 3000 });
      }
    });
  }

  onTabChange(index: number): void {
    if (index === 1 && !this.activeRequests) {
      this.requestService.getMyRequests(RequestStatus.Open).subscribe({
        next: (result) => this.activeRequests = result,
        error: (e) => console.debug(e)
      });
    } else if (index === 2 && !this.fulfilledRequests) {
      this.requestService.getMyRequests(RequestStatus.Fulfilled).subscribe({
        next: (result) => this.fulfilledRequests = result,
        error: (e) => console.debug(e)
      });
    }
  }

  loadMatches(requestId: string): void {
    if (this.matchesMap[requestId]) {
      delete this.matchesMap[requestId];
      return;
    }
    this.matchService.getMatchesForRequest(requestId).subscribe({
      next: (matches) => { this.matchesMap[requestId] = matches; },
      error: (e) => console.debug(e)
    });
  }

  cancelRequest(id: string): void {
    if (this.isResponding[id]) return;
    if (confirm('Are you sure you want to cancel this blood request?')) {
      this.isResponding[id] = true;
      this.requestService.cancelRequest(id).pipe(finalize(() => this.isResponding[id] = false)).subscribe({
        next: () => {
          this.loadAll(1);
          this.activeRequests = null;
          this.fulfilledRequests = null;
          this.snackBar.open('Request cancelled.', 'Close', { duration: 3000 });
        },
        error: (e) => {
          console.debug(e);
          this.snackBar.open(e.error?.message || 'Failed to cancel request.', 'Close', { duration: 3000 });
        }
      });
    }
  }

  getBloodGroupLabel(group: string): string {
    return (BloodGroupLabels as any)[group] || group;
  }

  formatStatus(status: string): string {
    return status.replace(/([A-Z])/g, ' $1').trim();
  }
}
