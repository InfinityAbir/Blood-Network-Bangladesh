import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { AdminService } from '../../../core/services/admin.service';
import { AdminDashboardStats } from '../../../core/models/admin';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatTabsModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="dashboard-container">
      <div class="dashboard-header">
        <h1>Admin Dashboard</h1>
      </div>

      @if (isLoading) {
        <div class="cards-grid">
          @for (i of [1,2,3,4,5]; track i) {
            <mat-card class="sk-card">
              <mat-card-header>
                <mat-card-title><app-skeleton type="line" width="120px" height="14px" /></mat-card-title>
              </mat-card-header>
              <mat-card-content>
                <app-skeleton type="line" width="60px" height="36px" />
                <div style="margin-top:8px"><app-skeleton type="line" width="140px" height="12px" /></div>
              </mat-card-content>
            </mat-card>
          }
        </div>
        <div class="nav-cards">
          @for (i of [1,2,3]; track i) {
            <app-skeleton type="rect" width="180px" height="40px" />
          }
        </div>
      } @else if (errorMessage) {
        <div class="error-banner">
          <mat-icon>error</mat-icon>
          <span>{{ errorMessage }}</span>
          <button mat-button (click)="retry()">Retry</button>
        </div>
      } @else if (stats) {
        <div class="cards-grid">
          <mat-card>
            <mat-card-header>
              <mat-icon class="card-icon users">people</mat-icon>
              <mat-card-title>Total Users</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ stats.totalUsers }}</div>
              <div class="stat-detail">{{ stats.totalDonors }} donors, {{ stats.totalRequesters }} requesters</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-icon class="card-icon requests">bloodtype</mat-icon>
              <mat-card-title>Blood Requests</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ stats.totalBloodRequests }}</div>
              <div class="stat-detail">{{ stats.openBloodRequests }} open, {{ stats.fulfilledBloodRequests }} fulfilled</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-icon class="card-icon matches">handshake</mat-icon>
              <mat-card-title>Matches</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ stats.totalMatches }}</div>
              <div class="stat-detail">{{ stats.acceptedMatches }} accepted</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-icon class="card-icon reports">flag</mat-icon>
              <mat-card-title>Reports</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ stats.totalReports }}</div>
              <div class="stat-detail">{{ stats.openReports }} open</div>
            </mat-card-content>
          </mat-card>

          <mat-card>
            <mat-card-header>
              <mat-icon class="card-icon verify">verified</mat-icon>
              <mat-card-title>Pending Verifications</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              <div class="stat-value">{{ stats.pendingVerifications }}</div>
            </mat-card-content>
          </mat-card>
        </div>

        <div class="nav-cards">
          <a mat-raised-button routerLink="/admin/users" routerLinkActive="active-link">
            <mat-icon>people</mat-icon> User Management
          </a>
          <a mat-raised-button routerLink="/admin/reports" routerLinkActive="active-link">
            <mat-icon>flag</mat-icon> Reports
          </a>
          <a mat-raised-button routerLink="/admin/audit-logs" routerLinkActive="active-link">
            <mat-icon>history</mat-icon> Audit Logs
          </a>
          <a mat-raised-button routerLink="/admin/settings" routerLinkActive="active-link">
            <mat-icon>settings</mat-icon> Settings
          </a>
        </div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .dashboard-container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .dashboard-header { margin-bottom: 24px; }
    .dashboard-header h1 { margin: 0; font-size: 24px; }
    .cards-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(220px, 1fr)); gap: 16px; margin-bottom: 32px; }
    .sk-card { min-height: 120px; }
    .card-icon { font-size: 32px; width: 32px; height: 32px; }
    .card-icon.users { color: #1565c0; }
    .card-icon.requests { color: #c62828; }
    .card-icon.matches { color: #2e7d32; }
    .card-icon.reports { color: #f57c00; }
    .card-icon.verify { color: #7b1fa2; }
    .stat-value { font-size: 32px; font-weight: 600; margin: 8px 0 4px; }
    .stat-detail { font-size: 13px; color: #666; }
    .nav-cards { display: flex; gap: 12px; flex-wrap: wrap; }
    .nav-cards a { display: flex; align-items: center; gap: 8px; }
    @media (max-width: 600px) {
      .dashboard-container { padding: 16px; }
      .cards-grid { grid-template-columns: 1fr 1fr; gap: 12px; }
      .stat-value { font-size: 24px; }
      .nav-cards { flex-direction: column; }
      .nav-cards a { width: 100%; justify-content: center; height: 48px; }
    }
  `]
})
export class AdminDashboardComponent implements OnInit {
  stats: AdminDashboardStats | null = null;
  isLoading = true;
  errorMessage = '';

  constructor(
    private adminService: AdminService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.adminService.getDashboardStats().pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (stats) => { this.stats = stats; },
      error: (e) => {
        console.debug(e);
        this.errorMessage = e.error?.message || e.message || 'Failed to load dashboard. Please retry.';
      }
    });
  }

  retry(): void {
    this.load();
  }
}
