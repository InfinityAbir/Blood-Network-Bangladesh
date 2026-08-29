import { Component, signal, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { HeaderComponent } from '../../../layout/header/header.component';
import { MatCardModule } from '@angular/material/card';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { retry, timer, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { RevealDirective } from '../../directives/reveal.directive';
import { AuthService } from '../../../core/services/auth.service';

interface EligibilityQuestion {
  id: string;
  questionBn: string;
  questionEn: string;
  questionBanglish: string;
  questionType: 'yesno' | 'number';
  unit?: string;
  minValue?: number;
  maxValue?: number;
}

interface EligibilityCheck {
  questionId: string;
  passed: boolean;
  message: string;
  messageBn: string;
}

interface EligibilityResult {
  isEligible: boolean;
  score: number;
  checks: EligibilityCheck[];
  recommendationBn: string;
  recommendationEn: string;
}

@Component({
  selector: 'app-eligibility-check',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink,
    HeaderComponent,
    MatCardModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    MatProgressBarModule,
    MatInputModule,
    MatFormFieldModule,
    RevealDirective,
  ],
  template: `
    <app-header />
    <div class="eligibility-page page-wrap">
      <div class="container eligibility-container">
        <div class="page-header bgn-fade-up" style="--i:0">
          <mat-icon class="header-icon bgn-float">fact_check</mat-icon>
          <div>
            <h1>Donor Eligibility Check</h1>
            <p class="subtitle">যোগ্যতা পরীক্ষা — Blood Donation Self-Assessment</p>
          </div>
        </div>

        @if (error()) {
          <div class="error-banner bgn-fade-up">
            <mat-icon>error_outline</mat-icon>
            <span>{{ error() }}</span>
          </div>
        }

        @if (!result()) {
          @if (loading()) {
            <mat-card class="loading-card">
              <mat-progress-bar mode="indeterminate"></mat-progress-bar>
              <p class="loading-text">Loading questions / প্রশ্ন লোড হচ্ছে...</p>
            </mat-card>
          } @else if (questions().length > 0) {
            <mat-card class="progress-card" appReveal>
              <div class="progress-header">
                <span>Question {{ currentIndex() + 1 }} of {{ questions().length }}</span>
                <span>{{ progressPercent() }}%</span>
              </div>
              <mat-progress-bar mode="determinate" [value]="progressPercent()"></mat-progress-bar>
            </mat-card>

            <mat-card class="question-card" appReveal [appRevealDelay]="1">
              <div class="question-number">Q{{ currentIndex() + 1 }}</div>
              <h2 class="question-title">{{ currentQuestion().questionEn }}</h2>
              <p class="question-bn">{{ currentQuestion().questionBanglish }}</p>

              @if (currentQuestion().questionType === 'yesno') {
                <div class="yesno-options bgn-fade-up">
                  <label class="radio-option" [class.selected]="answers()[qKey(currentQuestion())] === 'yes'">
                    <input
                      type="radio"
                      [name]="'q' + currentQuestion().id"
                      value="yes"
                      [(ngModel)]="answers()[qKey(currentQuestion())]"
                    />
                    <span class="radio-label">Yes / হ্যাঁ</span>
                  </label>
                  <label class="radio-option" [class.selected]="answers()[qKey(currentQuestion())] === 'no'">
                    <input
                      type="radio"
                      [name]="'q' + currentQuestion().id"
                      value="no"
                      [(ngModel)]="answers()[qKey(currentQuestion())]"
                    />
                    <span class="radio-label">No / না</span>
                  </label>
                </div>
              } @else {
                <mat-form-field appearance="outline" class="number-field bgn-fade-up">
                  <mat-label>{{ currentQuestion().questionEn }}</mat-label>
                  <input
                    matInput
                    type="number"
                    [min]="currentQuestion().minValue ?? null"
                    [max]="currentQuestion().maxValue ?? null"
                    [(ngModel)]="answers()[qKey(currentQuestion())]"
                    [placeholder]="currentQuestion().unit ?? ''"
                  />
                  @if (currentQuestion().unit) {
                    <mat-hint>{{ currentQuestion().unit }}</mat-hint>
                  }
                  @if (answers()[qKey(currentQuestion())] !== undefined && answers()[qKey(currentQuestion())] !== '' && isNumberOutOfRange()) {
                    <mat-error>Value must be {{ rangeHint(currentQuestion()) }} {{ currentQuestion().unit ?? '' }}</mat-error>
                  }
                </mat-form-field>
              }

              <div class="nav-buttons">
                <button
                  mat-stroked-button
                  class="bgn-press"
                  (click)="prev()"
                  [disabled]="currentIndex() === 0"
                >
                  <mat-icon>arrow_back</mat-icon>
                  Back
                </button>
                @if (currentIndex() < questions().length - 1) {
                  <button
                    mat-flat-button
                    color="primary"
                    class="bgn-press"
                    (click)="next()"
                    [disabled]="!canProceed()"
                  >
                    Next
                    <mat-icon>arrow_forward</mat-icon>
                  </button>
                } @else {
                  <button
                    mat-flat-button
                    color="primary"
                    class="bgn-press"
                    (click)="submit()"
                    [disabled]="!canProceed() || submitting()"
                  >
                    @if (submitting()) {
                      <mat-icon>hourglass_top</mat-icon>
                    } @else {
                      <mat-icon>check</mat-icon>
                    }
                    Submit / জমা দিন
                  </button>
                }
              </div>
            </mat-card>
          }
        } @else {
          <mat-card class="result-card bgn-fade-up" style="--i:0">
            <div class="result-header" [class.pass]="result()!.isEligible" [class.fail]="!result()!.isEligible">
              <mat-icon class="result-icon" [class.bgn-heartbeat]="result()!.isEligible">
                {{ result()!.isEligible ? 'check_circle' : 'cancel' }}
              </mat-icon>
              <div>
                <h2>{{ result()!.isEligible ? 'Eligible to Donate!' : 'Not Eligible at This Time' }}</h2>
                <p>{{ result()!.isEligible
                  ? 'আপনি রক্তদানের জন্য যোগ্য।'
                  : 'আপনি এখন রক্তদানের জন্য যোগ্য নন।' }}</p>
              </div>
            </div>

            <div class="score-section bgn-fade-up" style="--i:1">
              <span class="score-label">Score</span>
              <span class="score-value">{{ result()!.score }}%</span>
            </div>

            <div class="results-list">
              @for (r of result()!.checks; track r.questionId; let i = $index) {
                <div class="result-item bgn-fade-up" [style.--i]="i + 2" [class.pass]="r.passed" [class.fail]="!r.passed">
                  <mat-icon>{{ r.passed ? 'check_circle' : 'cancel' }}</mat-icon>
                  <span>{{ r.message }} <span class="bangla">/ {{ r.messageBn }}</span></span>
                </div>
              }
            </div>

            <div class="disclaimer-box bgn-fade-up">
              <mat-icon>info</mat-icon>
              <p>This self-check is not a medical diagnosis and isn't approved by a medical authority. For an accurate assessment, please visit a hospital or consult a doctor. / এটি কোনো চিকিৎসা নির্ণয় নয় এবং কোনো চিকিৎসা কর্তৃপক্ষ কর্তৃক অনুমোদিত নয়। সঠিক মূল্যায়নের জন্য দয়া করে হাসপাতালে যান বা একজন চিকিৎসকের পরামর্শ নিন।</p>
            </div>

            <div class="result-actions">
              <a mat-stroked-button routerLink="/" class="bgn-press">
                <mat-icon>home</mat-icon>
                Home / হোম
              </a>
              <a mat-stroked-button routerLink="/find-blood" class="bgn-press">
                <mat-icon>search</mat-icon>
                Find Blood / রক্ত খুঁজুন
              </a>
              <button mat-flat-button color="primary" class="bgn-press" (click)="reset()">
                <mat-icon>refresh</mat-icon>
                Retake / আবার করুন
              </button>
            </div>
          </mat-card>
        }
      </div>
    </div>
  `,
  styles: [`
    .eligibility-container {
      max-width: 640px;
      margin: 0 auto;
      padding: 32px 20px 64px;
    }

    .page-header {
      display: flex;
      align-items: center;
      gap: 16px;
      margin-bottom: 28px;
    }
    .header-icon {
      font-size: 36px;
      width: 36px;
      height: 36px;
      color: var(--bgn-primary);
    }
    .page-header h1 { margin: 0; font-size: 1.8rem; }
    .subtitle { margin: 4px 0 0; color: var(--bgn-text-muted); font-size: 0.95rem; }

    .error-banner {
      display: flex;
      align-items: center;
      gap: 10px;
      padding: 14px 18px;
      background: rgba(211, 47, 47, 0.08);
      border: 1px solid var(--bgn-danger);
      border-radius: var(--bgn-radius-md);
      color: var(--bgn-danger);
      margin-bottom: 20px;
      font-size: 0.9rem;
    }

    .loading-card {
      padding: 40px;
      text-align: center;
    }
    .loading-text { margin-top: 16px; color: var(--bgn-text-muted); }

    .progress-card {
      padding: 16px 20px;
      margin-bottom: 16px;
    }
    .progress-header {
      display: flex;
      justify-content: space-between;
      font-size: 0.85rem;
      color: var(--bgn-text-muted);
      margin-bottom: 8px;
    }

    .question-card {
      padding: 28px 24px;
    }
    .question-number {
      display: inline-block;
      background: var(--bgn-gradient);
      color: #fff;
      font-weight: 700;
      font-size: 0.85rem;
      padding: 4px 12px;
      border-radius: var(--bgn-radius-pill);
      margin-bottom: 12px;
    }
    .question-title {
      margin: 0 0 4px;
      font-size: 1.2rem;
    }
    .question-bn {
      margin: 0 0 20px;
      color: var(--bgn-text-muted);
      font-size: 0.95rem;
    }

    .yesno-options {
      display: flex;
      gap: 16px;
      margin-bottom: 24px;
    }
    .radio-option {
      flex: 1;
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 8px;
      padding: 16px;
      border: 2px solid var(--bgn-border);
      border-radius: var(--bgn-radius-md);
      cursor: pointer;
      transition: all 0.2s ease;
      text-align: center;
    }
    .radio-option:hover {
      border-color: var(--bgn-primary);
      background: rgba(229, 57, 53, 0.04);
      transform: translateY(-2px);
    }
    .radio-option:active {
      transform: scale(0.97);
    }
    .radio-option.selected {
      border-color: var(--bgn-primary);
      background: rgba(229, 57, 53, 0.08);
    }
    .radio-option input { display: none; }
    .radio-label { font-size: 1rem; font-weight: 500; }

    .number-field {
      width: 100%;
      margin-bottom: 24px;
    }

    .nav-buttons {
      display: flex;
      justify-content: space-between;
      gap: 12px;
    }

    .result-card { padding: 28px 24px; }
    .result-header {
      display: flex;
      align-items: center;
      gap: 14px;
      margin-bottom: 20px;
    }
    .result-icon { font-size: 40px; width: 40px; height: 40px; }
    .result-header.pass .result-icon { color: var(--bgn-success); }
    .result-header.fail .result-icon { color: var(--bgn-danger); }
    .result-header h2 { margin: 0; font-size: 1.4rem; }
    .result-header p { margin: 4px 0 0; color: var(--bgn-text-muted); }

    .score-section {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 14px 18px;
      background: var(--bgn-surface-2);
      border-radius: var(--bgn-radius-md);
      margin-bottom: 20px;
    }
    .score-label { font-weight: 600; }
    .score-value { font-size: 1.5rem; font-weight: 800; color: var(--bgn-primary); }

    .results-list {
      display: flex;
      flex-direction: column;
      gap: 8px;
      margin-bottom: 20px;
    }
    .result-item {
      display: flex;
      align-items: center;
      gap: 10px;
      padding: 10px 14px;
      border-radius: var(--bgn-radius-sm);
      font-size: 0.9rem;
    }
    .result-item.pass {
      background: rgba(46, 125, 50, 0.06);
      color: var(--bgn-success);
    }
    .result-item.fail {
      background: rgba(211, 47, 47, 0.06);
      color: var(--bgn-danger);
    }

    .disclaimer-box {
      display: flex;
      gap: 10px;
      align-items: flex-start;
      padding: 14px 16px;
      background: var(--bgn-surface-2);
      border: 1px solid var(--bgn-border);
      border-left: 4px solid var(--bgn-warning);
      border-radius: var(--bgn-radius-md);
      margin-bottom: 20px;
    }
    .disclaimer-box mat-icon { color: var(--bgn-warning); flex-shrink: 0; margin-top: 2px; }
    .disclaimer-box p { margin: 0; font-size: 0.85rem; color: var(--bgn-text-muted); }

    .result-actions { display: flex; gap: 12px; justify-content: center; flex-wrap: wrap; }
  `]
})
export class EligibilityCheckComponent {
  questions = signal<EligibilityQuestion[]>([]);
  answers = signal<Record<string, string>>({});
  currentIndex = signal(0);
  loading = signal(true);
  submitting = signal(false);
  error = signal<string | null>(null);
  result = signal<EligibilityResult | null>(null);

  private apiUrl = `${environment.apiUrl}/ai/eligibility`;
  private auth = inject(AuthService);

  currentQuestion = computed(() => this.questions()[this.currentIndex()]!);
  progressPercent = computed(() => {
    const total = this.questions().length;
    return total === 0 ? 0 : Math.round(((this.currentIndex() + 1) / total) * 100);
  });

  qKey(q: EligibilityQuestion): string {
    return String(q.id);
  }

  constructor(private http: HttpClient) {
    this.loadQuestions();
  }

  private storageKey(): string {
    const userId = this.auth.currentUser()?.id || 'guest';
    return `eligibility_state_${userId}`;
  }

  private saveToLocal(answers: Record<string, string>, result: EligibilityResult | null): void {
    try {
      const key = this.storageKey();
      if (result) {
        localStorage.setItem(key, JSON.stringify({ answers, result, updatedAt: new Date().toISOString() }));
      } else {
        localStorage.setItem(key, JSON.stringify({ answers, result: null, updatedAt: new Date().toISOString() }));
      }
    } catch {}
  }

  private loadFromLocal(): { answers: Record<string, string>, result: EligibilityResult | null } | null {
    try {
      const raw = localStorage.getItem(this.storageKey());
      if (!raw) return null;
      const parsed = JSON.parse(raw);
      return { answers: parsed.answers || {}, result: parsed.result || null };
    } catch { return null; }
  }

  private clearLocal(): void {
    try { localStorage.removeItem(this.storageKey()); } catch {}
  }

  private restoreSavedState(): void {
    // For authenticated users, backend is source of truth (cross-device, survives logout/login per user).
    // For guests, use localStorage per "guest" key. Both are isolated by userId.
    if (this.auth.currentUser()) {
      this.http.get<any>(`${this.apiUrl}/state`).subscribe({
        next: (state) => {
          if (state && state.answers && state.result && state.answers.length > 0) {
            const ansMap: Record<string, string> = {};
            for (const a of state.answers) ansMap[String(a.questionId)] = a.answer;
            this.answers.set(ansMap);
            this.result.set(state.result as EligibilityResult);
            this.saveToLocal(ansMap, state.result as EligibilityResult);
          } else {
            const local = this.loadFromLocal();
            if (local && (Object.keys(local.answers).length > 0 || local.result)) {
              this.answers.set(local.answers);
              if (local.result) this.result.set(local.result);
            }
          }
        },
        error: () => {
          const local = this.loadFromLocal();
          if (local && (Object.keys(local.answers).length > 0 || local.result)) {
            this.answers.set(local.answers);
            if (local.result) this.result.set(local.result);
          }
        }
      });
      return;
    }
    const local = this.loadFromLocal();
    if (local && (Object.keys(local.answers).length > 0 || local.result)) {
      this.answers.set(local.answers);
      if (local.result) this.result.set(local.result);
    }
  }

  loadQuestions(): void {
    this.loading.set(true);
    this.error.set(null);
    this.http.get<EligibilityQuestion[]>(`${this.apiUrl}/questions`).subscribe({
      next: (qs) => {
        this.questions.set(qs);
        this.loading.set(false);
        // Restore per-user saved answers+result after questions are known
        this.restoreSavedState();
      },
      error: () => {
        this.error.set('Failed to load questions. Please try again later. / প্রশ্ন লোড করতে ব্যর্থ।');
        this.loading.set(false);
      },
    });
  }

  canProceed(): boolean {
    const q = this.currentQuestion();
    if (!q) return false;
    const val = this.answers()[String(q.id)];
    if (q.questionType === 'yesno') return val === 'yes' || val === 'no';
    if (q.questionType === 'number') {
      if (val === undefined || val === null || val === '') return false;
      const num = Number(val);
      return !isNaN(num) && this.withinRange(num, q);
    }
    return false;
  }

  isNumberOutOfRange(): boolean {
    const q = this.currentQuestion();
    if (!q || q.questionType !== 'number') return false;
    const val = this.answers()[String(q.id)];
    if (val === undefined || val === null || val === '') return false;
    const num = Number(val);
    return isNaN(num) || !this.withinRange(num, q);
  }

  private withinRange(num: number, q: EligibilityQuestion): boolean {
    if (q.minValue !== undefined && num < q.minValue) return false;
    if (q.maxValue !== undefined && num > q.maxValue) return false;
    return true;
  }

  rangeHint(q: EligibilityQuestion): string {
    if (q.minValue !== undefined && q.maxValue !== undefined) return `between ${q.minValue} and ${q.maxValue}`;
    if (q.minValue !== undefined) return `at least ${q.minValue}`;
    if (q.maxValue !== undefined) return `at most ${q.maxValue}`;
    return '';
  }

  next(): void {
    if (this.canProceed() && this.currentIndex() < this.questions().length - 1) {
      this.currentIndex.update((i) => i + 1);
    }
  }

  prev(): void {
    if (this.currentIndex() > 0) {
      this.currentIndex.update((i) => i - 1);
    }
  }

  submit(): void {
    if (!this.canProceed() || this.submitting()) return;
    this.submitting.set(true);
    this.error.set(null);

    const ans = this.answers();
    const answerPayload = this.questions().map(q => ({
      questionId: q.id,
      answer: String(ans[String(q.id)] ?? '')
    }));

    this.http.post<EligibilityResult>(`${this.apiUrl}/check`, answerPayload).pipe(
      retry({
        count: 3,
        delay: (error, retryCount) => {
          const status = (error as HttpErrorResponse)?.status ?? 0;
          if (status === 0 || status >= 500) {
            return timer(retryCount * 1500);
          }
          return throwError(() => error);
        }
      }),
    ).subscribe({
      next: (res) => {
        this.result.set(res);
        this.submitting.set(false);
        // Persist per-user so same user sees it after logout/login; isolated by userId (guest vs authenticated)
        this.saveToLocal(ans, res);
        // Backend already persists for authenticated users via POST /check, no extra call needed
      },
      error: () => {
        this.error.set('Failed to submit. Please try again later. / জমা দিতে ব্যর্থ। কিছুক্ষণ পর আবার চেষ্টা করুন।');
        this.submitting.set(false);
      },
    });
  }

  reset(): void {
    this.questions.set([]);
    this.answers.set({});
    this.currentIndex.set(0);
    this.result.set(null);
    this.error.set(null);
    this.clearLocal();
    // Also clear server-side per-user state if authenticated
    if (this.auth.currentUser()) {
      this.http.delete(`${this.apiUrl}/state`).subscribe({ next: () => {}, error: () => {} });
    }
    this.loadQuestions();
  }
}
