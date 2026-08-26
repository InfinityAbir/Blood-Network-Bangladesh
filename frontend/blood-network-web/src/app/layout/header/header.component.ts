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
import { Subscription } from 'rxjs';
import { AuthService } from '../../core/services/auth.service';
import { NotificationService } from '../../core/services/notification.service';
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
    MatDividerModule
  ],
  template: `
    <mat-toolbar color="primary">
      <a routerLink="/" class="logo">Blood Network BD</a>
      <span class="spacer"></span>
      <a mat-button routerLink="/find-blood">Find Blood</a>
      <a mat-button routerLink="/request-blood">Need Blood</a>
      @if (authService.isAuthenticated()) {
        <a mat-button [routerLink]="authService.getDashboardRoute()">Dashboard</a>
        <button mat-icon-button [matMenuTriggerFor]="notifMenu" class="notif-btn">
          <mat-icon [matBadge]="unreadCount > 0 ? unreadCount : null" matBadgeColor="accent" matBadgeSize="small">
            notifications
          </mat-icon>
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
        <button mat-button (click)="authService.logout()">Logout</button>
      } @else {
        <a mat-button routerLink="/login">Login</a>
        <a mat-raised-button color="accent" routerLink="/register">Register</a>
      }
    </mat-toolbar>
  `,
  styles: [`
    .logo { text-decoration: none; color: white; font-weight: bold; font-size: 1.2em; }
    .spacer { flex: 1 1 auto; }
    .notif-btn { color: white; }
    .notif-header { display: flex; justify-content: space-between; align-items: center; padding: 8px 16px; font-weight: 500; min-width: 300px; }
    .notif-empty { padding: 24px; text-align: center; color: #999; }
    .notif-item { height: auto !important; padding: 8px 16px !important; }
    .notif-item.unread { background: #e3f2fd; }
    .notif-icon { margin-right: 12px; flex-shrink: 0; }
    .notif-icon.type-bloodrequestmatch { color: #c62828; }
    .notif-icon.type-donoraccepted { color: #2e7d32; }
    .notif-icon.type-donordeclined { color: #f57c00; }
    .notif-icon.type-requestupdate { color: #1565c0; }
    .notif-content { min-width: 0; }
    .notif-title { font-weight: 500; font-size: 13px; }
    .notif-message { font-size: 12px; color: #666; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width: 250px; }
    .notif-time { font-size: 11px; color: #999; margin-top: 2px; }
  `]
})
export class HeaderComponent implements OnInit, OnDestroy {
  notifications: Notification[] = [];
  unreadCount = 0;
  private sub?: Subscription;

  constructor(
    public authService: AuthService,
    private notificationService: NotificationService
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
      next: (notifications) => {
        this.notifications = notifications;
      }
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
