import { Injectable, NgZone } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface RealtimeNotification {
  title: string;
  message: string;
  type: string;
  relatedEntityId?: string;
  createdAt: string;
  isRead: boolean;
}

@Injectable({ providedIn: 'root' })
export class SignalRService {
  private hubConnection?: signalR.HubConnection;
  private notificationSubject = new Subject<RealtimeNotification>();
  private unreadCountSubject = new Subject<number>();
  private connectionStateSubject = new Subject<'connected' | 'disconnected' | 'reconnecting'>();

  notifications$ = this.notificationSubject.asObservable();
  unreadCount$ = this.unreadCountSubject.asObservable();
  connectionState$ = this.connectionStateSubject.asObservable();

  constructor(private ngZone: NgZone) {}

  async start(): Promise<void> {
    if (this.hubConnection?.state === signalR.HubConnectionState.Connected) return;

    const token = localStorage.getItem('access_token');
    if (!token) return;

    const hubUrl = environment.apiUrl.replace(/\/api\/?$/, '') + '/hubs/notifications';

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(hubUrl, { accessTokenFactory: () => localStorage.getItem('access_token') || '' })
      .withAutomaticReconnect([0, 2, 5, 10, 15, 30])
      .configureLogging(signalR.LogLevel.Warning)
      .build();

    this.hubConnection.on('ReceiveNotification', (notification: RealtimeNotification) => {
      this.ngZone.run(() => {
        this.notificationSubject.next(notification);
      });
    });

    this.hubConnection.on('UnreadCount', (count: number) => {
      this.ngZone.run(() => {
        this.unreadCountSubject.next(count);
      });
    });

    this.hubConnection.onreconnecting(() => {
      this.ngZone.run(() => this.connectionStateSubject.next('reconnecting'));
    });

    this.hubConnection.onreconnected(() => {
      this.ngZone.run(() => this.connectionStateSubject.next('connected'));
    });

    this.hubConnection.onclose(() => {
      this.ngZone.run(() => this.connectionStateSubject.next('disconnected'));
    });

    try {
      await this.hubConnection.start();
      this.ngZone.run(() => this.connectionStateSubject.next('connected'));
    } catch (err) {
      console.warn('SignalR connection failed:', err);
    }
  }

  async stop(): Promise<void> {
    if (this.hubConnection) {
      await this.hubConnection.stop();
      this.hubConnection = undefined;
    }
  }
}
