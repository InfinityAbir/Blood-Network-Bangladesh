import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-admin-first-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatProgressSpinnerModule],
  template: `
    <main class="first-login-wrap">
      <mat-card class="first-login-card">
        <mat-card-header>
          <mat-card-title>Change Admin Credentials</mat-card-title>
          <mat-card-subtitle>For security, you must change the default email and password on first login.</mat-card-subtitle>
        </mat-card-header>
        <mat-card-content>
          @if (errorMessage) { <div class="banner error">{{ errorMessage }}</div> }
          @if (successMessage) { <div class="banner success">{{ successMessage }}</div> }
          <form [formGroup]="form" (ngSubmit)="onSubmit()">
            <mat-form-field appearance="outline" class="full">
              <mat-label>Current Password</mat-label>
              <input matInput [type]="hideCurrent ? 'password' : 'text'" formControlName="currentPassword" />
              <button mat-icon-button matSuffix type="button" (click)="hideCurrent = !hideCurrent">
                <mat-icon>{{ hideCurrent ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (form.get('currentPassword')?.hasError('required') && form.get('currentPassword')?.touched) { <mat-error>Required</mat-error> }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full">
              <mat-label>New Email</mat-label>
              <input matInput formControlName="newEmail" type="email" placeholder="admin@yourdomain.com" />
              <mat-icon matPrefix>email</mat-icon>
              @if (form.get('newEmail')?.hasError('required') && form.get('newEmail')?.touched) { <mat-error>Required</mat-error> }
              @if (form.get('newEmail')?.hasError('email') && form.get('newEmail')?.touched) { <mat-error>Invalid email</mat-error> }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full">
              <mat-label>New Password</mat-label>
              <input matInput [type]="hideNew ? 'password' : 'text'" formControlName="newPassword" />
              <button mat-icon-button matSuffix type="button" (click)="hideNew = !hideNew">
                <mat-icon>{{ hideNew ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (form.get('newPassword')?.hasError('required') && form.get('newPassword')?.touched) { <mat-error>Required</mat-error> }
              @if (form.get('newPassword')?.hasError('minlength') && form.get('newPassword')?.touched) { <mat-error>Minimum 8 characters</mat-error> }
              @if (form.get('newPassword')?.hasError('pattern') && form.get('newPassword')?.touched) { <mat-error>Uppercase, lowercase and number required</mat-error> }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full">
              <mat-label>Confirm New Password</mat-label>
              <input matInput [type]="hideConfirm ? 'password' : 'text'" formControlName="confirmPassword" />
              <button mat-icon-button matSuffix type="button" (click)="hideConfirm = !hideConfirm">
                <mat-icon>{{ hideConfirm ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (form.get('confirmPassword')?.hasError('required') && form.get('confirmPassword')?.touched) { <mat-error>Required</mat-error> }
              @if (form.get('confirmPassword')?.hasError('mismatch') && form.get('confirmPassword')?.touched) { <mat-error>Passwords do not match</mat-error> }
            </mat-form-field>

            <button mat-raised-button color="primary" type="submit" class="full submit" [disabled]="form.invalid || isLoading">
              @if (isLoading) { <mat-spinner diameter="20"></mat-spinner> } @else { Update and Continue }
            </button>
          </form>
        </mat-card-content>
      </mat-card>
    </main>
  `,
  styles: [`
    .first-login-wrap { flex: 1; display:flex; justify-content:center; align-items:center; padding:48px 16px; background: var(--bgn-bg); min-height: calc(100vh - 64px); }
    .first-login-card { width:100%; max-width:500px; padding:16px 18px; border-radius: var(--bgn-radius-lg) !important; border:1px solid var(--bgn-border) !important; box-shadow: var(--bgn-shadow-lg) !important; }
    .full { width:100%; }
    .submit { height:48px; border-radius: var(--bgn-radius-pill) !important; margin-top:12px; }
    .banner { padding:12px 16px; border-radius: var(--bgn-radius-sm); margin-bottom:16px; font-size:14px; border:1px solid; }
    .banner.error { background: color-mix(in srgb, var(--bgn-danger) 12%, transparent); color: var(--bgn-danger); border-color: color-mix(in srgb, var(--bgn-danger) 30%, transparent); }
    .banner.success { background: color-mix(in srgb, var(--bgn-success) 14%, transparent); color: var(--bgn-success); border-color: color-mix(in srgb, var(--bgn-success) 30%, transparent); }
  `]
})
export class AdminFirstLoginComponent {
  form: FormGroup;
  isLoading = false;
  hideCurrent = true;
  hideNew = true;
  hideConfirm = true;
  errorMessage = '';
  successMessage = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.form = this.fb.group({
      currentPassword: ['', Validators.required],
      newEmail: ['', [Validators.required, Validators.email]],
      newPassword: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$/)]],
      confirmPassword: ['', Validators.required]
    });
    const user = this.auth.currentUser();
    if (user?.email) this.form.patchValue({ newEmail: user.email });

    this.form.get('confirmPassword')?.valueChanges.subscribe(() => {
      const np = this.form.get('newPassword')?.value;
      const cp = this.form.get('confirmPassword')?.value;
      if (np && cp && np !== cp) this.form.get('confirmPassword')?.setErrors({ mismatch: true });
      else if (this.form.get('confirmPassword')?.hasError('mismatch')) {
        const e = this.form.get('confirmPassword')?.errors;
        if (e) { delete e['mismatch']; this.form.get('confirmPassword')?.setErrors(Object.keys(e).length ? e : null); }
      }
    });
    this.form.get('newPassword')?.valueChanges.subscribe(() => {
      const cp = this.form.get('confirmPassword')?.value;
      if (cp) this.form.get('confirmPassword')?.updateValueAndValidity({ emitEvent: false });
    });
  }

  onSubmit(): void {
    if (this.form.invalid) return;
    if (this.form.value.newPassword !== this.form.value.confirmPassword) {
      this.errorMessage = 'Passwords do not match';
      return;
    }
    this.isLoading = true;
    this.errorMessage = '';
    const { currentPassword, newEmail, newPassword } = this.form.value;
    this.auth.changeFirstLoginCredentials(currentPassword, newEmail, newPassword).subscribe({
      next: () => {
        this.isLoading = false;
        this.successMessage = 'Credentials updated. Redirecting...';
        setTimeout(() => {
          this.isLoading = false;
          this.router.navigate(['/admin']);
        }, 1200);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || err.error?.Message || 'Update failed. Check current password and try again.';
      }
    });
  }
}
