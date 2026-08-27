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
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { AdminService } from '../../../core/services/admin.service';
import { AdminAuditLog } from '../../../core/models/admin';
import { PagedResult } from '../../../core/models/paged-result';

@Component({
  selector: 'app-audit-log-viewer',
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
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="container">
      <a mat-button routerLink="/admin" class="back-link"><mat-icon>arrow_back</mat-icon> Back to Dashboard</a>
      <h1>Audit Logs</h1>

      <div class="filters">
        <mat-form-field appearance="outline">
          <mat-label>Entity Type</mat-label>
          <input matInput [(ngModel)]="entityTypeFilter" placeholder="e.g. User, BloodRequest" (keyup.enter)="loadLogs()">
        </mat-form-field>
        <button mat-raised-button color="primary" (click)="loadLogs()">Filter</button>
        <button mat-stroked-button (click)="entityTypeFilter=''; loadLogs()"><mat-icon>clear</mat-icon> Reset</button>
      </div>

      @if (isLoading) {
        <mat-card>
          <div class="sk-table">
            <div class="sk-table-header">
              <app-skeleton type="line" width="60px" height="12px" />
              <app-skeleton type="line" width="80px" height="12px" />
              <app-skeleton type="line" width="60px" height="12px" />
              <app-skeleton type="line" width="60px" height="12px" />
              <app-skeleton type="line" width="80px" height="12px" />
              <app-skeleton type="line" width="60px" height="12px" />
              <app-skeleton type="line" width="120px" height="12px" />
            </div>
            @for (i of [1,2,3,4,5,6,7,8]; track i) {
              <div class="sk-table-row">
                <app-skeleton type="line" width="70px" height="12px" />
                <app-skeleton type="line" width="90px" height="12px" />
                <app-skeleton type="rect" width="70px" height="20px" />
                <app-skeleton type="line" width="60px" height="12px" />
                <app-skeleton type="line" width="80px" height="12px" />
                <app-skeleton type="line" width="60px" height="12px" />
                <app-skeleton type="line" width="120px" height="12px" />
              </div>
            }
          </div>
        </mat-card>
      } @else if (result && result.items.length > 0) {
        <div class="result-info">Showing {{ result.items.length }} of {{ result.totalCount }} logs</div>
        <mat-card>
          <table class="audit-table">
            <thead>
              <tr>
                <th>Date</th>
                <th>User</th>
                <th>Action</th>
                <th>Entity</th>
                <th>Entity ID</th>
                <th>IP</th>
                <th>Metadata</th>
              </tr>
            </thead>
            <tbody>
              @for (log of result.items; track log.id) {
                <tr>
                  <td>{{ log.createdAt | date:'short' }}</td>
                  <td>{{ log.userName || 'System' }}</td>
                  <td><span class="action-badge">{{ log.action }}</span></td>
                  <td>{{ log.entityType }}</td>
                  <td class="mono">{{ log.entityId ? (log.entityId | slice:0:8) + '...' : '-' }}</td>
                  <td class="mono">{{ log.ipAddress || '-' }}</td>
                  <td class="metadata">{{ log.metadata || '-' }}</td>
                </tr>
              }
            </tbody>
          </table>
        </mat-card>
        @if (result.totalPages > 1) {
          <div class="pagination">
            <button mat-button [disabled]="!result.hasPrevious" (click)="goPage(result.page - 1)">Previous</button>
            <span>Page {{ result.page }} of {{ result.totalPages }}</span>
            <button mat-button [disabled]="!result.hasNext" (click)="goPage(result.page + 1)">Next</button>
          </div>
        }
      } @else {
        <div class="no-results">No audit logs found</div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .back-link { margin-bottom: 12px; }
    .filters { display: flex; gap: 12px; align-items: center; margin-bottom: 24px; }
    .filters mat-form-field { flex: 1; min-width: 200px; }
    .sk-table { padding: 0; }
    .sk-table-header { display: grid; grid-template-columns: 70px 90px 70px 60px 80px 60px 1fr; gap: 8px; padding: 10px 8px; border-bottom: 2px solid #ddd; }
    .sk-table-row { display: grid; grid-template-columns: 70px 90px 70px 60px 80px 60px 1fr; gap: 8px; padding: 8px; border-bottom: 1px solid #eee; align-items: center; }
    .result-info { font-size: 13px; color: #666; margin-bottom: 12px; }
    .audit-table { width: 100%; border-collapse: collapse; font-size: 13px; }
    .audit-table th { text-align: left; padding: 10px 8px; border-bottom: 2px solid #ddd; font-weight: 500; color: #666; }
    .audit-table td { padding: 8px; border-bottom: 1px solid #eee; }
    .audit-table tr:hover { background: #f9f9f9; }
    .action-badge { background: #e3f2fd; color: #1565c0; padding: 2px 8px; border-radius: 8px; font-size: 12px; }
    .mono { font-family: monospace; font-size: 12px; }
    .metadata { max-width: 200px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; margin-top: 16px; }
  `]
})
export class AuditLogViewerComponent implements OnInit {
  result: PagedResult<AdminAuditLog> | null = null;
  isLoading = true;
  entityTypeFilter = '';
  currentPage = 1;

  constructor(
    private adminService: AdminService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadLogs();
  }

  loadLogs(): void {
    this.isLoading = true;
    this.currentPage = 1;
    this.adminService.getAuditLogs({
      entityType: this.entityTypeFilter || undefined,
      page: this.currentPage
    }).pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (result) => { this.result = result; },
      error: (e) => { console.debug(e); }
    });
  }

  goPage(page: number): void {
    this.currentPage = page;
    this.adminService.getAuditLogs({
      entityType: this.entityTypeFilter || undefined,
      page
    }).subscribe({
      next: (result) => this.result = result,
      error: (e) => console.debug(e)
    });
  }
}
