import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { AdminService } from '../../../core/services/admin.service';
import { AdminUser } from '../../../core/models/admin';
import { PagedResult } from '../../../core/models/paged-result';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="container">
      <h1>User Management</h1>

      <div class="filters">
        <mat-form-field appearance="outline">
          <mat-label>Search</mat-label>
          <input matInput [(ngModel)]="searchTerm" placeholder="Name, phone, email" (keyup.enter)="loadUsers()">
        </mat-form-field>
        <mat-form-field appearance="outline">
          <mat-label>Role</mat-label>
          <mat-select [(ngModel)]="selectedRole" (selectionChange)="loadUsers()">
            <mat-option value="">All</mat-option>
            <mat-option value="Donor">Donor</mat-option>
            <mat-option value="Requester">Requester</mat-option>
            <mat-option value="Admin">Admin</mat-option>
          </mat-select>
        </mat-form-field>
        <button mat-raised-button color="primary" (click)="loadUsers()">Search</button>
      </div>

      @if (isLoading) {
        <div class="loading"><mat-spinner diameter="40"></mat-spinner></div>
      } @else if (result && result.items.length > 0) {
        <div class="result-info">Showing {{ result.items.length }} of {{ result.totalCount }} users</div>
        @for (user of result.items; track user.id) {
          <mat-card class="user-card">
            <mat-card-header>
              <mat-card-title>{{ user.firstName }} {{ user.lastName }}</mat-card-title>
              <mat-card-subtitle>{{ user.phoneNumber }} {{ user.email ? '• ' + user.email : '' }}</mat-card-subtitle>
            </mat-card-header>
            <mat-card-content>
              <div class="user-info">
                <span class="chip role">{{ user.role }}</span>
                <span class="chip" [class]="user.isActive ? 'active' : 'inactive'">{{ user.isActive ? 'Active' : 'Inactive' }}</span>
                @if (user.donorVerificationStatus) {
                  <span class="chip verify" [class]="'verify-' + user.donorVerificationStatus.toLowerCase()">{{ user.donorVerificationStatus }}</span>
                }
                <span class="detail">Joined {{ user.createdAt | date:'mediumDate' }}</span>
                @if (user.lastLoginAt) {
                  <span class="detail">Last login {{ user.lastLoginAt | date:'short' }}</span>
                }
              </div>
            </mat-card-content>
            <mat-card-actions align="end">
              @if (user.role === 'Donor' && user.donorVerificationStatus === 'Pending') {
                <button mat-button color="primary" (click)="verifyDonor(user.id, 'Verified')">Verify</button>
                <button mat-button color="warn" (click)="verifyDonor(user.id, 'Rejected')">Reject</button>
              }
              <button mat-button [color]="user.isActive ? 'warn' : 'primary'" (click)="toggleActive(user.id, !user.isActive)">
                {{ user.isActive ? 'Deactivate' : 'Activate' }}
              </button>
            </mat-card-actions>
          </mat-card>
        }
        @if (result.totalPages > 1) {
          <div class="pagination">
            <button mat-button [disabled]="!result.hasPrevious" (click)="goPage(result.page - 1)">Previous</button>
            <span>Page {{ result.page }} of {{ result.totalPages }}</span>
            <button mat-button [disabled]="!result.hasNext" (click)="goPage(result.page + 1)">Next</button>
          </div>
        }
      } @else {
        <div class="no-results">No users found</div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .filters { display: flex; gap: 12px; align-items: center; margin-bottom: 24px; flex-wrap: wrap; }
    .filters mat-form-field { flex: 1; min-width: 200px; }
    .loading { display: flex; justify-content: center; padding: 60px; }
    .result-info { font-size: 13px; color: #666; margin-bottom: 12px; }
    .user-card { margin-bottom: 8px; }
    .user-info { display: flex; flex-wrap: wrap; gap: 8px; align-items: center; margin-top: 8px; }
    .chip { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; font-weight: 500; }
    .chip.role { background: #e3f2fd; color: #1565c0; }
    .chip.active { background: #e8f5e9; color: #2e7d32; }
    .chip.inactive { background: #ffebee; color: #c62828; }
    .verify-verified { background: #e8f5e9; color: #2e7d32; }
    .verify-pending { background: #fff3e0; color: #e65100; }
    .verify-unverified { background: #f5f5f5; color: #666; }
    .verify-rejected { background: #ffebee; color: #c62828; }
    .detail { font-size: 12px; color: #999; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; margin-top: 16px; }
  `]
})
export class UserManagementComponent implements OnInit {
  result: PagedResult<AdminUser> | null = null;
  isLoading = true;
  searchTerm = '';
  selectedRole = '';
  currentPage = 1;

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.isLoading = true;
    this.currentPage = 1;
    this.adminService.getUsers({
      search: this.searchTerm || undefined,
      role: this.selectedRole || undefined,
      page: this.currentPage
    }).subscribe({
      next: (result) => {
        this.result = result;
        this.isLoading = false;
      },
      error: (e) => {
        console.debug(e);
        this.isLoading = false;
      }
    });
  }

  goPage(page: number): void {
    this.currentPage = page;
    this.adminService.getUsers({
      search: this.searchTerm || undefined,
      role: this.selectedRole || undefined,
      page
    }).subscribe({
      next: (result) => this.result = result,
      error: (e) => console.debug(e)
    });
  }

  toggleActive(userId: string, isActive: boolean): void {
    this.adminService.toggleUserActive(userId, isActive).subscribe({
      next: () => this.loadUsers(),
      error: (e) => console.debug(e)
    });
  }

  verifyDonor(userId: string, status: string): void {
    this.adminService.verifyDonor(userId, status).subscribe({
      next: () => this.loadUsers(),
      error: (e) => console.debug(e)
    });
  }
}
