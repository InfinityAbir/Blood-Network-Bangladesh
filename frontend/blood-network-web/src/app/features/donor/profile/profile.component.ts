import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { DonorService } from '../../../core/services/donor.service';
import { DonorProfile } from '../../../core/models/donor';
import { LocationService, Division, District, Upazila } from '../../../core/services/location.service';
import { BloodGroup, BloodGroupLabels } from '../../../core/models/blood-group';

@Component({
  selector: 'app-donor-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="profile-container">
      <mat-card class="profile-card">
        <mat-card-header>
          <mat-card-title>{{ isEditing ? 'Edit Donor Profile' : 'Donor Profile Setup' }}</mat-card-title>
          <mat-card-subtitle>{{ isEditing ? 'Update your details to keep receiving match requests' : 'Complete your profile to start receiving match requests' }}</mat-card-subtitle>
        </mat-card-header>

        <mat-card-content>
          @if (errorMessage) {
            <div class="error-banner">{{ errorMessage }}</div>
          }

          <form [formGroup]="profileForm" (ngSubmit)="onSubmit()">
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Blood Group</mat-label>
              <mat-select formControlName="bloodGroup">
                @for (group of bloodGroups; track group.value) {
                  <mat-option [value]="group.value">{{ group.label }}</mat-option>
                }
              </mat-select>
              @if (profileForm.get('bloodGroup')?.hasError('required') && profileForm.get('bloodGroup')?.touched) {
                <mat-error>Blood group is required</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Gender</mat-label>
              <mat-select formControlName="gender">
                <mat-option value="Male">Male</mat-option>
                <mat-option value="Female">Female</mat-option>
                <mat-option value="Other">Other</mat-option>
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Date of Birth</mat-label>
              <input matInput [matDatepicker]="picker" formControlName="dateOfBirth" />
              <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
              <mat-datepicker #picker></mat-datepicker>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Division</mat-label>
              <mat-select formControlName="divisionId" (selectionChange)="onDivisionChange()">
                @for (division of divisions; track division.id) {
                  <mat-option [value]="division.id">{{ division.name }}</mat-option>
                }
              </mat-select>
              @if (profileForm.get('divisionId')?.hasError('required') && profileForm.get('divisionId')?.touched) {
                <mat-error>Division is required</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>District</mat-label>
              <mat-select formControlName="districtId" (selectionChange)="onDistrictChange()" [disabled]="!profileForm.get('divisionId')?.value">
                @for (district of districts; track district.id) {
                  <mat-option [value]="district.id">{{ district.name }}</mat-option>
                }
              </mat-select>
              @if (profileForm.get('districtId')?.hasError('required') && profileForm.get('districtId')?.touched) {
                <mat-error>District is required</mat-error>
              }
              @if (!profileForm.get('divisionId')?.value) {
                <mat-hint>Select Division first</mat-hint>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Upazila / Thana</mat-label>
              <mat-select formControlName="upazilaId" [disabled]="!profileForm.get('districtId')?.value">
                @for (upazila of upazilas; track upazila.id) {
                  <mat-option [value]="upazila.id">{{ upazila.name }}</mat-option>
                }
              </mat-select>
              @if (profileForm.get('upazilaId')?.hasError('required') && profileForm.get('upazilaId')?.touched) {
                <mat-error>Upazila/Thana is required</mat-error>
              }
              @if (!profileForm.get('districtId')?.value) {
                <mat-hint>Select District first</mat-hint>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Area / Landmark (optional)</mat-label>
              <input matInput formControlName="area" placeholder="e.g., Near Dhaka Medical College" />
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Last Donation Date (optional)</mat-label>
              <input matInput [matDatepicker]="lastDonationPicker" formControlName="lastDonationDate" />
              <mat-datepicker-toggle matSuffix [for]="lastDonationPicker"></mat-datepicker-toggle>
              <mat-datepicker #lastDonationPicker></mat-datepicker>
              <mat-hint>Leave empty if you have not donated yet</mat-hint>
            </mat-form-field>

            <div class="form-actions">
              <a mat-stroked-button routerLink="/donor/dashboard" class="action-btn">Cancel</a>
              <button mat-raised-button color="primary" type="submit" class="action-btn submit-btn"
                      [disabled]="isLoading">
                @if (isLoading) {
                  <mat-spinner diameter="20"></mat-spinner>
                } @else {
                  Save Profile
                }
              </button>
            </div>
          </form>
        </mat-card-content>
      </mat-card>
    </main>
    <app-footer />
  `,
  styles: [`
    .profile-container {
      flex: 1;
      display: flex;
      justify-content: center;
      padding: 40px 16px;
      background: #f5f5f5;
    }
    .profile-card {
      width: 100%;
      max-width: 600px;
    }
    .full-width { width: 100%; }
    .form-actions { display: flex; gap: 12px; margin-top: 16px; }
    .action-btn { flex: 1; height: 48px; }
    .error-banner {
      background: color-mix(in srgb, var(--bgn-danger) 12%, transparent); color: var(--bgn-danger);
      padding: 12px 16px; border-radius: var(--bgn-radius-md); border: 1px solid color-mix(in srgb, var(--bgn-danger) 30%, transparent);
      margin-bottom: 16px; font-size: 14px;
    }
    @media (max-width: 600px) {
      .profile-container { padding: 24px 16px; }
      .form-actions { flex-direction: column; gap: 8px; }
      .action-btn { width: 100%; max-width: none; height: 48px; border-radius: var(--bgn-radius-pill) !important; }
    }
  `]
})
export class DonorProfileComponent implements OnInit {
  profileForm: FormGroup;
  isLoading = false;
  hidePassword = true;
  errorMessage = '';
  isEditing = false;

  divisions: Division[] = [];
  districts: District[] = [];
  upazilas: Upazila[] = [];

  bloodGroups = Object.entries(BloodGroupLabels).map(([value, label]) => ({ value, label }));

  constructor(
    private fb: FormBuilder,
    private donorService: DonorService,
    private locationService: LocationService,
    private router: Router,
    private snackBar: MatSnackBar,
    private cdr: ChangeDetectorRef
  ) {
    this.profileForm = this.fb.group({
      bloodGroup: ['', Validators.required],
      gender: [''],
      dateOfBirth: [null],
      divisionId: ['', Validators.required],
      districtId: ['', Validators.required],
      upazilaId: ['', Validators.required],
      area: [''],
      lastDonationDate: [null]
    });
  }

  ngOnInit(): void {
    this.locationService.getDivisions().subscribe({
      next: divs => this.divisions = divs,
      error: (e) => console.debug(e)
    });

    this.donorService.getMyProfile().subscribe({
      next: (profile) => {
        this.isEditing = true;
        this.prefillProfile(profile);
      },
      error: () => {
        this.isEditing = false;
      }
    });
  }

  private prefillProfile(profile: DonorProfile): void {
    this.profileForm.patchValue({
      bloodGroup: profile.bloodGroup,
      gender: profile.gender || '',
      dateOfBirth: profile.dateOfBirth ? new Date(profile.dateOfBirth) : null,
      area: profile.area || '',
      lastDonationDate: profile.lastDonationDate ? new Date(profile.lastDonationDate) : null
    });

    this.locationService.getDistricts().subscribe({
      next: (allDistricts) => {
        const district = allDistricts.find(d => d.id === profile.districtId);
        const divisionId = district?.divisionId || '';
        this.profileForm.patchValue({ divisionId, districtId: profile.districtId });

        this.locationService.getDistricts(divisionId).subscribe({
          next: d => this.districts = d,
          error: (e) => console.debug(e)
        });

        this.locationService.getUpazilas(profile.districtId).subscribe({
          next: u => this.upazilas = u,
          error: (e) => console.debug(e)
        });

        this.profileForm.patchValue({ upazilaId: profile.upazilaId });
        this.cdr.detectChanges();
      },
      error: (e) => console.debug(e)
    });
  }

  onDivisionChange(): void {
    const divisionId = this.profileForm.get('divisionId')?.value;
    this.profileForm.patchValue({ districtId: '', upazilaId: '' });
    this.upazilas = [];
    if (divisionId) {
      this.locationService.getDistricts(divisionId).subscribe({ next: d => this.districts = d, error: (e) => console.debug(e) });
    } else {
      this.districts = [];
    }
  }

  onDistrictChange(): void {
    const districtId = this.profileForm.get('districtId')?.value;
    this.profileForm.patchValue({ upazilaId: '' });
    if (districtId) {
      this.locationService.getUpazilas(districtId).subscribe({ next: u => this.upazilas = u, error: (e) => console.debug(e) });
    } else {
      this.upazilas = [];
    }
  }

  onSubmit(): void {
    if (this.profileForm.invalid) {
      this.profileForm.markAllAsTouched();
      this.errorMessage = 'Please fill all required fields correctly.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    const { divisionId, ...data } = this.profileForm.value;
    data.dateOfBirth = data.dateOfBirth ? new Date(data.dateOfBirth).toISOString() : undefined;
    data.lastDonationDate = data.lastDonationDate ? new Date(data.lastDonationDate).toISOString() : null;

    const request$ = this.isEditing
      ? this.donorService.updateProfile(data)
      : this.donorService.createProfile(data);

    request$.subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open('Profile saved successfully!', 'Close', { duration: 3000, horizontalPosition: 'end', verticalPosition: 'top' });
        this.router.navigate(['/donor/dashboard']);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Failed to save profile. Please try again.';
      }
    });
  }
}
