import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { DonorService } from '../../../core/services/donor.service';
import { LocationService, Division, District, Upazila } from '../../../core/services/location.service';
import { BloodGroup, BloodGroupLabels } from '../../../core/models/blood-group';

@Component({
  selector: 'app-donor-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="profile-container">
      <mat-card class="profile-card">
        <mat-card-header>
          <mat-card-title>Donor Profile Setup</mat-card-title>
          <mat-card-subtitle>Complete your profile to start receiving match requests</mat-card-subtitle>
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
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>District</mat-label>
              <mat-select formControlName="districtId" (selectionChange)="onDistrictChange()" [disabled]="!profileForm.get('divisionId')?.value">
                @for (district of districts; track district.id) {
                  <mat-option [value]="district.id">{{ district.name }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Upazila</mat-label>
              <mat-select formControlName="upazilaId" [disabled]="!profileForm.get('districtId')?.value">
                @for (upazila of upazilas; track upazila.id) {
                  <mat-option [value]="upazila.id">{{ upazila.name }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Area / Landmark (optional)</mat-label>
              <input matInput formControlName="area" placeholder="e.g., Near Dhaka Medical College" />
            </mat-form-field>

            <button mat-raised-button color="primary" type="submit" class="full-width submit-btn"
                    [disabled]="profileForm.invalid || isLoading">
              @if (isLoading) {
                <mat-spinner diameter="20"></mat-spinner>
              } @else {
                Save Profile
              }
            </button>
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
    .submit-btn { margin-top: 16px; height: 48px; }
    .error-banner {
      background: #ffebee; color: #c62828;
      padding: 12px 16px; border-radius: 4px;
      margin-bottom: 16px; font-size: 14px;
    }
  `]
})
export class DonorProfileComponent implements OnInit {
  profileForm: FormGroup;
  isLoading = false;
  hidePassword = true;
  errorMessage = '';

  divisions: Division[] = [];
  districts: District[] = [];
  upazilas: Upazila[] = [];

  bloodGroups = Object.entries(BloodGroupLabels).map(([value, label]) => ({ value, label }));

  constructor(
    private fb: FormBuilder,
    private donorService: DonorService,
    private locationService: LocationService,
    private router: Router
  ) {
    this.profileForm = this.fb.group({
      bloodGroup: ['', Validators.required],
      gender: [''],
      dateOfBirth: [null],
      divisionId: ['', Validators.required],
      districtId: ['', Validators.required],
      upazilaId: ['', Validators.required],
      area: ['']
    });
  }

  ngOnInit(): void {
    this.locationService.getDivisions().subscribe(divs => this.divisions = divs);

    this.donorService.getMyProfile().subscribe({
      next: (profile) => {
        this.router.navigate(['/donor/dashboard']);
      },
      error: () => {}
    });
  }

  onDivisionChange(): void {
    const divisionId = this.profileForm.get('divisionId')?.value;
    this.profileForm.patchValue({ districtId: '', upazilaId: '' });
    this.upazilas = [];
    if (divisionId) {
      this.locationService.getDistricts(divisionId).subscribe(d => this.districts = d);
    } else {
      this.districts = [];
    }
  }

  onDistrictChange(): void {
    const districtId = this.profileForm.get('districtId')?.value;
    this.profileForm.patchValue({ upazilaId: '' });
    if (districtId) {
      this.locationService.getUpazilas(districtId).subscribe(u => this.upazilas = u);
    } else {
      this.upazilas = [];
    }
  }

  onSubmit(): void {
    if (this.profileForm.invalid) return;

    this.isLoading = true;
    this.errorMessage = '';

    const { divisionId, ...data } = this.profileForm.value;

    this.donorService.createProfile(data).subscribe({
      next: () => {
        this.router.navigate(['/donor/dashboard']);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Failed to create profile. Please try again.';
      }
    });
  }
}
