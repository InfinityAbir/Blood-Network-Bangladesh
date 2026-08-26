import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Notification } from '../models/notification';
import { SignalRService, RealtimeNotification } from './signalr.service';

@Injectable({ providedIn: 'root' })
export class NotificationService {
  private readonly apiUrl = `${environment.apiUrl}/notifications`;
  private unreadCountSubject = new BehaviorSubject<number>(0);
  unreadCount$ = this.unreadCountSubject.asObservable();
  private newNotificationSubject = new Subject<Notification>();
  newNotification$ = this.newNotificationSubject.asObservable();

  constructor(
    private http: HttpClient,
    private signalR: SignalRService
  ) {
    this.signalR.notifications$.subscribe(n => {
      this.newNotificationSubject.next(n as any);
      this.unreadCountSubject.next(this.unreadCountSubject.value + 1);
    });

    this.signalR.unreadCount$.subscribe(count => {
      this.unreadCountSubject.next(count);
    });
  }

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

  startConnection(): void {
    this.signalR.start();
  }

  stopConnection(): void {
    this.signalR.stop();
  }
}
