import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { finalize } from 'rxjs';
import { AdminService } from '../../../core/services/admin.service';
import { AdminEligibilityQuestion, SaveEligibilityQuestionRequest } from '../../../core/models/admin';

export interface EligibilityQuestionDialogData {
  existing?: AdminEligibilityQuestion;
}

@Component({
  selector: 'app-eligibility-question-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatButtonToggleModule,
    MatSlideToggleModule,
    MatProgressSpinnerModule
  ],
  template: `
    <div class="q-dialog">
      <h2 mat-dialog-title>{{ data.existing ? 'Edit Question' : 'Add Question' }}</h2>

      <mat-dialog-content>
        <form [formGroup]="form" class="q-form">
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Question (English)</mat-label>
            <input matInput formControlName="questionEn">
          </mat-form-field>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Question (Bengali script)</mat-label>
            <input matInput formControlName="questionBn">
          </mat-form-field>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Question (Banglish)</mat-label>
            <input matInput formControlName="questionBanglish">
          </mat-form-field>

          <label class="field-label">Answer type</label>
          <mat-button-toggle-group formControlName="questionType" class="full-width">
            <mat-button-toggle value="yesno">Yes / No</mat-button-toggle>
            <mat-button-toggle value="number">Number</mat-button-toggle>
          </mat-button-toggle-group>

          @if (form.value.questionType === 'number') {
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Unit (optional, e.g. kg)</mat-label>
              <input matInput formControlName="unit">
            </mat-form-field>
            <div class="row">
              <mat-form-field appearance="outline" class="half">
                <mat-label>Min to pass (optional)</mat-label>
                <input matInput type="number" formControlName="minValue">
              </mat-form-field>
              <mat-form-field appearance="outline" class="half">
                <mat-label>Max to pass (optional)</mat-label>
                <input matInput type="number" formControlName="maxValue">
              </mat-form-field>
            </div>
          } @else {
            <label class="field-label">Which answer passes?</label>
            <mat-button-toggle-group formControlName="passOnYes" class="full-width">
              <mat-button-toggle [value]="false">"No" passes</mat-button-toggle>
              <mat-button-toggle [value]="true">"Yes" passes</mat-button-toggle>
            </mat-button-toggle-group>
          }

          <div class="critical-row">
            <div>
              <div class="field-label">Critical</div>
              <div class="hint">Failing this alone makes the donor ineligible</div>
            </div>
            <mat-slide-toggle formControlName="isCritical"></mat-slide-toggle>
          </div>

          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Display order</mat-label>
            <input matInput type="number" formControlName="displayOrder">
          </mat-form-field>

          <label class="field-label">Messages shown to the donor</label>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Pass message (English)</mat-label>
            <input matInput formControlName="passMessageEn">
          </mat-form-field>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Pass message (Bengali)</mat-label>
            <input matInput formControlName="passMessageBn">
          </mat-form-field>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Fail message (English) — use {{ '{value}' }} for the answer</mat-label>
            <input matInput formControlName="failMessageEn">
          </mat-form-field>
          <mat-form-field appearance="outline" class="full-width">
            <mat-label>Fail message (Bengali) — use {{ '{value}' }} for the answer</mat-label>
            <input matInput formControlName="failMessageBn">
          </mat-form-field>
        </form>
      </mat-dialog-content>

      <mat-dialog-actions align="end">
        <button mat-stroked-button class="bgn-press" (click)="dialogRef.close()" [disabled]="isSaving">Cancel</button>
        <button mat-raised-button color="primary" (click)="save()" [disabled]="form.invalid || isSaving" class="bgn-press">
          @if (isSaving) {
            <mat-spinner diameter="18"></mat-spinner>
          } @else {
            Save
          }
        </button>
      </mat-dialog-actions>
    </div>
  `,
  styles: [`
    .q-dialog { padding: 0; max-width: 560px; }
    .q-form { display: flex; flex-direction: column; gap: 4px; padding-top: 4px; }
    .full-width { width: 100%; }
    .field-label { font-size: 13px; font-weight: 600; margin: 10px 0 4px; color: var(--bgn-text-muted, #555); }
    .hint { font-size: 12px; color: var(--bgn-text-muted, #888); }
    .row { display: flex; gap: 12px; }
    .half { flex: 1; }
    .critical-row { display: flex; align-items: center; justify-content: space-between; margin: 8px 0; }
    mat-dialog-content { max-height: 70vh; }
    mat-dialog-actions { padding: 12px 24px 20px !important; gap: 8px; }
  `]
})
export class EligibilityQuestionDialogComponent {
  form: FormGroup;
  isSaving = false;

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    public dialogRef: MatDialogRef<EligibilityQuestionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EligibilityQuestionDialogData
  ) {
    const q = data.existing;
    this.form = this.fb.group({
      questionEn: [q?.questionEn ?? '', Validators.required],
      questionBn: [q?.questionBn ?? '', Validators.required],
      questionBanglish: [q?.questionBanglish ?? '', Validators.required],
      questionType: [q?.questionType ?? 'yesno', Validators.required],
      unit: [q?.unit ?? ''],
      minValue: [q?.minValue ?? null],
      maxValue: [q?.maxValue ?? null],
      passOnYes: [q?.passOnYes ?? false],
      isCritical: [q?.isCritical ?? false],
      displayOrder: [q?.displayOrder ?? 0, Validators.required],
      passMessageEn: [q?.passMessageEn ?? '', Validators.required],
      passMessageBn: [q?.passMessageBn ?? '', Validators.required],
      failMessageEn: [q?.failMessageEn ?? '', Validators.required],
      failMessageBn: [q?.failMessageBn ?? '', Validators.required],
    });
  }

  save(): void {
    if (this.form.invalid) return;
    this.isSaving = true;

    const v = this.form.value;
    const request: SaveEligibilityQuestionRequest = {
      questionEn: v.questionEn.trim(),
      questionBn: v.questionBn.trim(),
      questionBanglish: v.questionBanglish.trim(),
      questionType: v.questionType,
      unit: v.questionType === 'number' ? (v.unit?.trim() || undefined) : undefined,
      minValue: v.questionType === 'number' && v.minValue !== null && v.minValue !== '' ? Number(v.minValue) : undefined,
      maxValue: v.questionType === 'number' && v.maxValue !== null && v.maxValue !== '' ? Number(v.maxValue) : undefined,
      passOnYes: v.questionType === 'yesno' ? v.passOnYes : undefined,
      isCritical: v.isCritical,
      displayOrder: Number(v.displayOrder),
      passMessageEn: v.passMessageEn.trim(),
      passMessageBn: v.passMessageBn.trim(),
      failMessageEn: v.failMessageEn.trim(),
      failMessageBn: v.failMessageBn.trim(),
    };

    const call$ = this.data.existing
      ? this.adminService.updateEligibilityQuestion(this.data.existing.id, request)
      : this.adminService.createEligibilityQuestion(request);

    call$.pipe(finalize(() => this.isSaving = false)).subscribe({
      next: (result) => this.dialogRef.close(result),
      error: (err) => { this.dialogRef.close({ error: err.error?.message || 'Failed to save question.' }); }
    });
  }
}
