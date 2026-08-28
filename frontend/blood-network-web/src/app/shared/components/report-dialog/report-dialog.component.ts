import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { finalize } from 'rxjs';
import { ReportService } from '../../../core/services/report.service';

export interface ReportDialogData {
  reportedUserId: string;
  reportedUserName: string;
  bloodRequestId?: string;
}

@Component({
  selector: 'app-report-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  template: `
    <div class="report-dialog">
      <div class="dialog-header">
        <div class="header-icon">
          <mat-icon>flag</mat-icon>
        </div>
        <div>
          <h2 mat-dialog-title>Report User</h2>
          <p class="subtitle">Reporting {{ data.reportedUserName }}</p>
        </div>
      </div>

      <mat-dialog-content>
        @if (successMessage) {
          <div class="success-state bgn-fade-up">
            <mat-icon class="success-icon">check_circle</mat-icon>
            <p>{{ successMessage }}</p>
            <span>Our team will review this report shortly.</span>
          </div>
        } @else {
          <form [formGroup]="reportForm" class="report-form">
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Reason for report</mat-label>
              <mat-select formControlName="reason">
                <mat-option value="Fake Donor">Fake Donor</mat-option>
                <mat-option value="No Show">No Show - Didn't arrive when confirmed</mat-option>
                <mat-option value="Rude Behavior">Rude or inappropriate behavior</mat-option>
                <mat-option value="Health Concerns">Health or safety concerns</mat-option>
                <mat-option value="Wrong Information">Wrong blood group or information</mat-option>
                <mat-option value="Scam or Fraud">Scam or fraud attempt</mat-option>
                <mat-option value="Other">Other</mat-option>
              </mat-select>
              @if (reportForm.get('reason')?.hasError('required') && reportForm.get('reason')?.touched) {
                <mat-error>Please select a reason</mat-error>
              }
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Additional details (optional)</mat-label>
              <textarea matInput formControlName="description" rows="4"
                placeholder="Provide any additional context about this report..."></textarea>
            </mat-form-field>
          </form>
        }
      </mat-dialog-content>

      <mat-dialog-actions align="end">
        @if (!successMessage) {
          <button mat-stroked-button class="bgn-press" (click)="dialogRef.close()" [disabled]="isLoading">Cancel</button>
          <button mat-raised-button color="warn" (click)="submit()" [disabled]="reportForm.invalid || isLoading" class="submit-btn bgn-press">
            @if (isLoading) {
              <mat-spinner diameter="18"></mat-spinner>
            } @else {
              <mat-icon>flag</mat-icon> Submit Report
            }
          </button>
        } @else {
          <button mat-raised-button color="primary" class="bgn-press" (click)="dialogRef.close(true)">Done</button>
        }
      </mat-dialog-actions>
    </div>
  `,
  styles: [`
    .report-dialog { padding: 0; }
    .dialog-header { display: flex; align-items: center; gap: 14px; padding: 20px 24px 4px; }
    .header-icon {
      width: 44px; height: 44px; border-radius: 12px;
      background: color-mix(in srgb, var(--bgn-danger, #c62828) 10%, transparent);
      display: flex; align-items: center; justify-content: center;
      transition: transform 0.2s ease-out, background 0.2s ease-out;
    }
    .dialog-header:hover .header-icon {
      transform: scale(1.06) rotate(-4deg);
      background: color-mix(in srgb, var(--bgn-danger, #c62828) 16%, transparent);
    }
    .header-icon mat-icon { color: var(--bgn-danger, #c62828); font-size: 24px; }
    .dialog-header h2 { margin: 0; font-size: 18px; font-weight: 600; }
    .subtitle { margin: 2px 0 0; font-size: 13px; color: var(--bgn-text-muted, #666); }
    .report-form { display: flex; flex-direction: column; gap: 10px; padding-top: 8px; }
    .full-width { width: 100%; }
    .success-state { text-align: center; padding: 24px 0; }
    .success-icon { font-size: 48px; width: 48px; height: 48px; color: var(--bgn-success, #2e7d32); margin-bottom: 12px; }
    .success-state p { margin: 0 0 4px; font-size: 16px; font-weight: 500; }
    .success-state span { font-size: 13px; color: var(--bgn-text-muted, #666); }
    .submit-btn { display: flex; align-items: center; gap: 6px; }
    mat-dialog-actions { padding: 12px 24px 20px !important; gap: 8px; }
  `]
})
export class ReportDialogComponent {
  reportForm: FormGroup;
  isLoading = false;
  successMessage = '';

  constructor(
    private fb: FormBuilder,
    private reportService: ReportService,
    public dialogRef: MatDialogRef<ReportDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ReportDialogData
  ) {
    this.reportForm = this.fb.group({
      reason: ['', Validators.required],
      description: ['']
    });
  }

  submit(): void {
    if (this.reportForm.invalid) return;
    this.isLoading = true;

    this.reportService.createReport({
      reportedUserId: this.data.reportedUserId,
      bloodRequestId: this.data.bloodRequestId,
      reason: this.reportForm.value.reason,
      description: this.reportForm.value.description || undefined
    }).pipe(
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: (res) => { this.successMessage = res.message; },
      error: (err) => { this.dialogRef.close({ error: err.error?.message || 'Failed to submit report.' }); }
    });
  }
}
