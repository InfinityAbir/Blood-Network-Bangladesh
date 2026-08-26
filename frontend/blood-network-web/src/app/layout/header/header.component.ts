import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Subscription } from 'rxjs';
import { AuthService } from '../../core/services/auth.service';
import { NotificationService } from '../../core/services/notification.service';
import { ThemeService } from '../../core/services/theme.service';
import { Notification } from '../../core/models/notification';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatBadgeModule,
    MatListModule,
    MatDividerModule,
    MatTooltipModule
  ],
  template: `
    <mat-toolbar class="bgn-header">
      <a routerLink="/" class="logo" aria-label="Blood Network Bangladesh home">
        <mat-icon class="logo-icon">water_drop</mat-icon>
        <span class="logo-text">Blood Network <span class="logo-accent">BD</span></span>
      </a>

      <span class="spacer"></span>

      <button
        mat-icon-button
        class="theme-toggle"
        (click)="theme.toggle()"
        [matTooltip]="theme.mode() === 'dark' ? 'Switch to light mode' : 'Switch to dark mode'"
        [attr.aria-label]="theme.mode() === 'dark' ? 'Switch to light mode' : 'Switch to dark mode'">
        <mat-icon>{{ theme.mode() === 'dark' ? 'light_mode' : 'dark_mode' }}</mat-icon>
      </button>

      <a mat-button routerLink="/find-blood" class="nav-link">Find Blood</a>
      <a mat-button routerLink="/request-blood" class="nav-link">Need Blood</a>

      @if (authService.isAuthenticated()) {
        <a mat-button [routerLink]="authService.getDashboardRoute()" class="nav-link">Dashboard</a>
        <button mat-icon-button [matMenuTriggerFor]="notifMenu" class="notif-btn">
          <mat-icon [matBadge]="unreadCount > 0 ? unreadCount : null"
                    matBadgeColor="warn" matBadgeSize="small">notifications</mat-icon>
        </button>
        <mat-menu #notifMenu="matMenu" class="notif-menu" xPosition="before">
          <div class="notif-header">
            <span>Notifications</span>
            @if (unreadCount > 0) {
              <button mat-button color="primary" (click)="markAllRead($event)">Mark all read</button>
            }
          </div>
          <mat-divider></mat-divider>
          @if (notifications.length === 0) {
            <div class="notif-empty">No notifications</div>
          }
          @for (notif of notifications; track notif.id) {
            <button mat-menu-item class="notif-item" [class.unread]="!notif.isRead" (click)="onNotifClick($event, notif)">
              <mat-icon class="notif-icon" [class]="'type-' + notif.type.toLowerCase()">
                {{ getNotifIcon(notif.type) }}
              </mat-icon>
              <div class="notif-content">
                <div class="notif-title">{{ notif.title }}</div>
                <div class="notif-message">{{ notif.message }}</div>
                <div class="notif-time">{{ notif.createdAt | date:'short' }}</div>
              </div>
            </button>
          }
        </mat-menu>
        <button mat-button class="logout-btn" (click)="authService.logout()">Logout</button>
      } @else {
        <a mat-button routerLink="/login" class="nav-link">Login</a>
        <a mat-raised-button color="primary" routerLink="/register" class="register-btn">Register</a>
      }
    </mat-toolbar>
  `,
  styles: [`
    :host { display: block; }
    .bgn-header {
      position: sticky;
      top: 0;
      z-index: 100;
      width: 100%;
      left: 0;
      right: 0;
      box-sizing: border-box;
      background: var(--bgn-header-bg);
      color: #fff;
      height: 64px;
      min-height: 64px;
      padding: 0 16px;
      box-shadow: var(--bgn-shadow-md);
      gap: 6px;
      display: flex;
      align-items: center;
      flex-wrap: nowrap;
      overflow: visible;
    }

    .logo {
      display: flex;
      align-items: center;
      gap: 8px;
      text-decoration: none;
      color: #fff;
      font-weight: 700;
      font-size: 1.15rem;
      letter-spacing: 0.2px;
      flex-shrink: 0;
      min-width: 0;
      white-space: nowrap;
    }
    .logo-icon { color: #fff; height: 26px; width: 26px; font-size: 26px; line-height: 26px; flex-shrink: 0; overflow: visible; }
    .logo-accent { color: #ffd2d2; font-weight: 800; }
    .logo-text { white-space: nowrap; overflow: visible; }

    .spacer { flex: 1 1 auto; min-width: 8px; }

    .nav-link {
      color: #fff !important;
      opacity: 0.92;
      white-space: nowrap;
      flex-shrink: 0;
    }
    .nav-link:hover { opacity: 1; background: rgba(255,255,255,0.14) !important; }

    .theme-toggle {
      color: #fff !important;
      flex-shrink: 0;
      width: 40px; height: 40px;
      display: inline-flex; align-items: center; justify-content: center;
      border-radius: 50%;
    }
    .theme-toggle mat-icon { font-size: 22px; height: 22px; width: 22px; line-height: 22px; }

    .register-btn { color: #b71c1c !important; background: #fff !important; flex-shrink: 0; white-space: nowrap; }

    .notif-btn { color: #fff !important; flex-shrink: 0; }
    .logout-btn { color: #fff !important; flex-shrink: 0; white-space: nowrap; }

    .notif-header {
      display: flex; justify-content: space-between; align-items: center;
      padding: 8px 16px; font-weight: 600; min-width: 300px;
      color: var(--bgn-text);
    }
    .notif-empty { padding: 24px; text-align: center; color: var(--bgn-text-faint); }
    .notif-item { height: auto !important; padding: 8px 16px !important; white-space: normal; }
    .notif-item.unread { background: rgba(229,57,53,0.08); }
    .notif-icon { margin-right: 12px; flex-shrink: 0; }
    .notif-icon.type-bloodrequestmatch { color: #c62828; }
    .notif-icon.type-donoraccepted { color: #2e7d32; }
    .notif-icon.type-donordeclined { color: #ed6c02; }
    .notif-icon.type-requestupdate { color: #1565c0; }
    .notif-content { min-width: 0; }
    .notif-title { font-weight: 500; font-size: 13px; color: var(--bgn-text); }
    .notif-message {
      font-size: 12px; color: var(--bgn-text-muted);
      white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width: 250px;
    }
    .notif-time { font-size: 11px; color: var(--bgn-text-faint); margin-top: 2px; }

    @media (max-width: 600px) {
      .nav-link, .logout-btn { display: none; }
      .logo-text { font-size: 1rem; }
    }
  `]
})
export class HeaderComponent implements OnInit, OnDestroy {
  notifications: Notification[] = [];
  unreadCount = 0;
  private sub?: Subscription;

  constructor(
    public authService: AuthService,
    private notificationService: NotificationService,
    public theme: ThemeService
  ) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.notificationService.refreshUnreadCount();
      this.sub = this.notificationService.unreadCount$.subscribe(count => {
        this.unreadCount = count;
      });
      this.loadNotifications();
    }
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  loadNotifications(): void {
    this.notificationService.getNotifications(1, 10).subscribe({
      next: (notifications) => { this.notifications = notifications; }
    });
  }

  onNotifClick(event: Event, notif: Notification): void {
    event.stopPropagation();
    if (!notif.isRead) {
      this.notificationService.markAsRead(notif.id).subscribe();
      notif.isRead = true;
      this.unreadCount = Math.max(0, this.unreadCount - 1);
    }
  }

  markAllRead(event: Event): void {
    event.stopPropagation();
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
