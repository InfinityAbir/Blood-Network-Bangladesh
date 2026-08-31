import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { AuthService } from '../../../core/services/auth.service';
import { RevealDirective } from '../../../shared/directives/reveal.directive';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HeaderComponent,
    FooterComponent,
    RevealDirective
  ],
  template: `
    <app-header />
    <main class="auth-container">
      <mat-card class="auth-card" appReveal>
        <div class="auth-icon-badge bgn-float">
          <mat-icon>bloodtype</mat-icon>
        </div>
        <mat-card-header>
          <mat-card-title>Login</mat-card-title>
          <mat-card-subtitle>Welcome back to Blood Network Bangladesh</mat-card-subtitle>
        </mat-card-header>

        <mat-card-content>
          @if (errorMessage) {
            <div class="error-banner">{{ errorMessage }}</div>
          }

          <form [formGroup]="loginForm" (ngSubmit)="onSubmit()">
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Phone Number</mat-label>
              <input matInput formControlName="phoneNumber" placeholder="01712345678" maxlength="11" />
              <mat-icon matPrefix>phone</mat-icon>
              @if (loginForm.get('phoneNumber')?.hasError('required') && loginForm.get('phoneNumber')?.touched) {
                <mat-error>Phone number is required</mat-error>
              }
              @if (loginForm.get('phoneNumber')?.hasError('pattern') && loginForm.get('phoneNumber')?.touched) {
                <mat-error>Enter a valid Bangladeshi number (01XXXXXXXXX)</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Password</mat-label>
              <input matInput [type]="hidePassword ? 'password' : 'text'" formControlName="password" />
              <button mat-icon-button matSuffix (click)="hidePassword = !hidePassword" type="button">
                <mat-icon>{{ hidePassword ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (loginForm.get('password')?.hasError('required') && loginForm.get('password')?.touched) {
                <mat-error>Password is required</mat-error>
              }
            </mat-form-field>

            <button mat-raised-button color="primary" type="submit" class="full-width submit-btn bgn-press"
                    [disabled]="loginForm.invalid || isLoading">
              @if (isLoading) {
                <mat-spinner diameter="20"></mat-spinner>
              } @else {
                Login
              }
            </button>
          </form>
        </mat-card-content>

        <mat-card-actions align="end">
          <p class="auth-link">Don't have an account? <a routerLink="/register">Register here</a></p>
        </mat-card-actions>
      </mat-card>
    </main>
    <app-footer />
  `,
  styles: [`
    .auth-container {
      flex: 1;
      display: flex;
      justify-content: center;
      align-items: center;
      padding: 48px 16px;
      background: var(--bgn-bg);
    }
    .auth-card {
      position: relative;
      overflow: hidden;
      width: 100%;
      max-width: 420px;
      padding: 12px 18px;
      border-radius: var(--bgn-radius-lg) !important;
      border: 1px solid var(--bgn-border) !important;
      box-shadow: var(--bgn-shadow-lg) !important;
    }
    .auth-card::before {
      content: '';
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      height: 5px;
      background: var(--bgn-gradient);
      background-size: 200% 200%;
      animation: bgn-gradient-shift 8s ease infinite;
    }
    .auth-icon-badge {
      width: 56px;
      height: 56px;
      margin: 10px auto 0;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      background: var(--bgn-gradient);
      box-shadow: var(--bgn-shadow-md);
    }
    .auth-icon-badge mat-icon {
      color: #fff;
      font-size: 28px;
      width: 28px;
      height: 28px;
    }
    .full-width {
      width: 100%;
    }
    .submit-btn {
      margin-top: 16px;
      height: 48px;
      border-radius: var(--bgn-radius-pill) !important;
      transition: transform 0.2s ease-out, box-shadow 0.2s ease-out;
    }
    .submit-btn:hover:not(:disabled) {
      transform: translateY(-2px);
      box-shadow: var(--bgn-shadow-md);
    }
    .error-banner {
      background: color-mix(in srgb, var(--bgn-danger) 12%, transparent);
      color: var(--bgn-danger);
      padding: 12px 16px;
      border-radius: var(--bgn-radius-sm);
      margin-bottom: 16px;
      font-size: 14px;
      border: 1px solid color-mix(in srgb, var(--bgn-danger) 30%, transparent);
    }
    .auth-link {
      margin: 0;
      font-size: 14px;
      color: var(--bgn-text-muted);
    }
    .auth-link a {
      color: var(--bgn-primary);
      text-decoration: none;
      font-weight: 500;
    }
    .auth-link a:hover {
      text-decoration: underline;
    }
    mat-card-actions {
      padding: 16px !important;
    }
  `]
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading = false;
  hidePassword = true;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.loginForm = this.fb.group({
      phoneNumber: ['', [Validators.required, Validators.pattern(/^01[3-9]\d{8}$/)]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.loginForm.invalid) return;

    this.isLoading = true;
    this.errorMessage = '';

    const { phoneNumber, password } = this.loginForm.value;

    this.authService.login(phoneNumber, password).pipe(
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: (res) => {
        this.snackBar.open('Welcome back!', 'Close', { duration: 3000, horizontalPosition: 'end', verticalPosition: 'top' });
        if ((res.user as any)?.mustChangePassword) {
          this.router.navigate(['/admin/first-login-change']);
          return;
        }
        this.router.navigate([this.authService.getDashboardRoute()]);
      },
      error: (err) => {
        if (err.name === 'TimeoutError') {
          this.errorMessage = 'The server is waking up (this can take up to a minute on first use) — please try again.';
          return;
        }
        const msg = err.error?.message || err.error?.Message || 'Invalid phone number or password. Please try again.';
        this.errorMessage = msg;
      }
    });
  }
}
