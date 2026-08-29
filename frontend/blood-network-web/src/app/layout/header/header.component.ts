import { Component, HostListener, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
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
    RouterLinkActive,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatBadgeModule,
    MatListModule,
    MatDividerModule,
    MatTooltipModule,
    MatSnackBarModule
  ],
  template: `
    <mat-toolbar class="bgn-header" [class.scrolled]="scrolled">
      <a routerLink="/" class="logo" aria-label="Blood Network Bangladesh home">
        <svg class="logo-icon" viewBox="0 0 24 24" width="26" height="26" aria-hidden="true">
          <!-- White water-drop -->
          <path d="M12 2.5s7 5.8 7 11.2A7 7 0 1 1 5 13.7C5 8.3 12 2.5 12 2.5z" fill="#FFFFFF"/>
          <!-- Minimal red medical cross (+) centered inside the drop -->
          <g fill="#C62828">
            <rect x="10.7" y="12.1" width="2.6" height="1.15" rx="0.3"/>
            <rect x="11.42" y="10.7" width="1.15" height="2.6" rx="0.3"/>
          </g>
        </svg>
        <span class="logo-text">Blood Network <span class="logo-accent">BD</span></span>
      </a>

      <span class="spacer"></span>

      <button
        mat-icon-button
        class="theme-toggle bgn-press"
        (click)="theme.toggle()"
        [matTooltip]="theme.mode() === 'dark' ? 'Switch to light mode' : 'Switch to dark mode'"
        [attr.aria-label]="theme.mode() === 'dark' ? 'Switch to light mode' : 'Switch to dark mode'">
        <span class="theme-icon-swap">
          @if (theme.mode() === 'dark') {
            <svg viewBox="0 0 24 24" width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="4"/><path d="M12 2v2M12 20v2M4.93 4.93l1.41 1.41M17.66 17.66l1.41 1.41M2 12h2M20 12h2M6.34 17.66l-1.41 1.41M19.07 4.93l-1.41 1.41"/></svg>
          } @else {
            <svg viewBox="0 0 24 24" width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"/></svg>
          }
        </span>
      </button>

      @if (authService.isAuthenticated()) {
        <button mat-icon-button [matMenuTriggerFor]="notifMenu" class="notif-btn" aria-label="Notifications">
          <mat-icon [matBadge]="unreadCount > 0 ? unreadCount : null"
                    matBadgeColor="warn" matBadgeSize="small">notifications</mat-icon>
        </button>
      }

      <nav class="desktop-nav">
        <a mat-button routerLink="/find-blood" routerLinkActive="active" class="nav-link">Find Blood</a>
        <a mat-button routerLink="/request-blood" routerLinkActive="active" class="nav-link">Need Blood</a>
        @if (authService.isAuthenticated()) {
          <a mat-button [routerLink]="authService.getDashboardRoute()" routerLinkActive="active" class="nav-link">Dashboard</a>
          <button mat-button class="logout-btn bgn-press" (click)="authService.logout()">Logout</button>
        } @else {
          <a mat-button routerLink="/login" routerLinkActive="active" class="nav-link">Login</a>
          <a mat-raised-button color="primary" routerLink="/register" class="register-btn bgn-press">Register</a>
        }
      </nav>

      <button mat-icon-button class="mobile-menu-btn" [matMenuTriggerFor]="mobileNav" aria-label="Open menu">
        <mat-icon>menu</mat-icon>
      </button>
    </mat-toolbar>

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
      <mat-divider></mat-divider>
      <a mat-menu-item routerLink="/notifications" (click)="$event.stopPropagation()">
        <mat-icon>list</mat-icon>
        <span>View All Notifications</span>
      </a>
    </mat-menu>

    <mat-menu #mobileNav="matMenu" class="mobile-nav-menu">
      <a mat-menu-item routerLink="/find-blood"><mat-icon>bloodtype</mat-icon><span>Find Blood</span></a>
      <a mat-menu-item routerLink="/request-blood"><mat-icon>volunteer_activism</mat-icon><span>Need Blood</span></a>
      @if (authService.isAuthenticated()) {
        <a mat-menu-item [routerLink]="authService.getDashboardRoute()"><mat-icon>dashboard</mat-icon><span>Dashboard</span></a>
        <a mat-menu-item routerLink="/notifications"><mat-icon>notifications</mat-icon><span>Notifications @if(unreadCount>0){ ({{unreadCount}})}</span></a>
        <button mat-menu-item (click)="authService.logout()"><mat-icon>logout</mat-icon><span>Logout</span></button>
      } @else {
        <a mat-menu-item routerLink="/login"><mat-icon>login</mat-icon><span>Login</span></a>
        <a mat-menu-item routerLink="/register"><mat-icon>person_add</mat-icon><span>Register</span></a>
      }
    </mat-menu>
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
      transition: box-shadow 0.25s ease, background 0.25s ease, height 0.25s ease, min-height 0.25s ease;
    }
    .bgn-header.scrolled {
      height: 58px;
      min-height: 58px;
      box-shadow: 0 4px 24px rgba(0,0,0,0.22);
      backdrop-filter: saturate(160%) blur(10px);
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
      transition: transform 0.2s ease-out;
    }
    .logo:hover { transform: scale(1.03); }
    .logo:hover .logo-icon { animation: bgn-heartbeat 0.9s ease-in-out; }
    .logo-icon { color: #fff; height: 26px; width: 26px; font-size: 26px; line-height: 26px; flex-shrink: 0; overflow: visible; }
    .logo-accent { color: #ffd2d2; font-weight: 800; }
    .logo-text { white-space: nowrap; overflow: visible; }

    .spacer { flex: 1 1 auto; min-width: 8px; }

    .nav-link {
      position: relative;
      color: #fff !important;
      opacity: 0.92;
      white-space: nowrap;
      flex-shrink: 0;
      transition: opacity 0.2s ease, background-color 0.2s ease;
    }
    .nav-link:hover { opacity: 1; background: rgba(255,255,255,0.14) !important; }
    .nav-link::after {
      content: '';
      position: absolute; left: 14px; right: 14px; bottom: 6px;
      height: 2px; background: #fff; border-radius: 2px;
      transform: scaleX(0); transform-origin: center;
      transition: transform 0.25s ease-out;
    }
    .nav-link:hover::after,
    .nav-link.active::after { transform: scaleX(1); }

    .theme-toggle {
      color: #fff !important;
      flex-shrink: 0;
      width: 40px; height: 40px;
      display: inline-flex; align-items: center; justify-content: center;
      border-radius: 50%;
      transition: background-color 0.2s ease;
    }
    .theme-toggle:hover { background: rgba(255,255,255,0.14); }
    .theme-toggle mat-icon { font-size: 22px; height: 22px; width: 22px; line-height: 22px; }
    .theme-icon-swap {
      display: inline-flex; align-items: center; justify-content: center;
      animation: bgn-fade-up 0.3s ease-out;
    }

    .register-btn {
      color: #b71c1c !important; background: #fff !important; flex-shrink: 0; white-space: nowrap;
      transition: transform 0.15s ease-out, box-shadow 0.15s ease-out;
    }
    .register-btn:hover { transform: translateY(-1px); box-shadow: 0 6px 14px -4px rgba(0,0,0,0.35); }

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

    .desktop-nav { display: flex; align-items: center; gap: 6px; }
    .mobile-menu-btn { display: none !important; color: #fff !important; }

    @media (max-width: 820px) {
      .bgn-header { gap: 4px; padding: 0 8px; }
      .desktop-nav { display: none !important; }
      .mobile-menu-btn { display: inline-flex !important; }
      .logo-text { font-size: 1rem; }
    }
    @media (max-width: 400px) {
      .logo-text { font-size: 0.95rem; }
      .bgn-header { padding: 0 6px; }
    }
  `]
})
export class HeaderComponent implements OnInit, OnDestroy {
  notifications: Notification[] = [];
  unreadCount = 0;
  scrolled = false;
  private subscriptions: Subscription[] = [];

  @HostListener('window:scroll')
  onWindowScroll(): void {
    this.scrolled = window.scrollY > 8;
  }

  constructor(
    public authService: AuthService,
    private notificationService: NotificationService,
    private router: Router,
    public theme: ThemeService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.notificationService.startConnection();
      this.notificationService.refreshUnreadCount();

      this.subscriptions.push(
        this.notificationService.unreadCount$.subscribe(count => {
          this.unreadCount = count;
        })
      );

      this.subscriptions.push(
        this.notificationService.newNotification$.subscribe(notif => {
          this.notifications.unshift(notif);
          if (this.notifications.length > 10) {
            this.notifications = this.notifications.slice(0, 10);
          }
          const snackBarRef = this.snackBar.open(notif.message, 'View', {
            duration: 5000,
            horizontalPosition: 'end',
            verticalPosition: 'top'
          });
          snackBarRef.onAction().subscribe(() => {
            if (notif.relatedEntityId) {
              this.navigateToRelated(notif.type, notif.relatedEntityId);
            } else {
              this.router.navigate(['/notifications']);
            }
          });
        })
      );

      this.loadNotifications();
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
    // SignalR lifecycle is owned by AuthService (storeAuth/logout); do not stop on header destroy to avoid flicker
  }

  loadNotifications(): void {
    this.notificationService.getNotifications(1, 10).subscribe({
      next: (notifications) => { this.notifications = notifications; },
      error: (e) => console.debug(e)
    });
  }

  onNotifClick(event: Event, notif: Notification): void {
    event.stopPropagation();
    if (!notif.isRead) {
      this.notificationService.markAsRead(notif.id).subscribe({ error: (e) => console.debug(e) });
      notif.isRead = true;
      this.unreadCount = Math.max(0, this.unreadCount - 1);
    }

    if (notif.relatedEntityId) {
      this.navigateToRelated(notif.type, notif.relatedEntityId);
    } else {
      this.router.navigate([this.authService.getDashboardRoute()]);
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

  markAllRead(event: Event): void {
    event.stopPropagation();
    this.notificationService.markAllAsRead().subscribe({
      next: () => {
        this.notifications.forEach(n => n.isRead = true);
        this.unreadCount = 0;
      },
      error: (e) => console.debug(e)
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
