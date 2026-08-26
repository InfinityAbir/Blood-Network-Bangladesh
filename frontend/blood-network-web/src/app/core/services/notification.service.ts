import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap, interval, Subject, takeUntil } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Notification } from '../models/notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private readonly apiUrl = `${environment.apiUrl}/notifications`;
  private unreadCountSubject = new BehaviorSubject<number>(0);
  unreadCount$ = this.unreadCountSubject.asObservable();
  private destroy$ = new Subject<void>();
  private isPolling = false;

  constructor(private http: HttpClient, private ngZone: NgZone) {}

  getNotifications(page = 1, pageSize = 20): Observable<Notification[]> {
    return this.http.get<Notification[]>(this.apiUrl, {
      params: { page: page.toString(), pageSize: pageSize.toString() }
    });
  }

  getUnreadCount(): Observable<{ count: number }> {
    return this.http.get<{ count: number }>(`${this.apiUrl}/unread-count`).pipe(
      tap(response => this.unreadCountSubject.next(response.count))
    );
  }

  markAsRead(notificationId: string): Observable<Notification> {
    return this.http.post<Notification>(`${this.apiUrl}/${notificationId}/read`, {}).pipe(
      tap(() => {
        const current = this.unreadCountSubject.value;
        this.unreadCountSubject.next(Math.max(0, current - 1));
      })
    );
  }

  markAllAsRead(): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/read-all`, {}).pipe(
      tap(() => this.unreadCountSubject.next(0))
    );
  }

  refreshUnreadCount(): void {
    this.getUnreadCount().subscribe();
  }

  startPolling(): void {
    if (this.isPolling) return;
    this.isPolling = true;
    this.ngZone.runOutsideAngular(() => {
      interval(30000).pipe(
        takeUntil(this.destroy$)
      ).subscribe(() => {
        this.ngZone.run(() => {
          this.refreshUnreadCount();
        });
      });
    });
  }

  stopPolling(): void {
    this.isPolling = false;
    this.destroy$.next();
    this.destroy$.complete();
    this.destroy$ = new Subject<void>();
  }
}
