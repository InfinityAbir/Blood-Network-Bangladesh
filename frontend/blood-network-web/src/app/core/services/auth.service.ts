import { Injectable, signal, computed, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap, timeout } from 'rxjs';

// The backend (Render free tier) spins down when idle and can take 50s+ to wake back up
// on the first request - HttpClient has no default timeout, so without this the login/
// register button would spin forever instead of surfacing a "still waking up" error.
const COLD_START_TIMEOUT_MS = 75_000;
import { environment } from '../../../environments/environment';
import { User, AuthResponse, UserRole } from '../models/user';
import { SignalRService } from './signalr.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = `${environment.apiUrl}/auth`;
  private currentUserSignal = signal<User | null>(null);
  private signalR = inject(SignalRService);

  currentUser = this.currentUserSignal.asReadonly();
  isAuthenticated = computed(() => {
    const user = this.currentUserSignal();
    if (!user) return false;
    if (this.isTokenExpired()) return false;
    return true;
  });
  isAdmin = computed(() => this.currentUserSignal()?.role === UserRole.Admin);
  isDonor = computed(() => this.currentUserSignal()?.role === UserRole.Donor);
  isRequester = computed(() => this.currentUserSignal()?.role === UserRole.Requester);

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    this.loadStoredUser();
  }

  register(data: {
    firstName: string;
    lastName: string;
    phoneNumber: string;
    password: string;
    email?: string;
    role?: string;
  }): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/register`, data)
      .pipe(
        timeout(COLD_START_TIMEOUT_MS),
        tap(response => {
          this.storeAuth(response);
        })
      );
  }

  login(phoneNumber: string, password: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, { phoneNumber, password })
      .pipe(
        timeout(COLD_START_TIMEOUT_MS),
        tap(response => {
          this.storeAuth(response);
        })
      );
  }

  refreshToken(refreshToken: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/refresh`, { refreshToken });
  }

  changeFirstLoginCredentials(currentPassword: string, newEmail: string, newPassword: string): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/first-login-change`, { currentPassword, newEmail, newPassword })
      .pipe(
        tap(user => {
          const stored = localStorage.getItem('user');
          if (stored) {
            const updated = { ...JSON.parse(stored), email: user.email, mustChangePassword: user.mustChangePassword };
            localStorage.setItem('user', JSON.stringify(updated));
            this.currentUserSignal.set(updated);
          }
        })
      );
  }

  updateProfile(currentPassword: string, newEmail: string | null, newPhoneNumber: string | null, newPassword: string | null, newPhotoUrl?: string | null): Observable<User> {
    const body: Record<string, string> = { currentPassword };
    if (newEmail) body['newEmail'] = newEmail;
    if (newPhoneNumber) body['newPhoneNumber'] = newPhoneNumber;
    if (newPassword) body['newPassword'] = newPassword;
    if (newPhotoUrl !== undefined && newPhotoUrl !== null) body['newPhotoUrl'] = newPhotoUrl;
    return this.http.put<User>(`${this.apiUrl}/profile`, body)
      .pipe(
        tap(user => {
          const stored = localStorage.getItem('user');
          if (stored) {
            const updated = { ...JSON.parse(stored), email: user.email, phoneNumber: user.phoneNumber, mustChangePassword: user.mustChangePassword, photoUrl: user.photoUrl };
            localStorage.setItem('user', JSON.stringify(updated));
            this.currentUserSignal.set(updated);
          }
        })
      );
  }

  /** Photo-only update — doesn't require the current password (a photo isn't as sensitive
   * as email/phone/password; see backend AuthService.UpdateProfileAsync). */
  updatePhoto(photoUrl: string): Observable<User> {
    return this.updateProfile('', null, null, null, photoUrl);
  }

  logout(): void {
    this.signalR.stop();
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    localStorage.removeItem('user');
    this.currentUserSignal.set(null);
    this.router.navigate(['/']);
  }

  getToken(): string | null {
    return localStorage.getItem('access_token');
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refresh_token');
  }

  getDashboardRoute(): string {
    const role = this.currentUserSignal()?.role;
    switch (role) {
      case UserRole.Admin:
        return '/admin';
      case UserRole.Donor:
        return '/donor/dashboard';
      case UserRole.Requester:
        return '/requester/dashboard';
      default:
        return '/';
    }
  }

  storeAuth(response: AuthResponse): void {
    localStorage.setItem('access_token', response.accessToken);
    localStorage.setItem('refresh_token', response.refreshToken);
    localStorage.setItem('user', JSON.stringify(response.user));
    this.currentUserSignal.set(response.user);
    this.signalR.start();
  }

  isTokenExpired(token?: string | null): boolean {
    const t = token ?? localStorage.getItem('access_token');
    if (!t) return true;
    try {
      const payload = JSON.parse(atob(t.split('.')[1]));
      if (!payload.exp) return false;
      return payload.exp * 1000 < Date.now();
    } catch {
      return true;
    }
  }

  private loadStoredUser(): void {
    const token = localStorage.getItem('access_token');
    const userJson = localStorage.getItem('user');
    if (token && userJson) {
      if (this.isTokenExpired(token)) {
        localStorage.removeItem('access_token');
        localStorage.removeItem('refresh_token');
        localStorage.removeItem('user');
        return;
      }
      try {
        const user = JSON.parse(userJson) as User;
        this.currentUserSignal.set(user);
      } catch {
        localStorage.removeItem('access_token');
        localStorage.removeItem('refresh_token');
        localStorage.removeItem('user');
      }
    }
  }
}
