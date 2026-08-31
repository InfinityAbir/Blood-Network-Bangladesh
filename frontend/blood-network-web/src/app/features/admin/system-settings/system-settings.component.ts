import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { AdminService } from '../../../core/services/admin.service';
import { SystemSettings } from '../../../core/models/admin';

@Component({
  selector: 'app-system-settings',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="container">
      <a mat-button routerLink="/admin" class="back-link"><mat-icon>arrow_back</mat-icon> Back to Dashboard</a>
      <h1>System Settings</h1>
      <p class="subtitle">Tune donation rules and match scoring without redeploy. Changes apply immediately to new matches.</p>

      @if (isLoading) {
        <div class="sk-list">
          @for (i of [1,2,3]; track i) { <app-skeleton type="rect" width="100%" height="120px" /> }
        </div>
      } @else if (errorMessage && !form) {
        <div class="error-banner"><mat-icon>error</mat-icon><span>{{errorMessage}}</span><button mat-button (click)="load()">Retry</button></div>
      } @else if (form) {
        <form [formGroup]="form" (ngSubmit)="save()" class="form-grid">
          <mat-card class="section-card">
            <mat-card-header><mat-card-title>Business Rules</mat-card-title></mat-card-header>
            <mat-card-content class="grid">
              <mat-form-field appearance="outline">
                <mat-label>Minimum Donation Interval (days)</mat-label>
                <input matInput type="number" formControlName="minimumDonationIntervalDays">
                <mat-hint>Donors flagged RecentlyDonated within this window</mat-hint>
              </mat-form-field>
              <mat-form-field appearance="outline">
                <mat-label>Profile Confirmation Days</mat-label>
                <input matInput type="number" formControlName="donorProfileConfirmationDays">
                <mat-hint>After this, availability becomes Unknown</mat-hint>
              </mat-form-field>
              <mat-form-field appearance="outline">
                <mat-label>Max Active Requests Per User</mat-label>
                <input matInput type="number" formControlName="maxActiveRequestsPerUser">
              </mat-form-field>
              <mat-form-field appearance="outline">
                <mat-label>Contact Cooldown (hours)</mat-label>
                <input matInput type="number" formControlName="contactCooldownHours">
                <mat-hint>Throttle between request creations</mat-hint>
              </mat-form-field>
            </mat-card-content>
          </mat-card>

          <mat-card class="section-card">
            <mat-card-header><mat-card-title>Match Score Weights (0-100)</mat-card-title><mat-card-subtitle>Higher = more influence. Total is sum of applicable bonuses.</mat-card-subtitle></mat-card-header>
            <mat-card-content class="grid">
              <mat-form-field appearance="outline"><mat-label>Exact Blood Group</mat-label><input matInput type="number" formControlName="exactBloodGroupWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Compatible Blood Group</mat-label><input matInput type="number" formControlName="compatibleBloodGroupWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Available</mat-label><input matInput type="number" formControlName="availableWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Unknown</mat-label><input matInput type="number" formControlName="unknownWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Verified</mat-label><input matInput type="number" formControlName="verifiedWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Unverified</mat-label><input matInput type="number" formControlName="unverifiedWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Profile Freshness</mat-label><input matInput type="number" formControlName="profileFreshnessWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Distance 0-3km</mat-label><input matInput type="number" formControlName="distance0to3kmWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Distance 3-10km</mat-label><input matInput type="number" formControlName="distance3to10kmWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Distance 10-25km</mat-label><input matInput type="number" formControlName="distance10to25kmWeight"></mat-form-field>
              <mat-form-field appearance="outline"><mat-label>Distance >25km</mat-label><input matInput type="number" formControlName="distanceOver25kmWeight"></mat-form-field>
            </mat-card-content>
          </mat-card>

          @if (saveError) { <div class="error-banner">{{saveError}}</div> }
          @if (saveSuccess) { <div class="success-banner">Settings saved. New requests will use updated weights.</div> }

          <div class="actions">
            <button mat-raised-button color="primary" type="submit" [disabled]="form.invalid || isSaving">
              @if (isSaving) { <mat-spinner diameter="18"></mat-spinner> } @else { Save Settings }
            </button>
            <button mat-stroked-button type="button" (click)="load()" [disabled]="isSaving">Reset</button>
          </div>
          <p class="hint">Last updated: {{settings?.updatedAt | date:'medium'}}</p>
        </form>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex:1; padding:24px; max-width:900px; margin:0 auto; width:100%; }
    .back-link { margin-bottom:12px; }
    .subtitle { color:#666; margin:-8px 0 16px; font-size:14px; }
    .section-card { margin-bottom:16px; }
    .grid { display:grid; grid-template-columns:1fr 1fr; gap:16px; padding-top:12px; }
    .form-grid { display:flex; flex-direction:column; }
    .actions { display:flex; gap:12px; margin-top:8px; }
    .error-banner { background:#ffebee; color:#c62828; padding:12px; border-radius:8px; display:flex; align-items:center; gap:8px; margin-bottom:12px; }
    .success-banner { background:#e8f5e9; color:#2e7d32; padding:12px; border-radius:8px; margin-bottom:12px; }
    .hint { font-size:12px; color:#999; margin-top:8px; }
    @media (max-width:700px){ .grid{ grid-template-columns:1fr; } }
  `]
})
export class SystemSettingsComponent implements OnInit {
  form: FormGroup | null = null;
  settings: SystemSettings | null = null;
  isLoading = true;
  isSaving = false;
  errorMessage = '';
  saveError = '';
  saveSuccess = false;

  constructor(private fb: FormBuilder, private adminService: AdminService, private cdr: ChangeDetectorRef, private snack: MatSnackBar) {}

  ngOnInit(): void { this.load(); }

  load(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.adminService.getSystemSettings().pipe(finalize(()=>{ this.isLoading=false; this.cdr.detectChanges(); })).subscribe({
      next: s => {
        this.settings = s;
        this.form = this.fb.group({
          minimumDonationIntervalDays: [s.minimumDonationIntervalDays, [Validators.required, Validators.min(0), Validators.max(365)]],
          donorProfileConfirmationDays: [s.donorProfileConfirmationDays, [Validators.required, Validators.min(0), Validators.max(365)]],
          maxActiveRequestsPerUser: [s.maxActiveRequestsPerUser, [Validators.required, Validators.min(1), Validators.max(100)]],
          contactCooldownHours: [s.contactCooldownHours, [Validators.required, Validators.min(0), Validators.max(720)]],
          exactBloodGroupWeight: [s.exactBloodGroupWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          compatibleBloodGroupWeight: [s.compatibleBloodGroupWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          availableWeight: [s.availableWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          unknownWeight: [s.unknownWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          verifiedWeight: [s.verifiedWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          unverifiedWeight: [s.unverifiedWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          profileFreshnessWeight: [s.profileFreshnessWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          distance0to3kmWeight: [s.distance0to3kmWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          distance3to10kmWeight: [s.distance3to10kmWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          distance10to25kmWeight: [s.distance10to25kmWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
          distanceOver25kmWeight: [s.distanceOver25kmWeight, [Validators.required, Validators.min(0), Validators.max(100)]],
        });
      },
      error: e => this.errorMessage = e.error?.message || e.message || 'Failed to load settings'
    });
  }

  save(): void {
    if (!this.form || this.form.invalid) return;
    this.isSaving = true;
    this.saveError = '';
    this.saveSuccess = false;
    const payload = { ...this.settings, ...this.form.value } as SystemSettings;
    this.adminService.updateSystemSettings(payload).pipe(finalize(()=>{ this.isSaving=false; this.cdr.detectChanges(); })).subscribe({
      next: s => {
        this.settings = s;
        this.saveSuccess = true;
        this.snack.open('System settings saved', 'Close', { duration: 2500 });
      },
      error: e => this.saveError = e.error?.message || e.message || 'Save failed'
    });
  }
}
