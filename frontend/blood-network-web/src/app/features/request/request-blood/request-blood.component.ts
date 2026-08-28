import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, ActivatedRoute } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { RequestService } from '../../../core/services/request.service';
import { LocationService, Division, District, Upazila } from '../../../core/services/location.service';
import { BloodGroup, BloodGroupLabels } from '../../../core/models/blood-group';

@Component({
  selector: 'app-request-blood',
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
    MatRadioModule,
    MatIconModule,
    MatStepperModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HeaderComponent,
    FooterComponent
  ],
  template: `
    <app-header />
    <main class="request-container">
      <div class="request-header bgn-fade-up" style="--i:0">
        <h1>Request Blood</h1>
        <p>Fill in the details to find blood donors quickly</p>
      </div>

      @if (errorMessage) {
        <div class="error-banner" role="alert" aria-live="polite">{{ errorMessage }}</div>
      }

      @if (successMessage) {
        <div class="success-banner" role="status" aria-live="polite">{{ successMessage }}</div>
      }

      <mat-card class="bgn-fade-up" style="--i:1">
        <mat-card-content>
          <form [formGroup]="requestForm" (ngSubmit)="onSubmit()">
            <div class="form-section">
              <h3>Blood Details</h3>
              <div class="form-row">
                <mat-form-field appearance="outline">
                  <mat-label>Blood Group Needed</mat-label>
                  <mat-select formControlName="bloodGroup">
                    @for (group of bloodGroups; track group.value) {
                      <mat-option [value]="group.value">{{ group.label }}</mat-option>
                    }
                  </mat-select>
                  @if (requestForm.get('bloodGroup')?.hasError('required') && requestForm.get('bloodGroup')?.touched) {
                    <mat-error>Required</mat-error>
                  }
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>Units Required</mat-label>
                  <input matInput type="number" formControlName="unitsRequired" min="1" max="10" />
                  @if (requestForm.get('unitsRequired')?.hasError('required') && requestForm.get('unitsRequired')?.touched) {
                    <mat-error>Required</mat-error>
                  }
                  @if (requestForm.get('unitsRequired')?.hasError('min') && requestForm.get('unitsRequired')?.touched) {
                    <mat-error>Minimum 1 unit</mat-error>
                  }
                  @if (requestForm.get('unitsRequired')?.hasError('max') && requestForm.get('unitsRequired')?.touched) {
                    <mat-error>Maximum 10 units</mat-error>
                  }
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>Urgency</mat-label>
                  <mat-select formControlName="urgency">
                    <mat-option value="Critical">Critical</mat-option>
                    <mat-option value="Urgent">Urgent</mat-option>
                    <mat-option value="Normal">Normal</mat-option>
                  </mat-select>
                </mat-form-field>
              </div>
            </div>

            <div class="form-section">
              <h3>Hospital Information</h3>
              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Hospital Name</mat-label>
                  <input matInput formControlName="hospitalName" placeholder="e.g., Dhaka Medical College Hospital" />
                  @if (requestForm.get('hospitalName')?.hasError('required') && requestForm.get('hospitalName')?.touched) {
                    <mat-error>Hospital name is required</mat-error>
                  }
                </mat-form-field>
              </div>
              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Hospital Address</mat-label>
                  <input matInput formControlName="hospitalAddress" placeholder="Full address of the hospital" />
                  @if (requestForm.get('hospitalAddress')?.hasError('required') && requestForm.get('hospitalAddress')?.touched) {
                    <mat-error>Hospital address is required</mat-error>
                  }
                </mat-form-field>
              </div>
            </div>

            <div class="form-section">
              <h3>Location</h3>
              <div class="form-row">
                <mat-form-field appearance="outline">
                  <mat-label>Division</mat-label>
                  <mat-select formControlName="divisionId" (selectionChange)="onDivisionChange()">
                    @for (division of divisions; track division.id) {
                      <mat-option [value]="division.id">{{ division.name }}</mat-option>
                    }
                  </mat-select>
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>District</mat-label>
                  <mat-select formControlName="districtId" (selectionChange)="onDistrictChange()" [disabled]="!requestForm.get('divisionId')?.value">
                    @for (district of districts; track district.id) {
                      <mat-option [value]="district.id">{{ district.name }}</mat-option>
                    }
                  </mat-select>
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>Upazila / Thana</mat-label>
                  <mat-select formControlName="upazilaId" [disabled]="!requestForm.get('districtId')?.value">
                    @for (upazila of upazilas; track upazila.id) {
                      <mat-option [value]="upazila.id">{{ upazila.name }}</mat-option>
                    }
                  </mat-select>
                </mat-form-field>
              </div>
              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Area / Landmark (optional)</mat-label>
                  <input matInput formControlName="area" placeholder="e.g., Near Uttara Metro Station" />
                </mat-form-field>
              </div>
            </div>

            <div class="form-section">
              <h3>Patient & Contact</h3>
              <div class="form-row">
                <mat-form-field appearance="outline">
                  <mat-label>Patient Name (optional)</mat-label>
                  <input matInput formControlName="patientName" />
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>Relation to Patient (optional)</mat-label>
                  <input matInput formControlName="patientRelation" placeholder="e.g., Father, Self" />
                </mat-form-field>

                <mat-form-field appearance="outline">
                  <mat-label>Contact Phone</mat-label>
                  <input matInput formControlName="contactPhone" placeholder="01712345678" maxlength="11" />
                  <mat-hint>Format: 01XXXXXXXXX</mat-hint>
                  @if (requestForm.get('contactPhone')?.hasError('required') && requestForm.get('contactPhone')?.touched) {
                    <mat-error>Phone is required</mat-error>
                  }
                  @if (requestForm.get('contactPhone')?.hasError('pattern') && requestForm.get('contactPhone')?.touched) {
                    <mat-error>Invalid BD phone (e.g., 01712345678)</mat-error>
                  }
                </mat-form-field>
              </div>

              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Required By</mat-label>
                  <input matInput [matDatepicker]="picker" formControlName="requiredBy" [min]="minDate" />
                  <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
                  <mat-datepicker #picker></mat-datepicker>
                  <mat-hint>Must be today or later</mat-hint>
                  @if (requestForm.get('requiredBy')?.hasError('required') && requestForm.get('requiredBy')?.touched) {
                    <mat-error>Required by date is needed</mat-error>
                  }
                </mat-form-field>
              </div>

              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Additional Information (optional)</mat-label>
                  <textarea matInput formControlName="additionalInformation" rows="3" placeholder="Any other relevant details..."></textarea>
                </mat-form-field>
              </div>
            </div>

            <div class="form-actions">
              <a mat-stroked-button routerLink="/" class="cancel-btn bgn-press">Cancel</a>
              <button mat-raised-button color="primary" type="submit" class="submit-btn bgn-press"
                      [disabled]="isLoading">
                @if (isLoading) {
                  <mat-spinner diameter="20"></mat-spinner>
                } @else {
                  <ng-container>
                    <mat-icon>send</mat-icon> Submit Blood Request
                  </ng-container>
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
    .request-container { flex: 1; padding: 24px; max-width: 800px; margin: 0 auto; width: 100%; box-sizing: border-box; }
    .request-header { margin-bottom: 24px; }
    .request-header h1 { margin: 0 0 4px; font-size: 24px; color: var(--bgn-text); }
    .request-header p { margin: 0; color: var(--bgn-text-muted); }
    .form-section { margin-bottom: 28px; }
    .form-section h3 { margin: 0 0 16px; font-size: 16px; color: var(--bgn-text); border-bottom: 1px solid var(--bgn-border); padding-bottom: 8px; }
    .form-row { display: flex; gap: 16px; row-gap: 12px; flex-wrap: wrap; margin-bottom: 4px; }
    .form-row mat-form-field { flex: 1; min-width: 160px; }
    .full-width { width: 100%; }
    .form-actions { display: flex; gap: 12px; justify-content: flex-end; padding-top: 16px; border-top: 1px solid var(--bgn-border); flex-wrap: wrap; }
    .form-actions .cancel-btn, .form-actions .submit-btn { height: 48px; font-size: 15px; flex: 1; min-width: 120px; }
    .form-actions .cancel-btn { max-width: 140px; }
    .error-banner { background: color-mix(in srgb, var(--bgn-danger) 12%, transparent); color: var(--bgn-danger); border: 1px solid color-mix(in srgb, var(--bgn-danger) 30%, transparent); padding: 12px 16px; border-radius: var(--bgn-radius-md); margin-bottom: 16px; animation: bgn-fade-up 0.35s ease-out; }
    .success-banner { background: color-mix(in srgb, var(--bgn-success) 14%, transparent); color: var(--bgn-success); border: 1px solid color-mix(in srgb, var(--bgn-success) 30%, transparent); padding: 12px 16px; border-radius: var(--bgn-radius-md); margin-bottom: 16px; animation: bgn-fade-up 0.35s ease-out; }
    .form-section { transition: opacity 0.2s ease; }
    .submit-btn { transition: transform 0.15s ease-out, box-shadow 0.2s ease-out; }
    .submit-btn:not([disabled]):hover { box-shadow: var(--bgn-shadow-md); }
    mat-card { transition: box-shadow 0.2s ease-out; }
    @media (max-width: 600px) {
      .form-row { flex-direction: column; }
      .form-row mat-form-field { min-width: 0; }
      .form-actions { flex-direction: column; gap: 8px; }
      .form-actions .submit-btn, .form-actions .cancel-btn { width: 100%; max-width: none; height: 48px; font-size: 16px; border-radius: var(--bgn-radius-pill) !important; }
      .form-actions .submit-btn { order: -1; }
    }
  `]
})
export class RequestBloodComponent implements OnInit {
  requestForm: FormGroup;
  isLoading = false;
  errorMessage = '';
  successMessage = '';
  minDate = new Date();

  divisions: Division[] = [];
  districts: District[] = [];
  upazilas: Upazila[] = [];

  bloodGroups = Object.entries(BloodGroupLabels).map(([value, label]) => ({ value, label }));

  constructor(
    private fb: FormBuilder,
    private requestService: RequestService,
    private locationService: LocationService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {
    this.requestForm = this.fb.group({
      bloodGroup: ['', Validators.required],
      unitsRequired: [1, [Validators.required, Validators.min(1), Validators.max(10)]],
      urgency: ['Urgent', Validators.required],
      hospitalName: ['', Validators.required],
      hospitalAddress: ['', Validators.required],
      divisionId: ['', Validators.required],
      districtId: ['', Validators.required],
      upazilaId: ['', Validators.required],
      area: [''],
      patientName: [''],
      patientRelation: [''],
      contactPhone: ['', [Validators.required, Validators.pattern(/^01[3-9]\d{8}$/)]],
      requiredBy: [null, Validators.required],
      additionalInformation: ['']
    });
  }

  ngOnInit(): void {
    this.locationService.getDivisions().subscribe({ next: divs => this.divisions = divs, error: (e) => console.debug(e) });
    this.route.queryParams.subscribe(params => {
      if (params['bloodGroup']) this.requestForm.patchValue({ bloodGroup: params['bloodGroup'] });
    });
  }

  onDivisionChange(): void {
    const divisionId = this.requestForm.get('divisionId')?.value;
    this.requestForm.patchValue({ districtId: '', upazilaId: '' });
    this.upazilas = [];
    if (divisionId) {
      this.locationService.getDistricts(divisionId).subscribe({ next: d => this.districts = d, error: (e) => console.debug(e) });
    } else {
      this.districts = [];
    }
  }

  onDistrictChange(): void {
    const districtId = this.requestForm.get('districtId')?.value;
    this.requestForm.patchValue({ upazilaId: '' });
    if (districtId) {
      this.locationService.getUpazilas(districtId).subscribe({ next: u => this.upazilas = u, error: (e) => console.debug(e) });
    } else {
      this.upazilas = [];
    }
  }

  onSubmit(): void {
    if (this.requestForm.invalid) {
      this.requestForm.markAllAsTouched();
      this.errorMessage = 'Please fill all required fields correctly.';
      return;
    }
    const units = this.requestForm.get('unitsRequired')?.value;
    const bg = this.requestForm.get('bloodGroup')?.value;
    if (!confirm(`Confirm blood request for ${bg || 'selected group'} — ${units} unit(s)? This will notify matching donors.`)) return;

    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    const { divisionId, ...data } = this.requestForm.value;

    this.requestService.createRequest(data).pipe(
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: () => {
        this.snackBar.open('Blood request created! Finding matching donors...', 'Close', {
          duration: 4000,
          horizontalPosition: 'end',
          verticalPosition: 'top'
        });
        this.successMessage = 'Blood request submitted successfully! Donors will be notified.';
        setTimeout(() => this.router.navigate(['/requester/dashboard']), 1500);
      },
      error: (err) => {
        if (err.status === 401) {
          this.errorMessage = 'Please login to request blood. Redirecting to login...';
          setTimeout(() => this.router.navigate(['/login']), 1200);
        } else {
          this.errorMessage = err.error?.message || err.error?.Message || 'Failed to submit request. Please try again.';
        }
      }
    });
  }
}
