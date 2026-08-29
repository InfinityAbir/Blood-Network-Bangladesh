import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from '@angular/material/chips';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';
import { AdminService } from '../../../core/services/admin.service';
import { AdminReport } from '../../../core/models/admin';
import { PagedResult } from '../../../core/models/paged-result';
import { RevealDirective } from '../../../shared/directives/reveal.directive';

@Component({
  selector: 'app-report-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent,
    RevealDirective,
    PaginationComponent
  ],
  template: `
    <app-header />
    <main class="container">
      <a mat-button routerLink="/admin" class="back-link"><mat-icon>arrow_back</mat-icon> Back to Dashboard</a>
      <h1>Report Management</h1>

      <div class="filters bgn-fade-up">
        <mat-form-field appearance="outline">
          <mat-label>Status</mat-label>
          <mat-select [(ngModel)]="selectedStatus" (selectionChange)="loadReports()">
            <mat-option value="">All</mat-option>
            <mat-option value="Open">Open</mat-option>
            <mat-option value="UnderReview">Under Review</mat-option>
            <mat-option value="Resolved">Resolved</mat-option>
            <mat-option value="Dismissed">Dismissed</mat-option>
          </mat-select>
        </mat-form-field>
        <button mat-raised-button color="primary" (click)="loadReports()" class="bgn-press">Filter</button>
        <button mat-stroked-button (click)="selectedStatus=''; loadReports()" class="bgn-press"><mat-icon>clear</mat-icon> Reset</button>
      </div>

      @if (isLoading) {
        <div class="sk-list">
          @for (i of [1,2,3]; track i) {
            <mat-card class="sk-report-card">
              <mat-card-header>
                <mat-card-title><app-skeleton type="line" width="220px" height="16px" /></mat-card-title>
                <mat-card-subtitle><app-skeleton type="line" width="300px" height="12px" /></mat-card-subtitle>
              </mat-card-header>
              <mat-card-content>
                <div class="sk-report-info">
                  <app-skeleton type="rect" width="80px" height="22px" />
                  <app-skeleton type="line" width="140px" height="12px" />
                </div>
              </mat-card-content>
            </mat-card>
          }
        </div>
      } @else if (result && result.items.length > 0) {
        <div class="results-panel" appReveal>
        <div class="result-info">Showing {{ result.items.length }} of {{ result.totalCount }} reports</div>
        @for (report of result.items; track report.id) {
          <mat-card class="report-card bgn-hover-lift">
            <mat-card-header>
              <mat-card-title>{{ report.reason }}</mat-card-title>
              <mat-card-subtitle>Reported by {{ report.reporterName }} against {{ report.reportedUserName }}</mat-card-subtitle>
            </mat-card-header>
            <mat-card-content>
              @if (report.description) {
                <p class="description">{{ report.description }}</p>
              }
              <div class="report-info">
                <span class="chip" [class]="'status-' + report.status.toLowerCase()">{{ report.status }}</span>
                <span class="detail">Created {{ report.createdAt | date:'medium' }}</span>
                @if (report.reviewedByName) {
                  <span class="detail">Reviewed by {{ report.reviewedByName }}</span>
                }
                @if (report.resolution) {
                  <div class="resolution">Resolution: {{ report.resolution }}</div>
                }
              </div>
            </mat-card-content>
            @if (report.status === 'Open' || report.status === 'UnderReview') {
              <mat-card-actions align="end">
                <button mat-button (click)="resolveReport(report.id, 'Dismissed')" class="bgn-press">Dismiss</button>
                <button mat-raised-button color="primary" (click)="resolveReport(report.id, 'Resolved')" class="bgn-press">Resolve</button>
              </mat-card-actions>
            }
          </mat-card>
        }
        <app-pagination
          [page]="result.page"
          [pageSize]="pageSize"
          [total]="result.totalCount"
          label="reports"
          (pageChange)="goPage($event)"
          (pageSizeChange)="onPageSizeChange($event)">
        </app-pagination>
        </div>
      } @else {
        <div class="no-results">No reports found</div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .back-link { margin-bottom: 12px; }
    .filters { display: flex; gap: 12px; align-items: center; margin-bottom: 24px; }
    .sk-list { display: flex; flex-direction: column; gap: 8px; }
    .sk-report-card { min-height: 110px; }
    .sk-report-info { display: flex; gap: 8px; align-items: center; margin-top: 8px; }
    .results-panel { display: flex; flex-direction: column; }
    .result-info { font-size: 13px; color: #666; margin-bottom: 12px; }
    .report-card { margin-bottom: 8px; }
    .description { color: #333; margin: 8px 0; }
    .report-info { display: flex; flex-wrap: wrap; gap: 8px; align-items: center; margin-top: 8px; }
    .chip { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; font-weight: 500; }
    .status-open { background: #ffebee; color: #c62828; }
    .status-underreview { background: #fff3e0; color: #e65100; }
    .status-resolved { background: #e8f5e9; color: #2e7d32; }
    .status-dismissed { background: #f5f5f5; color: #666; }
    .detail { font-size: 12px; color: #999; }
    .resolution { font-size: 13px; color: #333; margin-top: 4px; width: 100%; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; margin-top: 16px; }
    @media (max-width: 600px) {
      .filters { flex-direction: column; align-items: stretch; }
      .filters mat-form-field { min-width: 0; }
      .filters button { width: 100%; }
      mat-card-actions { flex-wrap: wrap; gap: 8px !important; }
      mat-card-actions button { flex: 1; min-width: 100px; }
    }
  `]
})
export class ReportManagementComponent implements OnInit {
  result: PagedResult<AdminReport> | null = null;
  isLoading = true;
  selectedStatus = '';
  currentPage = 1;
  pageSize = 10;

  constructor(
    private adminService: AdminService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadReports();
  }

  loadReports(): void {
    this.isLoading = true;
    this.currentPage = 1;
    this.adminService.getReports({
      status: this.selectedStatus || undefined,
      page: this.currentPage,
      pageSize: this.pageSize
    }).pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (result) => { this.result = result; },
      error: (e) => { console.debug(e); }
    });
  }

  goPage(page: number): void {
    this.currentPage = page;
    this.adminService.getReports({
      status: this.selectedStatus || undefined,
      page,
      pageSize: this.pageSize
    }).subscribe({
      next: (result) => this.result = result,
      error: (e) => console.debug(e)
    });
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.loadReports();
  }

  resolveReport(reportId: string, status: string): void {
    const resolution = prompt('Resolution notes (optional):');
    this.adminService.resolveReport(reportId, status, resolution || undefined).subscribe({
      next: () => this.loadReports(),
      error: (e) => console.debug(e)
    });
  }
}
