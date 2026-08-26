import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDividerModule } from '@angular/material/divider';
import { Subscription } from 'rxjs';
import { HeaderComponent } from '../../layout/header/header.component';
import { FooterComponent } from '../../layout/footer/footer.component';
import { NotificationService } from '../../core/services/notification.service';
import { AuthService } from '../../core/services/auth.service';
import { Notification } from '../../core/models/notification';

@Component({
  selector: 'app-notifications',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatDividerModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="page-container">
      <div class="page-header">
        <h1>Notifications</h1>
        @if (unreadCount > 0) {
          <button mat-stroked-button color="primary" (click)="markAllRead()">
            <mat-icon>done_all</mat-icon>
            Mark all as read
          </button>
        }
      </div>

      @if (isLoading) {
        <div class="loading">
          <mat-spinner diameter="40"></mat-spinner>
        </div>
      } @else if (notifications.length === 0) {
        <mat-card class="empty-card">
          <mat-card-content>
            <mat-icon class="empty-icon">notifications_off</mat-icon>
            <p>No notifications yet</p>
            <p class="empty-sub">You'll see updates about your blood requests and matches here.</p>
          </mat-card-content>
        </mat-card>
      } @else {
        <div class="notif-list">
          @for (notif of notifications; track notif.id) {
            <div class="notif-row" [class.unread]="!notif.isRead" (click)="onNotifClick(notif)">
              <mat-icon class="notif-icon" [class]="'type-' + notif.type.toLowerCase()">
                {{ getNotifIcon(notif.type) }}
              </mat-icon>
              <div class="notif-body">
                <div class="notif-title">{{ notif.title }}</div>
                <div class="notif-message">{{ notif.message }}</div>
                <div class="notif-meta">
                  <span class="notif-time">{{ notif.createdAt | date:'medium' }}</span>
                  @if (notif.relatedEntityId) {
                    <span class="notif-link">View details</span>
                  }
                </div>
              </div>
              @if (!notif.isRead) {
                <span class="unread-dot"></span>
              }
            </div>
          }
        </div>

        @if (hasMore) {
          <div class="load-more">
            <button mat-stroked-button color="primary" (click)="loadMore()" [disabled]="isLoadingMore">
              @if (isLoadingMore) {
                <mat-spinner diameter="18" class="inline-spinner"></mat-spinner>
              } @else {
                Load More
              }
            </button>
          </div>
        }
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .page-container { flex: 1; padding: 24px; max-width: 720px; margin: 0 auto; width: 100%; }
    .page-header {
      display: flex; justify-content: space-between; align-items: center;
      margin-bottom: 24px;
    }
    .page-header h1 { margin: 0; font-size: 24px; }

    .loading { display: flex; justify-content: center; padding: 60px; }

    .empty-card { text-align: center; padding: 48px 24px; }
    .empty-icon { font-size: 48px; height: 48px; width: 48px; color: var(--bgn-text-faint); margin-bottom: 12px; }
    .empty-sub { color: var(--bgn-text-muted); font-size: 14px; margin-top: 4px; }

    .notif-list { display: flex; flex-direction: column; gap: 4px; }

    .notif-row {
      display: flex; align-items: flex-start; gap: 14px;
      padding: 14px 16px;
      background: var(--bgn-surface);
      border: 1px solid var(--bgn-border);
      border-radius: var(--bgn-radius-sm);
      cursor: pointer;
      transition: background 0.15s ease, border-color 0.15s ease;
    }
    .notif-row:hover { background: var(--bgn-surface-hover); }
    .notif-row.unread { border-left: 3px solid var(--bgn-primary); }

    .notif-icon { flex-shrink: 0; margin-top: 2px; }
    .notif-icon.type-bloodrequestmatch { color: #c62828; }
    .notif-icon.type-donoraccepted { color: #2e7d32; }
    .notif-icon.type-donordeclined { color: #ed6c02; }
    .notif-icon.type-requestupdate { color: #1565c0; }
    .notif-icon.type-profilereminder { color: #7b1fa2; }
    .notif-icon.type-system { color: var(--bgn-text-muted); }

    .notif-body { flex: 1; min-width: 0; }
    .notif-title { font-weight: 600; font-size: 14px; margin-bottom: 2px; }
    .notif-row.unread .notif-title { color: var(--bgn-text); }
    .notif-message { font-size: 13px; color: var(--bgn-text-muted); line-height: 1.4; }
    .notif-meta { display: flex; align-items: center; gap: 12px; margin-top: 6px; }
    .notif-time { font-size: 12px; color: var(--bgn-text-faint); }
    .notif-link { font-size: 12px; color: var(--bgn-primary); font-weight: 500; }

    .unread-dot {
      flex-shrink: 0; width: 8px; height: 8px; border-radius: 50%;
      background: var(--bgn-primary); margin-top: 6px;
    }

    .load-more { display: flex; justify-content: center; padding: 24px; }
    .inline-spinner { display: inline-block; }

    @media (max-width: 600px) {
      .page-header { flex-direction: column; align-items: flex-start; gap: 12px; }
    }
  `]
})
export class NotificationsComponent implements OnInit, OnDestroy {
  notifications: Notification[] = [];
  unreadCount = 0;
  isLoading = true;
  isLoadingMore = false;
  currentPage = 1;
  pageSize = 20;
  hasMore = true;
  private subscriptions: Subscription[] = [];

  constructor(
    private notificationService: NotificationService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.notificationService.unreadCount$.subscribe(count => {
        this.unreadCount = count;
      })
    );

    this.subscriptions.push(
      this.notificationService.newNotification$.subscribe(notif => {
        this.notifications.unshift(notif);
      })
    );

    this.loadNotifications();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  loadNotifications(): void {
    this.notificationService.getNotifications(1, this.pageSize).subscribe({
      next: (notifications) => {
        this.notifications = notifications;
        this.hasMore = notifications.length >= this.pageSize;
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  loadMore(): void {
    this.isLoadingMore = true;
    this.currentPage++;
    this.notificationService.getNotifications(this.currentPage, this.pageSize).subscribe({
      next: (notifications) => {
        this.notifications = [...this.notifications, ...notifications];
        this.hasMore = notifications.length >= this.pageSize;
        this.isLoadingMore = false;
      },
      error: () => {
        this.currentPage--;
        this.isLoadingMore = false;
      }
    });
  }

  onNotifClick(notif: Notification): void {
    if (!notif.isRead) {
      this.notificationService.markAsRead(notif.id).subscribe();
      notif.isRead = true;
      this.unreadCount = Math.max(0, this.unreadCount - 1);
    }

    if (notif.relatedEntityId) {
      this.navigateToRelated(notif.type, notif.relatedEntityId);
    }
  }

  private navigateToRelated(type: string, entityId: string): void {
    switch (type) {
      case 'BloodRequestMatch':
        this.router.navigate(['/donor/dashboard']);
        break;
      case 'DonorAccepted':
      case 'DonorDeclined':
      case 'RequestUpdate':
        this.router.navigate(['/requester/dashboard']);
        break;
      default:
        this.router.navigate([this.authService.getDashboardRoute()]);
    }
  }

  markAllRead(): void {
    this.notificationService.markAllAsRead().subscribe({
      next: () => {
        this.notifications.forEach(n => n.isRead = true);
        this.unreadCount = 0;
      }
    });
  }

  getNotifIcon(type: string): string {
    switch (type) {
      case 'BloodRequestMatch': return 'bloodtype';
      case 'DonorAccepted': return 'check_circle';
      case 'DonorDeclined': return 'cancel';
      case 'RequestUpdate': return 'info';
      case 'ProfileReminder': return 'person';
      default: return 'notifications';
    }
  }
}
