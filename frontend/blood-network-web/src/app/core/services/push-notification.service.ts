import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { initializeApp, FirebaseApp } from 'firebase/app';
import { getMessaging, getToken, onMessage, isSupported, Messaging } from 'firebase/messaging';
import { environment } from '../../../environments/environment';

const FCM_TOKEN_KEY = 'fcm_token';

/**
 * Wires up browser push (FCM) so donor-match/verification/report notifications reach the
 * user even when the tab isn't open. Registers the device token with the backend
 * (POST /api/push/tokens) so PushNotificationService on the server can target this device.
 * Degrades to a no-op wherever push isn't available (unsupported browser, permission denied) -
 * in-app/SignalR notifications keep working regardless.
 */
@Injectable({ providedIn: 'root' })
export class PushNotificationService {
  private readonly apiUrl = `${environment.apiUrl}/push/tokens`;
  private app?: FirebaseApp;
  private messaging?: Messaging;
  private currentToken: string | null = null;
  private registerInFlight = false;

  constructor(
    private http: HttpClient,
    private ngZone: NgZone
  ) {}

  async register(): Promise<void> {
    if (this.registerInFlight || this.currentToken) return;
    this.registerInFlight = true;

    try {
      if (typeof window === 'undefined' || !('serviceWorker' in navigator) || !('Notification' in window)) {
        return;
      }

      const supported = await isSupported().catch(() => false);
      if (!supported || Notification.permission === 'denied') {
        return;
      }

      const registration = await navigator.serviceWorker.register('/firebase-messaging-sw.js');

      if (Notification.permission === 'default') {
        const permission = await Notification.requestPermission();
        if (permission !== 'granted') return;
      } else if (Notification.permission !== 'granted') {
        return;
      }

      this.app ??= initializeApp(environment.firebase);
      this.messaging ??= getMessaging(this.app);

      const token = await getToken(this.messaging, {
        vapidKey: environment.firebaseVapidKey,
        serviceWorkerRegistration: registration
      });
      if (!token) return;

      this.currentToken = token;
      localStorage.setItem(FCM_TOKEN_KEY, token);

      this.http.post(this.apiUrl, { token, platform: 'Web' }).subscribe({
        error: (e) => console.debug('Push token registration failed', e)
      });

      onMessage(this.messaging, (payload) => {
        this.ngZone.run(() => this.showForegroundNotification(payload));
      });
    } catch (err) {
      console.debug('Push notification setup failed', err);
    } finally {
      this.registerInFlight = false;
    }
  }

  /** Call on logout so the server stops targeting this device. */
  unregister(): void {
    const token = this.currentToken ?? localStorage.getItem(FCM_TOKEN_KEY);
    localStorage.removeItem(FCM_TOKEN_KEY);
    this.currentToken = null;
    if (!token) return;

    this.http.delete(`${this.apiUrl}/${encodeURIComponent(token)}`).subscribe({
      error: (e) => console.debug('Push token removal failed', e)
    });
  }

  // The service worker's onBackgroundMessage only fires while the tab is unfocused/closed;
  // foreground messages arrive here instead and need to be surfaced manually.
  private showForegroundNotification(payload: { notification?: { title?: string; body?: string }; data?: Record<string, string> }): void {
    if (Notification.permission !== 'granted') return;
    const title = payload.notification?.title || payload.data?.['title'] || 'Blood Network Bangladesh';
    const body = payload.notification?.body || payload.data?.['message'] || '';
    new Notification(title, { body, icon: '/favicon.ico' });
  }
}
