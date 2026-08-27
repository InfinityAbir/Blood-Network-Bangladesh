import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, switchMap, tap, throwError, Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { AuthResponse } from '../models/user';

let refresh$: Observable<AuthResponse> | null = null;

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  // Never attach token or handle 401 refresh for auth endpoints
  if (req.url.includes('/auth/')) {
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
              tap(() => { refresh$ = null; }),
              catchError((refreshError) => {
                refresh$ = null;
                authService.logout();
                router.navigate(['/login']);
                return throwError(() => refreshError);
              })
            );
            return refresh$.pipe(
              switchMap((response) => {
                authService.storeAuth(response);
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
