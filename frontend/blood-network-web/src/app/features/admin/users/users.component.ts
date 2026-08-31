import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatChipsModule } from '@angular/material/chips';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';
import { AdminService } from '../../../core/services/admin.service';
import { AdminUser } from '../../../core/models/admin';
import { PagedResult } from '../../../core/models/paged-result';
import { RevealDirective } from '../../../shared/directives/reveal.directive';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
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
      <h1>User Management</h1>

      <div class="filters bgn-fade-up">
        <div class="search-row">
          <mat-form-field appearance="outline" class="search-field">
            <mat-label>Search</mat-label>
            <input matInput [(ngModel)]="searchTerm" placeholder="Name, phone, email" (keyup.enter)="loadUsers()">
            <mat-icon matSuffix>search</mat-icon>
          </mat-form-field>
          <button mat-raised-button color="primary" (click)="loadUsers()" class="bgn-press search-btn">
            <mat-icon>search</mat-icon> Search
          </button>
          <button mat-stroked-button (click)="resetFilters()" class="bgn-press">
            <mat-icon>clear</mat-icon> Reset
          </button>
        </div>

        <div class="filter-groups">
          <div class="filter-group">
            <span class="filter-label">Role</span>
            <div class="chip-row">
              <button mat-stroked-button class="filter-chip" [class.active]="selectedRole===''" (click)="setRole('')">All</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedRole==='Donor'" (click)="setRole('Donor')">Donor</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedRole==='Requester'" (click)="setRole('Requester')">Requester</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedRole==='Admin'" (click)="setRole('Admin')">Admin</button>
            </div>
          </div>
          <div class="filter-group">
            <span class="filter-label">Status</span>
            <div class="chip-row">
              <button mat-stroked-button class="filter-chip" [class.active]="selectedStatus===''" (click)="setStatus('')">All</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedStatus==='Active'" (click)="setStatus('Active')"><mat-icon class="chip-icon">check_circle</mat-icon> Active</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedStatus==='Deactive'" (click)="setStatus('Deactive')"><mat-icon class="chip-icon">block</mat-icon> Deactive</button>
            </div>
          </div>
          <div class="filter-group">
            <span class="filter-label">Verify</span>
            <div class="chip-row">
              <button mat-stroked-button class="filter-chip" [class.active]="selectedVerification===''" (click)="setVerification('')">All</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedVerification==='Verified'" (click)="setVerification('Verified')">Verified</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedVerification==='Unverified'" (click)="setVerification('Unverified')">Unverified</button>
              <button mat-stroked-button class="filter-chip" [class.active]="selectedVerification==='Rejected'" (click)="setVerification('Rejected')">Rejected</button>
            </div>
          </div>
        </div>
      </div>

      @if (isLoading) {
        <div class="sk-list">
          @for (i of [1,2,3,4,5]; track i) {
            <mat-card class="sk-user-card">
              <mat-card-header>
                <mat-card-title><app-skeleton type="line" width="160px" height="16px" /></mat-card-title>
                <mat-card-subtitle><app-skeleton type="line" width="200px" height="12px" /></mat-card-subtitle>
              </mat-card-header>
              <mat-card-content>
                <div class="sk-chips">
                  <app-skeleton type="rect" width="70px" height="22px" />
                  <app-skeleton type="rect" width="60px" height="22px" />
                  <app-skeleton type="line" width="100px" height="12px" />
                </div>
              </mat-card-content>
            </mat-card>
          }
        </div>
      } @else if (result && filteredItems.length > 0) {
        <div class="results-panel" appReveal>
        @for (user of filteredItems; track user.id) {
          <mat-card class="user-card bgn-hover-lift">
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
              @if (user.role === 'Donor' && user.donorVerificationStatus === 'Unverified') {
                <button mat-button color="primary" (click)="verifyDonor(user.id, 'Verified')" class="bgn-press">Verify</button>
                <button mat-button color="warn" (click)="verifyDonor(user.id, 'Rejected')" class="bgn-press">Reject</button>
              }
              @if (user.role === 'Donor' && user.donorVerificationStatus === 'Verified') {
                <button mat-button color="warn" (click)="verifyDonor(user.id, 'Rejected')" class="bgn-press">Reject</button>
              }
              @if (user.role === 'Donor' && user.donorVerificationStatus === 'Rejected') {
                <button mat-button color="primary" (click)="verifyDonor(user.id, 'Verified')" class="bgn-press">Verify</button>
              }
              <button mat-button [color]="user.isActive ? 'warn' : 'primary'" (click)="toggleActive(user.id, !user.isActive)" class="bgn-press" [disabled]="isSelf(user.id) && user.isActive">
                {{ user.isActive ? 'Deactivate' : 'Activate' }}
              </button>
            </mat-card-actions>
          </mat-card>
        }
        <app-pagination
          [page]="result.page"
          [pageSize]="pageSize"
          [total]="result.totalCount"
          label="users"
          (pageChange)="goPage($event)"
          (pageSizeChange)="onPageSizeChange($event)">
        </app-pagination>
        </div>
      } @else {
        <div class="no-results">No users found</div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }
    .back-link { margin-bottom: 12px; }
    .filters {
      background: var(--bgn-surface, #fff);
      border: 1px solid var(--bgn-border, #e8e8e8);
      border-radius: 12px;
      padding: 16px;
      margin-bottom: 24px;
      box-shadow: 0 1px 3px rgba(0,0,0,0.04);
    }
    .search-row {
      display: flex;
      gap: 12px;
      align-items: center;
      flex-wrap: wrap;
      margin-bottom: 16px;
    }
    .search-field { flex: 1; min-width: 240px; }
    .search-btn { height: 56px; }
    .filter-groups {
      display: flex;
      flex-direction: column;
      gap: 12px;
    }
    .filter-group {
      display: flex;
      align-items: center;
      gap: 12px;
      flex-wrap: wrap;
    }
    .filter-label {
      font-size: 13px;
      font-weight: 600;
      color: var(--bgn-text-muted, #666);
      min-width: 48px;
      text-transform: uppercase;
      letter-spacing: 0.5px;
    }
    .chip-row {
      display: flex;
      gap: 8px;
      flex-wrap: wrap;
    }
    .filter-chip {
      border-radius: 999px !important;
      font-size: 13px;
      font-weight: 500;
      height: 32px;
      padding: 0 14px !important;
      border: 1px solid var(--bgn-border, #e0e0e0) !important;
      background: var(--bgn-surface, #fff) !important;
      color: var(--bgn-text, #333) !important;
      transition: all 0.2s ease;
    }
    .filter-chip.active {
      background: var(--bgn-primary, #e53935) !important;
      color: #fff !important;
      border-color: var(--bgn-primary, #e53935) !important;
      box-shadow: 0 2px 8px rgba(229,57,53,0.25);
    }
    .filter-chip .chip-icon {
      font-size: 16px;
      width: 16px;
      height: 16px;
      margin-right: 4px;
    }
    .filter-chip.active .chip-icon {
      color: #fff;
    }
    .sk-list { display: flex; flex-direction: column; gap: 8px; }
    .sk-user-card { min-height: 100px; }
    .sk-chips { display: flex; gap: 8px; align-items: center; margin-top: 8px; }
    .results-panel { display: flex; flex-direction: column; }
    .result-info { font-size: 13px; color: #666; margin-bottom: 12px; }
    .user-card { margin-bottom: 8px; }
    .user-info { display: flex; flex-wrap: wrap; gap: 8px; align-items: center; margin-top: 8px; }
    .chip { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; font-weight: 500; }
    .chip.role { background: #e3f2fd; color: #1565c0; }
    .chip.active { background: #e8f5e9; color: #2e7d32; }
    .chip.inactive { background: #ffebee; color: #c62828; }
    .verify-verified { background: #e8f5e9; color: #2e7d32; }
    .verify-unverified { background: #f5f5f5; color: #666; }
    .verify-rejected { background: #ffebee; color: #c62828; }
    .detail { font-size: 12px; color: #999; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; margin-top: 16px; }
    @media (max-width: 600px) {
      .container { padding: 16px; }
      .filters { flex-direction: column; align-items: stretch; }
      .filters mat-form-field { min-width: 0; }
      .filters button { width: 100%; }
      .user-card mat-card-actions { flex-wrap: wrap; gap: 8px !important; }
      .user-card mat-card-actions button { flex: 1; min-width: 80px; }
    }
  `]
})
export class UserManagementComponent implements OnInit {
  result: PagedResult<AdminUser> | null = null;
  isLoading = true;
  searchTerm = '';
  selectedRole = '';
  selectedStatus = '';
  selectedVerification = '';
  currentPage = 1;
  pageSize = 10;

  constructor(
    private adminService: AdminService,
    private cdr: ChangeDetectorRef,
    private authService: AuthService,
    private route: ActivatedRoute
  ) {}

  get filteredItems(): AdminUser[] {
    if (!this.result) return [];
    if (!this.selectedVerification) return this.result.items;
    return this.result.items.filter(u => u.donorVerificationStatus === this.selectedVerification);
  }

  isSelf(userId: string): boolean {
    return this.authService.currentUser()?.id === userId;
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['role']) this.selectedRole = params['role'];
      if (params['verify']) this.selectedVerification = params['verify'];
    });
    this.loadUsers();
  }

  private getIsActive(): boolean | undefined {
    if (this.selectedStatus === 'Active') return true;
    if (this.selectedStatus === 'Deactive') return false;
    return undefined;
  }

  setRole(role: string): void {
    this.selectedRole = role;
    this.loadUsers();
  }

  setStatus(status: string): void {
    this.selectedStatus = status;
    this.loadUsers();
  }

  setVerification(status: string): void {
    this.selectedVerification = status;
  }

  resetFilters(): void {
    this.searchTerm = '';
    this.selectedRole = '';
    this.selectedStatus = '';
    this.selectedVerification = '';
    this.loadUsers();
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.loadUsers();
  }

  loadUsers(): void {
    this.isLoading = true;
    this.currentPage = 1;
    this.adminService.getUsers({
      search: this.searchTerm || undefined,
      role: this.selectedRole || undefined,
      isActive: this.getIsActive(),
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
    this.adminService.getUsers({
      search: this.searchTerm || undefined,
      role: this.selectedRole || undefined,
      isActive: this.getIsActive(),
      page,
      pageSize: this.pageSize
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
