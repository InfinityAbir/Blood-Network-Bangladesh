import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

let isRefreshing = false;

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const token = authService.getToken();

  if (token) {
    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(cloned).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401 && !isRefreshing) {
          const refreshToken = authService.getRefreshToken();
          if (refreshToken) {
            isRefreshing = true;
            return authService.refreshToken(refreshToken).pipe(
              switchMap((response) => {
                isRefreshing = false;
                authService.storeAuth(response);
                const retryReq = req.clone({
                  setHeaders: { Authorization: `Bearer ${response.accessToken}` }
                });
                return next(retryReq);
              }),
              catchError((refreshError) => {
                isRefreshing = false;
                authService.logout();
                router.navigate(['/login']);
                return throwError(() => refreshError);
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
