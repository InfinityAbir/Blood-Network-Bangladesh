import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { AuthService } from '../../../core/services/auth.service';
import { RevealDirective } from '../../../shared/directives/reveal.directive';

@Component({
  selector: 'app-register',
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
    MatSelectModule,
    MatRadioModule,
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
          <mat-card-title>Register</mat-card-title>
          <mat-card-subtitle>Join Blood Network Bangladesh</mat-card-subtitle>
        </mat-card-header>

        <mat-card-content>
          @if (errorMessage) {
            <div class="error-banner">{{ errorMessage }}</div>
          }

          @if (successMessage) {
            <div class="success-banner">{{ successMessage }}</div>
          }

          <form [formGroup]="registerForm" (ngSubmit)="onSubmit()">
            <div class="name-row">
              <mat-form-field appearance="outline">
                <mat-label>First Name</mat-label>
                <input matInput formControlName="firstName" maxlength="50" />
                @if (registerForm.get('firstName')?.hasError('required') && registerForm.get('firstName')?.touched) {
                  <mat-error>Required</mat-error>
                }
              </mat-form-field>

              <mat-form-field appearance="outline">
                <mat-label>Last Name</mat-label>
                <input matInput formControlName="lastName" maxlength="50" />
                @if (registerForm.get('lastName')?.hasError('required') && registerForm.get('lastName')?.touched) {
                  <mat-error>Required</mat-error>
                }
              </mat-form-field>
            </div>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Phone Number</mat-label>
              <input matInput formControlName="phoneNumber" placeholder="01712345678" maxlength="11" />
              <mat-icon matPrefix>phone</mat-icon>
              @if (registerForm.get('phoneNumber')?.hasError('required') && registerForm.get('phoneNumber')?.touched) {
                <mat-error>Phone number is required</mat-error>
              }
              @if (registerForm.get('phoneNumber')?.hasError('pattern') && registerForm.get('phoneNumber')?.touched) {
                <mat-error>Enter a valid Bangladeshi number (01XXXXXXXXX)</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Email (optional)</mat-label>
              <input matInput formControlName="email" type="email" />
              <mat-icon matPrefix>email</mat-icon>
              @if (registerForm.get('email')?.hasError('email') && registerForm.get('email')?.touched) {
                <mat-error>Enter a valid email address</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Password</mat-label>
              <input matInput [type]="hidePassword ? 'password' : 'text'" formControlName="password" />
              <button mat-icon-button matSuffix (click)="hidePassword = !hidePassword" type="button">
                <mat-icon>{{ hidePassword ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (registerForm.get('password')?.hasError('required') && registerForm.get('password')?.touched) {
                <mat-error>Password is required</mat-error>
              }
              @if (registerForm.get('password')?.hasError('minlength') && registerForm.get('password')?.touched) {
                <mat-error>Minimum 8 characters</mat-error>
              }
              @if (registerForm.get('password')?.hasError('pattern') && registerForm.get('password')?.touched) {
                <mat-error>Must include uppercase, lowercase, and a number</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Confirm Password</mat-label>
              <input matInput [type]="hideConfirmPassword ? 'password' : 'text'" formControlName="confirmPassword" />
              <button mat-icon-button matSuffix (click)="hideConfirmPassword = !hideConfirmPassword" type="button">
                <mat-icon>{{ hideConfirmPassword ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (registerForm.get('confirmPassword')?.hasError('required') && registerForm.get('confirmPassword')?.touched) {
                <mat-error>Please confirm your password</mat-error>
              }
              @if (registerForm.get('confirmPassword')?.hasError('passwordMismatch') && registerForm.get('confirmPassword')?.touched) {
                <mat-error>Passwords do not match</mat-error>
              }
            </mat-form-field>

            <div class="role-section">
              <label class="role-label">I want to:</label>
              <mat-radio-group formControlName="role" class="role-radio-group">
                <mat-radio-button value="Requester">Request Blood</mat-radio-button>
                <mat-radio-button value="Donor">Donate Blood</mat-radio-button>
              </mat-radio-group>
            </div>

            <button mat-raised-button color="primary" type="submit" class="full-width submit-btn bgn-press"
                    [disabled]="registerForm.invalid || isLoading">
              @if (isLoading) {
                <mat-spinner diameter="20"></mat-spinner>
              } @else {
                Create Account
              }
            </button>
          </form>
        </mat-card-content>

        <mat-card-actions align="end">
          <p class="auth-link">Already have an account? <a routerLink="/login">Login here</a></p>
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
      max-width: 500px;
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
    .name-row {
      display: flex;
      gap: 16px;
    }
    .name-row mat-form-field {
      flex: 1;
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
    .success-banner {
      background: color-mix(in srgb, var(--bgn-success) 14%, transparent);
      color: var(--bgn-success);
      padding: 12px 16px;
      border-radius: var(--bgn-radius-sm);
      margin-bottom: 16px;
      font-size: 14px;
      border: 1px solid color-mix(in srgb, var(--bgn-success) 30%, transparent);
    }
    .role-section {
      margin: 16px 0;
    }
    .role-label {
      display: block;
      margin-bottom: 8px;
      font-size: 14px;
      color: var(--bgn-text-muted);
    }
    .role-radio-group {
      display: flex;
      gap: 24px;
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
    @media (max-width: 480px) {
      .name-row {
        flex-direction: column;
        gap: 0;
      }
    }
  `]
})
export class RegisterComponent {
  registerForm: FormGroup;
  isLoading = false;
  hidePassword = true;
  hideConfirmPassword = true;
  errorMessage = '';
  successMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^01[3-9]\d{8}$/)]],
      email: ['', Validators.email],
      password: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$/)
      ]],
      confirmPassword: ['', Validators.required],
      role: ['Requester', Validators.required]
    }, { validators: this.passwordMatchValidator });
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');
    if (password && confirmPassword && password.value !== confirmPassword.value) {
      confirmPassword.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true };
    }
    return null;
  }

  onSubmit(): void {
    if (this.registerForm.invalid) return;

    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    const { confirmPassword, ...registerData } = this.registerForm.value;

    this.authService.register(registerData).pipe(
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: () => {
        this.snackBar.open('Account created successfully!', 'Close', { duration: 3000, horizontalPosition: 'end', verticalPosition: 'top' });
        this.successMessage = 'Account created successfully! Redirecting...';
        setTimeout(() => this.router.navigate([this.authService.getDashboardRoute()]), 1500);
      },
      error: (err) => {
        if (err.name === 'TimeoutError') {
          this.errorMessage = 'The server is waking up (this can take up to a minute on first use) — please try again.';
          return;
        }
        this.errorMessage = err.error?.message || 'Registration failed. Please try again.';
      }
    });
  }
}
