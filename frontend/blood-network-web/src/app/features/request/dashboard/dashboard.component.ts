import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTabsModule } from '@angular/material/tabs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
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
    MatProgressSpinnerModule,
    MatTabsModule,
    HeaderComponent,
    FooterComponent
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
        <div class="loading">
          <mat-spinner diameter="40"></mat-spinner>
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
                        <button mat-button color="warn" (click)="cancelRequest(request.id)">
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
                      <button mat-button color="warn" (click)="cancelRequest(request.id)">
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
    .loading { display: flex; justify-content: center; padding: 60px; }
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
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; margin-top: 16px; }
    .matches-inline { margin-top: 16px; padding: 12px; background: #f9f9f9; border-radius: 8px; }
    .matches-inline h4 { margin: 0 0 8px; font-size: 14px; color: #666; }
    .match-row { display: flex; align-items: center; gap: 12px; padding: 6px 0; border-bottom: 1px solid #eee; }
    .match-row:last-child { border-bottom: none; }
    .match-name { font-weight: 500; }
    .match-score { color: #666; font-size: 13px; }
    .match-distance { color: #999; font-size: 13px; margin-left: auto; }
  `]
})
export class RequesterDashboardComponent implements OnInit {
  allRequests: PagedResult<BloodRequest> | null = null;
  activeRequests: PagedResult<BloodRequest> | null = null;
  fulfilledRequests: PagedResult<BloodRequest> | null = null;
  matchesMap: Record<string, BloodRequestMatch[]> = {};
  isLoading = true;

  constructor(
    private requestService: RequestService,
    private matchService: MatchService
  ) {}

  ngOnInit(): void {
    this.loadAll(1);
  }

  loadAll(page: number): void {
    this.isLoading = true;
    this.requestService.getMyRequests(undefined, page).subscribe({
      next: (result) => {
        this.allRequests = result;
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  onTabChange(index: number): void {
    if (index === 1 && !this.activeRequests) {
      this.requestService.getMyRequests(RequestStatus.Open).subscribe({
        next: (result) => this.activeRequests = result
      });
    } else if (index === 2 && !this.fulfilledRequests) {
      this.requestService.getMyRequests(RequestStatus.Fulfilled).subscribe({
        next: (result) => this.fulfilledRequests = result
      });
    }
  }

  loadMatches(requestId: string): void {
    if (this.matchesMap[requestId]) {
      delete this.matchesMap[requestId];
      return;
    }
    this.matchService.getMatchesForRequest(requestId).subscribe({
      next: (matches) => {
        this.matchesMap[requestId] = matches;
      }
    });
  }

  cancelRequest(id: string): void {
    if (confirm('Are you sure you want to cancel this blood request?')) {
      this.requestService.cancelRequest(id).subscribe({
        next: () => {
          this.loadAll(1);
          this.activeRequests = null;
          this.fulfilledRequests = null;
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
