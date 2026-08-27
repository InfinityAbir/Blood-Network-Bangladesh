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
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
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
      <div class="request-header">
        <h1>Request Blood</h1>
        <p>Fill in the details to find blood donors quickly</p>
      </div>

      @if (errorMessage) {
        <div class="error-banner">{{ errorMessage }}</div>
      }

      @if (successMessage) {
        <div class="success-banner">{{ successMessage }}</div>
      }

      <mat-card>
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
                  @if (requestForm.get('contactPhone')?.hasError('required') && requestForm.get('contactPhone')?.touched) {
                    <mat-error>Phone is required</mat-error>
                  }
                  @if (requestForm.get('contactPhone')?.hasError('pattern') && requestForm.get('contactPhone')?.touched) {
                    <mat-error>Invalid BD phone number</mat-error>
                  }
                </mat-form-field>
              </div>

              <div class="form-row">
                <mat-form-field appearance="outline" class="full-width">
                  <mat-label>Required By</mat-label>
                  <input matInput [matDatepicker]="picker" formControlName="requiredBy" />
                  <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
                  <mat-datepicker #picker></mat-datepicker>
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
              <button mat-raised-button color="primary" type="submit" class="submit-btn"
                      [disabled]="requestForm.invalid || isLoading">
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
    .request-container { flex: 1; padding: 24px; max-width: 800px; margin: 0 auto; width: 100%; }
    .request-header { margin-bottom: 24px; }
    .request-header h1 { margin: 0 0 4px; font-size: 24px; }
    .request-header p { margin: 0; color: #666; }
    .form-section { margin-bottom: 24px; }
    .form-section h3 { margin: 0 0 12px; font-size: 16px; color: #333; border-bottom: 1px solid #eee; padding-bottom: 8px; }
    .form-row { display: flex; gap: 16px; flex-wrap: wrap; }
    .form-row mat-form-field { flex: 1; min-width: 180px; }
    .full-width { width: 100%; }
    .form-actions { display: flex; justify-content: flex-end; padding-top: 16px; border-top: 1px solid #eee; }
    .submit-btn { height: 48px; font-size: 16px; }
    .error-banner { background: #ffebee; color: #c62828; padding: 12px 16px; border-radius: 4px; margin-bottom: 16px; }
    .success-banner { background: #e8f5e9; color: #2e7d32; padding: 12px 16px; border-radius: 4px; margin-bottom: 16px; }
  `]
})
export class RequestBloodComponent implements OnInit {
  requestForm: FormGroup;
  isLoading = false;
  errorMessage = '';
  successMessage = '';

  divisions: Division[] = [];
  districts: District[] = [];
  upazilas: Upazila[] = [];

  bloodGroups = Object.entries(BloodGroupLabels).map(([value, label]) => ({ value, label }));

  constructor(
    private fb: FormBuilder,
    private requestService: RequestService,
    private locationService: LocationService,
    private router: Router,
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
    if (this.requestForm.invalid) return;

    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    const { divisionId, ...data } = this.requestForm.value;

    this.requestService.createRequest(data).subscribe({
      next: (result) => {
        this.isLoading = false;
        this.snackBar.open('Blood request created! Finding matching donors...', 'Close', {
          duration: 4000,
          horizontalPosition: 'end',
          verticalPosition: 'top'
        });
        this.successMessage = 'Blood request submitted successfully! Donors will be notified.';
        setTimeout(() => {
          this.isLoading = false;
          this.router.navigate(['/requester/dashboard']);
        }, 2000);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error?.message || 'Failed to submit request. Please try again.';
      }
    });
  }
}
