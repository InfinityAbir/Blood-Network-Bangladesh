import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, switchMap, tap, throwError, Observable, finalize } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { AuthResponse } from '../models/user';

let refresh$: Observable<AuthResponse> | null = null;

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  // Skip token & refresh handling only for public auth endpoints; first-login-change & protected endpoints need the token
  const isPublicAuth = req.url.includes('/auth/login') || req.url.includes('/auth/register') || req.url.includes('/auth/refresh');
  if (isPublicAuth) {
    return next(req);
  }

  const token = authService.getToken();

  if (token) {
    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(cloned).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          const refreshToken = authService.getRefreshToken();
          if (refreshToken) {
            if (refresh$) {
              return refresh$.pipe(
                switchMap((response) => {
                  const retryReq = req.clone({
                    setHeaders: { Authorization: `Bearer ${response.accessToken}` }
                  });
                  return next(retryReq);
                })
              );
            }
            refresh$ = authService.refreshToken(refreshToken).pipe(
              tap((response) => authService.storeAuth(response)),
              catchError((refreshError) => {
                authService.logout();
                router.navigate(['/login']);
                return throwError(() => refreshError);
              }),
              finalize(() => { refresh$ = null; })
            );
            return refresh$.pipe(
              switchMap((response) => {
                const retryReq = req.clone({
                  setHeaders: { Authorization: `Bearer ${response.accessToken}` }
                });
                return next(retryReq);
              })
            );
          }
          authService.logout();
          router.navigate(['/login']);
        }
        return throwError(() => error);
      })
    );
  }

  return next(req);
};
