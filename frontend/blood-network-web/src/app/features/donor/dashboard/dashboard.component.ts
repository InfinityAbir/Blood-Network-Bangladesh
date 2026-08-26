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
import { DonorProfile, AvailabilityStatus, VerificationStatus } from '../../../core/models/donor';
import { BloodGroupLabels } from '../../../core/models/blood-group';

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
    .actions { display: flex; gap: 12px; }
    .no-profile { max-width: 400px; margin: 60px auto; }
  `]
})
export class DonorDashboardComponent implements OnInit {
  profile: DonorProfile | null = null;
  isLoading = true;

  constructor(private donorService: DonorService) {}

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    this.donorService.getMyProfile().subscribe({
      next: (profile) => {
        this.profile = profile;
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  getBloodGroupLabel(group: string): string {
    return (BloodGroupLabels as any)[group] || group;
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
