import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { DonorService } from '../../../core/services/donor.service';
import { MatchService } from '../../../core/services/match.service';
import { AuthService } from '../../../core/services/auth.service';
import { DonorProfile, AvailabilityStatus, VerificationStatus } from '../../../core/models/donor';
import { BloodGroupLabels } from '../../../core/models/blood-group';
import { BloodRequestMatch } from '../../../core/models/match';

@Component({
  selector: 'app-donor-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="dashboard-container">
      @if (isLoading) {
        <div class="dashboard-header">
          <app-skeleton type="line" width="200px" height="28px" />
          <div style="margin-top:8px"><app-skeleton type="line" width="300px" height="14px" /></div>
        </div>
        <div class="cards-grid">
          @for (i of [1,2,3,4,5,6]; track i) {
            <mat-card class="sk-card">
              <mat-card-header>
                <mat-card-title><app-skeleton type="line" width="100px" height="14px" /></mat-card-title>
              </mat-card-header>
              <mat-card-content>
                <app-skeleton type="line" width="80px" height="32px" />
              </mat-card-content>
            </mat-card>
          }
        </div>
        <div class="actions">
          <app-skeleton type="rect" width="180px" height="40px" />
          <app-skeleton type="rect" width="140px" height="40px" />
        </div>
      } @else if (loadError) {
        <div class="error-banner" role="alert">
          <mat-icon>error_outline</mat-icon>
          <span>{{ loadError }}</span>
          <button mat-stroked-button (click)="loadProfile()">Retry</button>
        </div>
      } @else if (profile) {
        <div class="dashboard-header">
          <h1>Donor Dashboard</h1>
          <p>Welcome, {{ userName }} — {{ getBloodGroupLabel(profile.bloodGroup) }} • {{ profile.districtName }}, {{ profile.upazilaName }}</p>
        </div>

        <div class="cards-grid">
          <mat-card>
            <mat-card-header>
              <mat-card-title>Blood Group</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value blood-group">{{ getBloodGroupLabel(profile.bloodGroup) }}</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-card-title>Status</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="status-chip" [class]="'status-' + profile.availabilityStatus.toLowerCase()">
                {{ profile.availabilityStatus }}
              </div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-card-title>Verification</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="status-chip" [class]="'verify-' + profile.verificationStatus.toLowerCase()">
                {{ profile.verificationStatus }}
              </div>
              @if (profile.verificationStatus === 'Unverified') {
                <div class="hint">Admin will verify your profile soon</div>
              }
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-card-title>Total Donations</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ profile.totalDonationCount }}</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-card-title>Location</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value location">{{ profile.districtName }}, {{ profile.upazilaName }}</div>
            </mat-card-content>
          </mat-card>

          <mat-card matTooltip="From your donor profile. Eligibility check does not update this.">
            <mat-card-header>
              <mat-card-title>Last Donation</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              @if (profile.lastDonationDate) {
                <div class="stat-value">{{ profile.lastDonationDate | date:'mediumDate' }}</div>
              } @else {
                <div class="stat-value not-recorded">Not recorded</div>
                <div class="hint">Add it in Edit Profile</div>
              }
            </mat-card-content>
          </mat-card>
        </div>

        <div class="actions">
          <button mat-raised-button color="primary" (click)="toggleAvailability()" [disabled]="isToggling">
            @if (isToggling) { <mat-spinner diameter="18"></mat-spinner> }
            @else { <mat-icon>{{ profile.availabilityStatus === 'Available' ? 'block' : 'check_circle' }}</mat-icon> }
            {{ profile.availabilityStatus === 'Available' ? 'Mark Unavailable' : 'Mark Available' }}
          </button>
          <a mat-stroked-button routerLink="/donor/profile">
            <mat-icon>edit</mat-icon> Edit Profile
          </a>
        </div>

        <div class="matches-section">
          <h2>Blood Match Requests</h2>
          @if (matchesLoading) {
            <mat-card><mat-card-content><app-skeleton type="line" width="100%" height="60px" /></mat-card-content></mat-card>
          } @else if (matchesError) {
            <div class="error-banner small" role="alert"><mat-icon>error_outline</mat-icon><span>{{ matchesError }}</span><button mat-button (click)="loadMatches()">Retry</button></div>
          } @else if (pendingMatches.length > 0) {
            @for (match of pendingMatches; track match.id) {
              <mat-card class="match-card">
                <mat-card-header>
                  <div class="blood-badge">{{ getBloodGroupLabel(match.donorBloodGroup) }}</div>
                  <mat-card-title>{{ formatScore(match.matchScore) }}% Match</mat-card-title>
                  <mat-card-subtitle>
                    @if (match.distanceKm != null) {
                      {{ match.distanceKm | number:'1.1-1' }} km away
                    } @else {
                      Distance unknown
                    }
                  </mat-card-subtitle>
                </mat-card-header>
                <mat-card-content>
                  <div class="match-info">
                    <div class="info-item">
                      <span class="label">Score:</span>
                      <span>{{ match.matchScore }}/100</span>
                    </div>
                  </div>
                </mat-card-content>
                <mat-card-actions align="end">
                  <button mat-button color="warn" (click)="declineMatch(match.id)" [disabled]="isResponding[match.id]">
                    @if (isResponding[match.id]) { <mat-spinner diameter="16"></mat-spinner> } @else { Decline }
                  </button>
                  <button mat-raised-button color="primary" (click)="acceptMatch(match.id)" [disabled]="isResponding[match.id]">
                    @if (isResponding[match.id]) { <mat-spinner diameter="16"></mat-spinner> } @else { Accept }
                  </button>
                </mat-card-actions>
              </mat-card>
            }
          } @else {
            <div class="empty-state">
              <mat-icon>volunteer_activism</mat-icon>
              <p>No pending requests right now</p>
              <span>We'll notify you when a nearby patient needs your blood type. Keep your profile available and verified.</span>
            </div>
          }
        </div>

        @if (otherMatches.length > 0) {
          <div class="matches-section">
            <h2>Recent Activity</h2>
            @for (match of otherMatches; track match.id) {
              <mat-card class="match-card small">
                <mat-card-content>
                  <div class="match-row">
                    <span class="blood-badge small">{{ getBloodGroupLabel(match.donorBloodGroup) }}</span>
                    <span class="status-chip" [class]="'response-' + match.donorResponse.toLowerCase()">
                      {{ match.donorResponse }}
                    </span>
                    <span class="score">{{ match.matchScore }}/100</span>
                    <span class="date">{{ match.createdAt | date:'short' }}</span>
                  </div>
                </mat-card-content>
              </mat-card>
            }
          </div>
        }
      } @else {
        <div class="no-profile">
          <mat-card>
            <mat-card-header>
              <mat-card-title>No Profile Found</mat-card-title>
              <mat-card-subtitle>You need to create a donor profile first</mat-card-subtitle>
            </mat-card-header>
            <mat-card-content>
              <p>Complete your donor profile to start receiving blood match requests.</p>
            </mat-card-content>
            <mat-card-actions>
              <a mat-raised-button color="primary" routerLink="/donor/profile">Create Profile</a>
            </mat-card-actions>
          </mat-card>
        </div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .dashboard-container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .dashboard-header { margin-bottom: 24px; }
    .dashboard-header h1 { margin: 0 0 4px; font-size: 24px; }
    .dashboard-header p { margin: 0; color: var(--bgn-text-muted); }
    .cards-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); gap: 16px; margin-bottom: 24px; }
    .sk-card { min-height: 100px; }
    .stat-value { font-size: 28px; font-weight: 500; }
    .stat-value.blood-group { color: var(--bgn-primary); }
    .stat-value.location { font-size: 18px; }
    .status-chip { display: inline-block; padding: 4px 12px; border-radius: 16px; font-size: 13px; font-weight: 500; }
    .status-available { background: #e8f5e9; color: #2e7d32; }
    .status-unavailable { background: #ffebee; color: #c62828; }
    .status-recentlydonated { background: #fff3e0; color: #e65100; }
    .status-unknown { background: var(--bgn-surface-2); color: var(--bgn-text-muted); }
    .verify-verified { background: #e8f5e9; color: #2e7d32; }
    .verify-unverified { background: #fff3e0; color: #e65100; }
    .verify-pending { background: #e3f2fd; color: #1565c0; }
    .verify-rejected { background: #ffebee; color: #c62828; }
    .not-recorded { color: var(--bgn-text-muted); font-size: 20px; }
    .hint { font-size: 12px; color: var(--bgn-text-muted); margin-top: 4px; }
    .response-accepted { background: #e8f5e9; color: #2e7d32; }
    .response-declined { background: #ffebee; color: #c62828; }
    .response-pending { background: #fff3e0; color: #e65100; }
    .actions { display: flex; gap: 12px; margin-bottom: 32px; flex-wrap: wrap; }
    .no-profile { max-width: 400px; margin: 60px auto; }
    .matches-section { margin-bottom: 32px; }
    .matches-section h2 { margin: 0 0 16px; font-size: 20px; }
    .match-card { margin-bottom: 12px; }
    .match-card.small { padding: 8px 16px; }
    .blood-badge { background: var(--bgn-primary); color: white; padding: 4px 12px; border-radius: 16px; font-weight: bold; font-size: 16px; margin-right: 12px; display: inline-block; }
    .blood-badge.small { font-size: 13px; padding: 2px 8px; margin-right: 8px; }
    .match-info { display: flex; gap: 16px; flex-wrap: wrap; }
    .info-item { display: flex; align-items: center; gap: 4px; }
    .info-item .label { color: var(--bgn-text-muted); font-size: 13px; }
    .match-row { display: flex; align-items: center; gap: 12px; flex-wrap: wrap; }
    .match-row .score { font-weight: 500; }
    .match-row .date { color: var(--bgn-text-muted); font-size: 12px; }
    .error-banner { display:flex; align-items:center; gap:12px; padding:12px 16px; background: color-mix(in srgb, var(--bgn-danger) 10%, transparent); border:1px solid color-mix(in srgb, var(--bgn-danger) 30%, transparent); color: var(--bgn-danger); border-radius: var(--bgn-radius-md); margin-bottom:16px; }
    .error-banner.small { padding:8px 12px; font-size:13px; }
    .empty-state { text-align:center; padding:32px 16px; color: var(--bgn-text-muted); border:1px dashed var(--bgn-border); border-radius: var(--bgn-radius-md); }
    .empty-state mat-icon { font-size:40px; width:40px; height:40px; color: var(--bgn-text-faint); margin-bottom:8px; }
    .empty-state p { margin:0 0 4px; font-weight:500; color: var(--bgn-text); }
    .empty-state span { font-size:13px; }
    @media (max-width: 600px) {
      .cards-grid { grid-template-columns: repeat(auto-fill, minmax(160px, 1fr)); gap:12px; }
      .actions { flex-direction: column; }
      .actions button, .actions a { width: 100%; justify-content: center; }
    }
  `]
})
export class DonorDashboardComponent implements OnInit {
  profile: DonorProfile | null = null;
  pendingMatches: BloodRequestMatch[] = [];
  otherMatches: BloodRequestMatch[] = [];
  isLoading = true;
  loadError: string | null = null;
  matchesLoading = false;
  matchesError: string | null = null;
  isResponding: Record<string, boolean> = {};
  isToggling = false;

  constructor(
    private donorService: DonorService,
    private matchService: MatchService,
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private cdr: ChangeDetectorRef
  ) {}

  get userName(): string {
    const u = this.authService.currentUser();
    return u ? `${u.firstName} ${u.lastName}`.trim() : 'Donor';
  }

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    this.isLoading = true;
    this.loadError = null;
    this.donorService.getMyProfile().pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (profile) => {
        this.profile = profile;
        this.loadMatches();
      },
      error: (e) => {
        this.loadError = e.error?.message || 'Failed to load profile. Please check connection and retry.';
      }
    });
  }

  loadMatches(): void {
    this.matchesLoading = true;
    this.matchesError = null;
    this.matchService.getMyMatches().subscribe({
      next: (matches) => {
        this.matchesLoading = false;
        this.pendingMatches = matches.filter(m => m.donorResponse === 'Pending');
        this.otherMatches = matches.filter(m => m.donorResponse !== 'Pending');
        this.cdr.detectChanges();
      },
      error: (e) => {
        this.matchesLoading = false;
        this.matchesError = e.error?.message || 'Failed to load matches.';
        this.cdr.detectChanges();
      }
    });
  }

  acceptMatch(matchId: string): void {
    if (this.isResponding[matchId]) return;
    if (!confirm('Accept this blood request? You will be expected to coordinate donation.')) return;
    this.isResponding[matchId] = true;
    this.matchService.respondToMatch(matchId, { response: 'Accepted' }).pipe(finalize(() => { this.isResponding[matchId] = false; this.cdr.detectChanges(); })).subscribe({
      next: () => {
        this.snackBar.open('Match accepted! Requester will be notified.', 'Close', { duration: 3000, horizontalPosition: 'end', verticalPosition: 'top' });
        this.loadMatches();
      },
      error: (e) => {
        this.snackBar.open(e.error?.message || 'Failed to accept match.', 'Close', { duration: 3000 });
      }
    });
  }

  declineMatch(matchId: string): void {
    if (this.isResponding[matchId]) return;
    if (!confirm('Decline this request? This cannot be undone.')) return;
    this.isResponding[matchId] = true;
    this.matchService.respondToMatch(matchId, { response: 'Declined' }).pipe(finalize(() => { this.isResponding[matchId] = false; this.cdr.detectChanges(); })).subscribe({
      next: () => {
        this.snackBar.open('Match declined.', 'Close', { duration: 3000, horizontalPosition: 'end', verticalPosition: 'top' });
        this.loadMatches();
      },
      error: (e) => {
        this.snackBar.open(e.error?.message || 'Failed to decline match.', 'Close', { duration: 3000 });
      }
    });
  }

  getBloodGroupLabel(group: string): string {
    return (BloodGroupLabels as any)[group] || group;
  }

  formatScore(score: number): number {
    return score;
  }

  toggleAvailability(): void {
    if (!this.profile || this.isToggling) return;
    const newStatus = this.profile.availabilityStatus === AvailabilityStatus.Available
      ? AvailabilityStatus.Unavailable
      : AvailabilityStatus.Available;
    if (!confirm(newStatus === 'Available' ? 'Mark yourself as available for donations?' : 'Mark yourself as unavailable? You will not receive new match requests.')) return;
    this.isToggling = true;
    this.donorService.toggleAvailability(newStatus).pipe(finalize(() => { this.isToggling = false; this.cdr.detectChanges(); })).subscribe({
      next: (updated) => {
        this.profile = updated;
        this.snackBar.open(`Status updated to ${updated.availabilityStatus}`, 'Close', { duration: 2500 });
      },
      error: (e) => {
        this.snackBar.open(e.error?.message || 'Failed to update availability.', 'Close', { duration: 3000 });
      }
    });
  }
}
