import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { DonorService } from '../../../core/services/donor.service';
import { MatchService } from '../../../core/services/match.service';
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
    MatProgressSpinnerModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="dashboard-container">
      @if (isLoading) {
        <div class="loading">
          <mat-spinner diameter="40"></mat-spinner>
        </div>
      } @else if (profile) {
        <div class="dashboard-header">
          <h1>Donor Dashboard</h1>
          <p>Welcome, {{ profile.area ? profile.area + ' - ' : '' }}{{ getBloodGroupLabel(profile.bloodGroup) }}</p>
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

          <mat-card>
            <mat-card-header>
              <mat-card-title>Last Donation</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">
                {{ profile.lastDonationDate ? (profile.lastDonationDate | date:'mediumDate') : 'Never' }}
              </div>
            </mat-card-content>
          </mat-card>
        </div>

        <div class="actions">
          <button mat-raised-button color="primary" (click)="toggleAvailability()">
            <mat-icon>{{ profile.availabilityStatus === 'Available' ? 'block' : 'check_circle' }}</mat-icon>
            {{ profile.availabilityStatus === 'Available' ? 'Mark Unavailable' : 'Mark Available' }}
          </button>
          <a mat-raised-button routerLink="/donor/profile">
            <mat-icon>edit</mat-icon> Edit Profile
          </a>
        </div>

        @if (pendingMatches.length > 0) {
          <div class="matches-section">
            <h2>Blood Match Requests ({{ pendingMatches.length }})</h2>
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
                  <button mat-button color="warn" (click)="declineMatch(match.id)">Decline</button>
                  <button mat-raised-button color="primary" (click)="acceptMatch(match.id)">Accept</button>
                </mat-card-actions>
              </mat-card>
            }
          </div>
        }

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
    .loading { display: flex; justify-content: center; padding: 60px; }
    .dashboard-header { margin-bottom: 24px; }
    .dashboard-header h1 { margin: 0 0 4px; font-size: 24px; }
    .dashboard-header p { margin: 0; color: #666; }
    .cards-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); gap: 16px; margin-bottom: 24px; }
    .stat-value { font-size: 28px; font-weight: 500; }
    .stat-value.blood-group { color: #c62828; }
    .stat-value.location { font-size: 18px; }
    .status-chip { display: inline-block; padding: 4px 12px; border-radius: 16px; font-size: 13px; font-weight: 500; }
    .status-available { background: #e8f5e9; color: #2e7d32; }
    .status-unavailable { background: #ffebee; color: #c62828; }
    .status-recentlydonated { background: #fff3e0; color: #e65100; }
    .status-unknown { background: #f5f5f5; color: #666; }
    .verify-verified { background: #e8f5e9; color: #2e7d32; }
    .verify-unverified { background: #fff3e0; color: #e65100; }
    .verify-pending { background: #e3f2fd; color: #1565c0; }
    .verify-rejected { background: #ffebee; color: #c62828; }
    .response-accepted { background: #e8f5e9; color: #2e7d32; }
    .response-declined { background: #ffebee; color: #c62828; }
    .response-pending { background: #fff3e0; color: #e65100; }
    .actions { display: flex; gap: 12px; margin-bottom: 32px; }
    .no-profile { max-width: 400px; margin: 60px auto; }
    .matches-section { margin-bottom: 32px; }
    .matches-section h2 { margin: 0 0 16px; font-size: 20px; }
    .match-card { margin-bottom: 12px; }
    .match-card.small { padding: 8px 16px; }
    .blood-badge { background: #c62828; color: white; padding: 4px 12px; border-radius: 16px; font-weight: bold; font-size: 16px; margin-right: 12px; display: inline-block; }
    .blood-badge.small { font-size: 13px; padding: 2px 8px; margin-right: 8px; }
    .match-info { display: flex; gap: 16px; }
    .info-item { display: flex; align-items: center; gap: 4px; }
    .info-item .label { color: #666; font-size: 13px; }
    .match-row { display: flex; align-items: center; gap: 12px; }
    .match-row .score { font-weight: 500; }
    .match-row .date { color: #999; margin-left: auto; }
  `]
})
export class DonorDashboardComponent implements OnInit {
  profile: DonorProfile | null = null;
  pendingMatches: BloodRequestMatch[] = [];
  otherMatches: BloodRequestMatch[] = [];
  isLoading = true;

  constructor(
    private donorService: DonorService,
    private matchService: MatchService
  ) {}

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    this.donorService.getMyProfile().subscribe({
      next: (profile) => {
        this.profile = profile;
        this.loadMatches();
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  loadMatches(): void {
    this.matchService.getMyMatches().subscribe({
      next: (matches) => {
        this.pendingMatches = matches.filter(m => m.donorResponse === 'Pending');
        this.otherMatches = matches.filter(m => m.donorResponse !== 'Pending');
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  acceptMatch(matchId: string): void {
    this.matchService.respondToMatch(matchId, { response: 'Accepted' }).subscribe({
      next: () => this.loadMatches()
    });
  }

  declineMatch(matchId: string): void {
    this.matchService.respondToMatch(matchId, { response: 'Declined' }).subscribe({
      next: () => this.loadMatches()
    });
  }

  getBloodGroupLabel(group: string): string {
    return (BloodGroupLabels as any)[group] || group;
  }

  formatScore(score: number): number {
    return score;
  }

  toggleAvailability(): void {
    if (!this.profile) return;

    const newStatus = this.profile.availabilityStatus === AvailabilityStatus.Available
      ? AvailabilityStatus.Unavailable
      : AvailabilityStatus.Available;

    this.donorService.toggleAvailability(newStatus).subscribe({
      next: (updated) => {
        this.profile = updated;
      }
    });
  }
}
