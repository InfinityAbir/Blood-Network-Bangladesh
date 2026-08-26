import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User, AuthResponse, UserRole } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = `${environment.apiUrl}/auth`;
  private currentUserSignal = signal<User | null>(null);

  currentUser = this.currentUserSignal.asReadonly();
  isAuthenticated = computed(() => !!this.currentUserSignal());
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
        tap(response => {
          this.storeAuth(response);
        })
      );
  }

  login(phoneNumber: string, password: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, { phoneNumber, password })
      .pipe(
        tap(response => {
          this.storeAuth(response);
        })
      );
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

  logout(): void {
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

  private storeAuth(response: AuthResponse): void {
    localStorage.setItem('access_token', response.accessToken);
    localStorage.setItem('refresh_token', response.refreshToken);
    localStorage.setItem('user', JSON.stringify(response.user));
    this.currentUserSignal.set(response.user);
  }

  private loadStoredUser(): void {
    const token = localStorage.getItem('access_token');
    const userJson = localStorage.getItem('user');
    if (token && userJson) {
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
