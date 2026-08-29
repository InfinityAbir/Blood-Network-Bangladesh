import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { AvatarComponent } from '../../../shared/components/avatar/avatar.component';
import { RevealDirective } from '../../../shared/directives/reveal.directive';
import { AuthService } from '../../../core/services/auth.service';
import { DeveloperInfoService } from '../../../core/services/developer-info.service';
import { DeveloperInfo } from '../../../core/models/developer-info';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule, MatCardModule, MatButtonModule, MatIconModule,
    MatFormFieldModule, MatInputModule, MatProgressSpinnerModule,
    HeaderComponent, FooterComponent, AvatarComponent, RevealDirective,
  ],
  template: `
    <app-header />
    <main class="about-wrap">
      <div class="about-container">
        @if (isLoading) {
          <div class="loading-row"><mat-spinner diameter="32"></mat-spinner></div>
        } @else if (loadError) {
          <mat-card class="about-card" appReveal>
            <mat-card-content>
              <div class="banner error">{{ loadError }}</div>
              <button mat-stroked-button (click)="load()" class="bgn-press">Retry</button>
            </mat-card-content>
          </mat-card>
        } @else if (info) {
          <mat-card class="about-card profile-card" appReveal>
            <mat-card-content>
              @if (isAdmin && !isEditing) {
                <button mat-icon-button class="edit-btn" (click)="startEdit()" aria-label="Edit developer info">
                  <mat-icon>edit</mat-icon>
                </button>
              }

              @if (!isEditing) {
                <div class="profile-header">
                  <app-avatar [photoUrl]="info.photoUrl" [size]="88" />
                  <h1>{{ info.name }}</h1>
                  <div class="role">{{ info.role }}</div>
                </div>
              } @else {
                <h2 class="edit-title">Edit developer info</h2>
                @if (saveError) { <div class="banner error">{{ saveError }}</div> }
                <form [formGroup]="form" (ngSubmit)="save()" class="edit-form">
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>Name</mat-label>
                    <input matInput formControlName="name" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>Role</mat-label>
                    <input matInput formControlName="role" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>Email</mat-label>
                    <input matInput formControlName="email" type="email" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>Phone</mat-label>
                    <input matInput formControlName="phone" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>LinkedIn URL</mat-label>
                    <input matInput formControlName="linkedInUrl" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>GitHub URL</mat-label>
                    <input matInput formControlName="githubUrl" />
                  </mat-form-field>
                  <mat-form-field appearance="outline" class="full">
                    <mat-label>Photo URL</mat-label>
                    <input matInput formControlName="photoUrl" />
                  </mat-form-field>
                  <div class="form-actions">
                    <button mat-stroked-button type="button" class="bgn-press" (click)="cancelEdit()">Cancel</button>
                    <button mat-raised-button color="primary" type="submit" class="bgn-press" [disabled]="form.invalid || isSaving">
                      @if (isSaving) { <mat-spinner diameter="20"></mat-spinner> } @else { Save }
                    </button>
                  </div>
                </form>
              }
            </mat-card-content>
          </mat-card>

          @if (!isEditing) {
            <mat-card class="about-card contact-card bgn-fade-up" style="--i:1">
              <mat-card-content>
                @if (info.email) {
                  <a class="contact-row" [href]="'mailto:' + info.email">
                    <mat-icon>email</mat-icon>
                    <div><div class="label">Email</div><div class="value">{{ info.email }}</div></div>
                  </a>
                }
                @if (info.phone) {
                  <a class="contact-row" [href]="'tel:' + info.phone">
                    <mat-icon>phone</mat-icon>
                    <div><div class="label">Phone</div><div class="value">{{ info.phone }}</div></div>
                  </a>
                }
                @if (info.linkedInUrl) {
                  <a class="contact-row" [href]="info.linkedInUrl" target="_blank" rel="noopener">
                    <mat-icon>link</mat-icon>
                    <div><div class="label">LinkedIn</div><div class="value">{{ info.linkedInUrl }}</div></div>
                  </a>
                }
                @if (info.githubUrl) {
                  <a class="contact-row" [href]="info.githubUrl" target="_blank" rel="noopener">
                    <mat-icon>code</mat-icon>
                    <div><div class="label">GitHub</div><div class="value">{{ info.githubUrl }}</div></div>
                  </a>
                }
              </mat-card-content>
            </mat-card>

            <p class="tagline bgn-fade-up" style="--i:2">
              Blood Network Bangladesh helps donors and requesters find each other faster —
              built to make donating blood as simple as it should be.
            </p>
          }
        }
      </div>
    </main>
    <app-footer />
  `,
  styles: [`
    .about-wrap { flex: 1; display:flex; justify-content:center; align-items:flex-start; padding:32px 16px; background: var(--bgn-bg); min-height: calc(100vh - 64px); }
    .about-container { width:100%; max-width:520px; display:flex; flex-direction:column; gap:16px; }
    .loading-row { display:flex; justify-content:center; padding:48px 0; }
    .about-card { border-radius: var(--bgn-radius-lg) !important; border:1px solid var(--bgn-border) !important; box-shadow: var(--bgn-shadow-lg) !important; }
    .profile-card { position: relative; }
    .edit-btn { position: absolute; top: 12px; right: 12px; }
    .profile-header { display:flex; flex-direction:column; align-items:center; gap:8px; padding: 12px 0 4px; text-align:center; }
    .profile-header h1 { margin: 4px 0 0; font-size: 1.4rem; font-weight: 700; }
    .profile-header .role { color: var(--bgn-text-muted); font-size: 0.95rem; }
    .edit-title { margin: 4px 0 12px; font-size: 1.1rem; font-weight: 600; }
    .edit-form { display:flex; flex-direction:column; gap: 4px; }
    .full { width:100%; }
    .form-actions { display:flex; justify-content:flex-end; gap:12px; margin-top:8px; }
    .form-actions button { border-radius: var(--bgn-radius-pill) !important; min-width: 96px; }
    .contact-card mat-card-content { display:flex; flex-direction:column; padding: 4px !important; }
    .contact-row {
      display:flex; align-items:center; gap:14px; padding:14px 12px; border-radius: var(--bgn-radius-md);
      text-decoration:none; color: var(--bgn-text); transition: background 0.15s ease;
    }
    .contact-row:hover { background: var(--bgn-surface-2); }
    .contact-row mat-icon { color: var(--bgn-primary); flex: none; }
    .contact-row .label { font-size: 0.75rem; color: var(--bgn-text-faint); }
    .contact-row .value { font-size: 0.95rem; word-break: break-all; }
    .tagline { color: var(--bgn-text-muted); font-size: 0.88rem; text-align:center; padding: 0 8px; }
    .banner { padding:12px 16px; border-radius: var(--bgn-radius-sm); margin-bottom:16px; font-size:14px; border:1px solid; }
    .banner.error { background: color-mix(in srgb, var(--bgn-danger) 12%, transparent); color: var(--bgn-danger); border-color: color-mix(in srgb, var(--bgn-danger) 30%, transparent); }
  `]
})
export class AboutComponent implements OnInit {
  private developerInfoService = inject(DeveloperInfoService);
  private auth = inject(AuthService);
  private fb = inject(FormBuilder);

  info: DeveloperInfo | null = null;
  isLoading = true;
  loadError = '';
  isEditing = false;
  isSaving = false;
  saveError = '';

  form: FormGroup = this.fb.group({
    name: ['', Validators.required],
    role: ['', Validators.required],
    email: [''],
    phone: [''],
    linkedInUrl: [''],
    githubUrl: [''],
    photoUrl: [''],
  });

  get isAdmin(): boolean {
    return this.auth.isAdmin();
  }

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.isLoading = true;
    this.loadError = '';
    this.developerInfoService.get().subscribe({
      next: (info) => {
        this.info = info;
        this.isLoading = false;
      },
      error: () => {
        this.loadError = 'Could not load this page. Please try again.';
        this.isLoading = false;
      }
    });
  }

  startEdit(): void {
    if (!this.info) return;
    this.form.patchValue(this.info);
    this.saveError = '';
    this.isEditing = true;
  }

  cancelEdit(): void {
    this.isEditing = false;
  }

  save(): void {
    if (this.form.invalid) return;
    this.isSaving = true;
    this.saveError = '';
    this.developerInfoService.update(this.form.value).subscribe({
      next: (updated) => {
        this.info = updated;
        this.isSaving = false;
        this.isEditing = false;
      },
      error: (err) => {
        this.isSaving = false;
        this.saveError = err.error?.message || err.error?.Message || 'Failed to save changes.';
      }
    });
  }
}
