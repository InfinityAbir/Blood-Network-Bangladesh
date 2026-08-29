import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { RevealDirective } from '../../../shared/directives/reveal.directive';
import { AdminService } from '../../../core/services/admin.service';
import { AdminEligibilityQuestion } from '../../../core/models/admin';
import { EligibilityQuestionDialogComponent } from './eligibility-question-dialog.component';

@Component({
  selector: 'app-admin-eligibility-questions',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatSlideToggleModule,
    MatDialogModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent,
    RevealDirective
  ],
  template: `
    <app-header />
    <main class="container">
      <a mat-button routerLink="/admin" class="back-link"><mat-icon>arrow_back</mat-icon> Back to Dashboard</a>
      <div class="page-header">
        <h1>Eligibility Questions</h1>
        <button mat-raised-button color="primary" (click)="openCreate()" class="bgn-press">
          <mat-icon>add</mat-icon> Add Question
        </button>
      </div>

      @if (errorMessage) {
        <div class="error-banner">
          <mat-icon>error</mat-icon>
          <span>{{ errorMessage }}</span>
          <button mat-button (click)="load()" class="bgn-press">Retry</button>
        </div>
      }

      @if (isLoading) {
        <div class="sk-list">
          @for (i of [1,2,3,4]; track i) {
            <mat-card class="sk-card">
              <app-skeleton type="line" width="70%" height="18px" />
              <div style="margin-top:10px"><app-skeleton type="line" width="40%" height="14px" /></div>
            </mat-card>
          }
        </div>
      } @else if (questions.length === 0) {
        <div class="no-results">No questions yet. Click "Add Question" to create the first one.</div>
      } @else {
        <div class="q-list" appReveal>
          @for (q of questions; track q.id) {
            <mat-card class="q-card bgn-hover-lift">
              <div class="q-top">
                <div class="q-title">
                  <span class="order">#{{ q.displayOrder }}</span>
                  {{ q.questionEn }}
                </div>
                <span class="chip" [class]="q.isActive ? 'active' : 'inactive'">{{ q.isActive ? 'Active' : 'Inactive' }}</span>
              </div>
              <div class="q-tags">
                <span class="tag">{{ q.questionType === 'number' ? ('Number' + (q.unit ? ' (' + q.unit + ')' : '')) : 'Yes / No' }}</span>
                @if (q.isCritical) {
                  <span class="tag critical">Critical</span>
                }
              </div>
              <div class="q-actions">
                <div class="toggle-group">
                  <span>{{ q.isActive ? 'Deactivate' : 'Activate' }}</span>
                  <mat-slide-toggle [checked]="q.isActive" (change)="toggleActive(q, $event.checked)"></mat-slide-toggle>
                </div>
                <div>
                  <button mat-icon-button (click)="openEdit(q)"><mat-icon>edit</mat-icon></button>
                  <button mat-icon-button color="warn" (click)="confirmDelete(q)"><mat-icon>delete</mat-icon></button>
                </div>
              </div>
            </mat-card>
          }
        </div>
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .container { flex: 1; padding: 24px; max-width: 900px; margin: 0 auto; width: 100%; }
    .back-link { margin-bottom: 12px; }
    .page-header { display: flex; align-items: center; justify-content: space-between; margin-bottom: 24px; flex-wrap: wrap; gap: 12px; }
    .page-header h1 { margin: 0; font-size: 24px; }
    .error-banner { display: flex; align-items: center; gap: 10px; padding: 12px 16px; background: #ffebee; color: #c62828; border-radius: 8px; margin-bottom: 16px; }
    .sk-list { display: flex; flex-direction: column; gap: 10px; }
    .sk-card { padding: 16px; }
    .no-results { text-align: center; padding: 60px; color: #999; }
    .q-list { display: flex; flex-direction: column; gap: 10px; }
    .q-card { padding: 16px; }
    .q-top { display: flex; align-items: flex-start; justify-content: space-between; gap: 10px; }
    .q-title { font-size: 15px; font-weight: 600; }
    .order { color: #999; font-weight: 500; margin-right: 4px; }
    .chip { flex-shrink: 0; display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; font-weight: 500; }
    .chip.active { background: #e8f5e9; color: #2e7d32; }
    .chip.inactive { background: #ffebee; color: #c62828; }
    .q-tags { display: flex; gap: 8px; margin-top: 8px; }
    .tag { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; font-weight: 500; background: #f5f5f5; color: #666; }
    .tag.critical { background: #ffebee; color: #c62828; }
    .q-actions { display: flex; align-items: center; justify-content: space-between; margin-top: 12px; }
    .toggle-group { display: flex; align-items: center; gap: 8px; font-size: 13px; color: #666; }
    @media (max-width: 600px) {
      .container { padding: 16px; }
      .page-header { flex-direction: column; align-items: stretch; }
    }
  `]
})
export class AdminEligibilityQuestionsComponent implements OnInit {
  questions: AdminEligibilityQuestion[] = [];
  isLoading = true;
  errorMessage = '';

  constructor(
    private adminService: AdminService,
    private dialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.adminService.getEligibilityQuestions().pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (list) => { this.questions = list.sort((a, b) => a.displayOrder - b.displayOrder); },
      error: (e) => {
        console.debug(e);
        this.errorMessage = e.error?.message || e.message || 'Failed to load questions.';
      }
    });
  }

  openCreate(): void {
    const ref = this.dialog.open(EligibilityQuestionDialogComponent, {
      width: '600px',
      maxWidth: '95vw',
      data: {}
    });
    ref.afterClosed().subscribe((result) => this.handleDialogResult(result));
  }

  openEdit(q: AdminEligibilityQuestion): void {
    const ref = this.dialog.open(EligibilityQuestionDialogComponent, {
      width: '600px',
      maxWidth: '95vw',
      data: { existing: q }
    });
    ref.afterClosed().subscribe((result) => this.handleDialogResult(result));
  }

  private handleDialogResult(result: any): void {
    if (!result) return;
    if (result.error) {
      this.errorMessage = result.error;
      return;
    }
    this.load();
  }

  toggleActive(q: AdminEligibilityQuestion, isActive: boolean): void {
    const previous = q.isActive;
    q.isActive = isActive;
    this.adminService.toggleEligibilityQuestionActive(q.id, isActive).subscribe({
      next: (updated) => { Object.assign(q, updated); },
      error: (e) => { q.isActive = previous; console.debug(e); }
    });
  }

  confirmDelete(q: AdminEligibilityQuestion): void {
    if (!confirm(`Delete "${q.questionEn}"? This can't be undone.`)) return;
    this.adminService.deleteEligibilityQuestion(q.id).subscribe({
      next: () => { this.questions = this.questions.filter(x => x.id !== q.id); },
      error: (e) => { console.debug(e); this.errorMessage = e.error?.message || 'Failed to delete question.'; }
    });
  }
}
