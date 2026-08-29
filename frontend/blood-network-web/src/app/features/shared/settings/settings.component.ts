import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { AuthService } from '../../../core/services/auth.service';
import { AvatarComponent } from '../../../shared/components/avatar/avatar.component';

@Component({
  selector: 'app-user-settings',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterLink, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatProgressSpinnerModule, HeaderComponent, FooterComponent, AvatarComponent],
  template: `
    <app-header />
    <main class="settings-wrap">
      <div class="settings-container">
        <a mat-button [routerLink]="dashboardLink" class="back-link bgn-fade-up" style="--i:0"><mat-icon>arrow_back</mat-icon> Back to Dashboard</a>

        <mat-card class="settings-card bgn-fade-up" style="--i:1">
          <mat-card-header>
            <mat-card-title>Profile Photo</mat-card-title>
          </mat-card-header>
          <mat-card-content>
            @if (photoError) { <div class="banner error">{{ photoError }}</div> }
            <div class="photo-row">
              <app-avatar [photoUrl]="photoUrlInput || auth.currentUser()?.photoUrl" [size]="64" />
              <mat-form-field appearance="outline" class="full">
                <mat-label>Photo URL</mat-label>
                <input matInput [(ngModel)]="photoUrlInput" [ngModelOptions]="{standalone: true}" placeholder="https://..." />
              </mat-form-field>
            </div>
            <div class="form-actions">
              <button mat-raised-button color="primary" class="bgn-press" [disabled]="isSavingPhoto || photoUrlInput === (auth.currentUser()?.photoUrl || '')" (click)="savePhoto()">
                @if (isSavingPhoto) { <mat-spinner diameter="20"></mat-spinner> } @else { Save Photo }
              </button>
            </div>
          </mat-card-content>
        </mat-card>

        <mat-card class="settings-card bgn-fade-up" style="--i:2">
        <mat-card-header>
          <mat-card-title>Account Settings</mat-card-title>
          <mat-card-subtitle>Update your email, phone number or password. Current password is required for any change.</mat-card-subtitle>
        </mat-card-header>
        <mat-card-content>
          @if (errorMessage) { <div class="banner error bgn-fade-up">{{ errorMessage }}</div> }
          @if (successMessage) { <div class="banner success bgn-fade-up">{{ successMessage }}</div> }
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
              <mat-label>New Email (optional)</mat-label>
              <input matInput formControlName="newEmail" type="email" placeholder="you@example.com" />
              <mat-icon matPrefix>email</mat-icon>
              @if (form.get('newEmail')?.hasError('email') && form.get('newEmail')?.touched) { <mat-error>Invalid email</mat-error> }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full">
              <mat-label>New Phone (optional)</mat-label>
              <input matInput formControlName="newPhoneNumber" placeholder="01712345678" />
              <mat-icon matPrefix>phone</mat-icon>
              @if (form.get('newPhoneNumber')?.hasError('pattern') && form.get('newPhoneNumber')?.touched) { <mat-error>Invalid Bangladeshi format (01712345678)</mat-error> }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full">
              <mat-label>New Password (optional)</mat-label>
              <input matInput [type]="hideNew ? 'password' : 'text'" formControlName="newPassword" />
              <button mat-icon-button matSuffix type="button" (click)="hideNew = !hideNew">
                <mat-icon>{{ hideNew ? 'visibility_off' : 'visibility' }}</mat-icon>
              </button>
              @if (form.get('newPassword')?.hasError('minlength') && form.get('newPassword')?.touched) { <mat-error>Minimum 8 characters</mat-error> }
              @if (form.get('newPassword')?.hasError('pattern') && form.get('newPassword')?.touched) { <mat-error>Uppercase, lowercase and number required</mat-error> }
            </mat-form-field>

            @if (form.get('newPassword')?.value) {
              <mat-form-field appearance="outline" class="full">
                <mat-label>Confirm New Password</mat-label>
                <input matInput [type]="hideConfirm ? 'password' : 'text'" formControlName="confirmPassword" />
                <button mat-icon-button matSuffix type="button" (click)="hideConfirm = !hideConfirm">
                  <mat-icon>{{ hideConfirm ? 'visibility_off' : 'visibility' }}</mat-icon>
                </button>
                @if (form.get('confirmPassword')?.hasError('mismatch') && form.get('confirmPassword')?.touched) { <mat-error>Passwords do not match</mat-error> }
              </mat-form-field>
            }

            <div class="form-actions">
              <a mat-stroked-button [routerLink]="dashboardLink" class="cancel-btn bgn-press">Cancel</a>
              <button mat-raised-button color="primary" type="submit" class="submit bgn-press" [disabled]="form.invalid || isLoading || !hasAnyChange()">
                @if (isLoading) { <mat-spinner diameter="20"></mat-spinner> } @else { Save Changes }
              </button>
            </div>
          </form>
        </mat-card-content>
      </mat-card>
      </div>
    </main>
    <app-footer />
  `,
  styles: [`
    .settings-wrap { flex: 1; display:flex; justify-content:center; align-items:flex-start; padding:32px 16px; background: var(--bgn-bg); min-height: calc(100vh - 64px); }
    .settings-container { width:100%; max-width:520px; display:flex; flex-direction:column; gap:12px; }
    .back-link { align-self: flex-start; }
    .settings-card { width:100%; padding:16px 18px; border-radius: var(--bgn-radius-lg) !important; border:1px solid var(--bgn-border) !important; box-shadow: var(--bgn-shadow-lg) !important; }
    .full { width:100%; }
    .photo-row { display:flex; align-items:center; gap:16px; }
    .full mat-icon[matSuffix] { transition: color 0.2s ease, transform 0.2s ease; }
    .full button[matSuffix]:active mat-icon { transform: scale(0.88); }
    .form-actions { display:flex; gap:12px; margin-top:12px; }
    .form-actions .cancel-btn, .form-actions .submit { flex:1; height:48px; border-radius: var(--bgn-radius-pill) !important; }
    .banner { padding:12px 16px; border-radius: var(--bgn-radius-sm); margin-bottom:16px; font-size:14px; border:1px solid; }
    .banner.error { background: color-mix(in srgb, var(--bgn-danger) 12%, transparent); color: var(--bgn-danger); border-color: color-mix(in srgb, var(--bgn-danger) 30%, transparent); }
    .banner.success { background: color-mix(in srgb, var(--bgn-success) 14%, transparent); color: var(--bgn-success); border-color: color-mix(in srgb, var(--bgn-success) 30%, transparent); }
    @media (max-width: 600px) { .form-actions { flex-direction: column; gap: 8px; } .form-actions .cancel-btn, .form-actions .submit { width: 100%; max-width: none; height: 48px; border-radius: var(--bgn-radius-pill) !important; } }
  `]
})
export class UserSettingsComponent {
  form: FormGroup;
  isLoading = false;
  hideCurrent = true;
  hideNew = true;
  hideConfirm = true;
  errorMessage = '';
  successMessage = '';
  dashboardLink = '/donor/dashboard';

  photoUrlInput = '';
  isSavingPhoto = false;
  photoError = '';

  constructor(public auth: AuthService, private fb: FormBuilder, private router: Router) {
    this.photoUrlInput = this.auth.currentUser()?.photoUrl || '';
    const user = this.auth.currentUser();
    if (user?.role === 'Admin') this.dashboardLink = '/admin';
    else if (user?.role === 'Requester') this.dashboardLink = '/requester/dashboard';
    else this.dashboardLink = '/donor/dashboard';

    this.form = this.fb.group({
      currentPassword: ['', Validators.required],
      newEmail: ['', [Validators.email]],
      newPhoneNumber: ['', [Validators.pattern(/^01[3-9]\d{8}$/)]],
      newPassword: ['', [Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$/)]],
      confirmPassword: ['']
    });

    if (user?.email) this.form.patchValue({ newEmail: user.email });
    if (user?.phoneNumber) this.form.patchValue({ newPhoneNumber: user.phoneNumber });

    this.form.get('confirmPassword')?.valueChanges.subscribe(() => this.validateConfirm());
    this.form.get('newPassword')?.valueChanges.subscribe(() => {
      const cp = this.form.get('confirmPassword')?.value;
      if (cp) this.validateConfirm();
      if (this.form.get('newPassword')?.value) {
        this.form.get('confirmPassword')?.setValidators([Validators.required]);
      } else {
        this.form.get('confirmPassword')?.clearValidators();
        this.form.get('confirmPassword')?.setErrors(null);
      }
      this.form.get('confirmPassword')?.updateValueAndValidity({ emitEvent: false });
    });
  }

  hasAnyChange(): boolean {
    return !!(this.form.get('newEmail')?.value || this.form.get('newPhoneNumber')?.value || this.form.get('newPassword')?.value);
  }

  private validateConfirm(): void {
    const np = this.form.get('newPassword')?.value;
    const cp = this.form.get('confirmPassword')?.value;
    if (np && cp && np !== cp) this.form.get('confirmPassword')?.setErrors({ mismatch: true });
    else if (this.form.get('confirmPassword')?.hasError('mismatch')) {
      const e = this.form.get('confirmPassword')?.errors;
      if (e) { delete e['mismatch']; this.form.get('confirmPassword')?.setErrors(Object.keys(e).length ? e : null); }
    }
  }

  onSubmit(): void {
    if (this.form.invalid || !this.hasAnyChange()) return;
    const np = this.form.get('newPassword')?.value;
    const cp = this.form.get('confirmPassword')?.value;
    if (np && np !== cp) {
      this.errorMessage = 'Passwords do not match';
      return;
    }
    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';
    const { currentPassword, newEmail, newPhoneNumber, newPassword } = this.form.value;
    this.auth.updateProfile(currentPassword, newEmail || null, newPhoneNumber || null, newPassword || null).subscribe({
      next: () => {
        this.isLoading = false;
        this.successMessage = 'Profile updated successfully.';
        this.form.patchValue({ currentPassword: '', newPassword: '', confirmPassword: '' });
        this.form.get('currentPassword')?.markAsUntouched();
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || err.error?.Message || 'Update failed. Check current password and try again.';
      }
    });
  }

  savePhoto(): void {
    this.isSavingPhoto = true;
    this.photoError = '';
    this.auth.updatePhoto(this.photoUrlInput.trim()).subscribe({
      next: () => { this.isSavingPhoto = false; },
      error: (err) => {
        this.isSavingPhoto = false;
        this.photoError = err.error?.message || err.error?.Message || 'Failed to save photo.';
      }
    });
  }
}
