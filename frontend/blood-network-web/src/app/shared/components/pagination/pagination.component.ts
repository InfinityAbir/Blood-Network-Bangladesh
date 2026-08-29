import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule, FormsModule, MatIconModule, MatButtonModule, MatSelectModule, MatFormFieldModule],
  template: `
    <div class="pagination-bar">
      <div class="pagination-info">
        Showing {{ start }} to {{ end }} of {{ total }} {{ label }}
      </div>
      <div class="pagination-controls">
        <button mat-icon-button (click)="goFirst()" [disabled]="page <= 1" class="nav-btn" aria-label="First page">
          <mat-icon>first_page</mat-icon>
        </button>
        <button mat-icon-button (click)="goPrev()" [disabled]="page <= 1" class="nav-btn" aria-label="Previous page">
          <mat-icon>chevron_left</mat-icon>
        </button>
        <span class="page-pill">{{ page }}</span>
        <button mat-icon-button (click)="goNext()" [disabled]="page >= totalPages" class="nav-btn" aria-label="Next page">
          <mat-icon>chevron_right</mat-icon>
        </button>
        <button mat-icon-button (click)="goLast()" [disabled]="page >= totalPages" class="nav-btn" aria-label="Last page">
          <mat-icon>last_page</mat-icon>
        </button>
      </div>
      <div class="page-size">
        <mat-form-field appearance="outline" class="page-size-field">
          <mat-select [value]="pageSize" (selectionChange)="onPageSizeChange($event.value)">
            <mat-option [value]="10">10</mat-option>
            <mat-option [value]="20">20</mat-option>
            <mat-option [value]="50">50</mat-option>
            <mat-option [value]="100">100</mat-option>
          </mat-select>
        </mat-form-field>
      </div>
    </div>
  `,
  styles: [`
    .pagination-bar {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 16px;
      padding: 12px 16px;
      background: var(--bgn-surface, #fff);
      border-top: 1px solid var(--bgn-border, #e0e0e0);
      flex-wrap: wrap;
      font-size: 14px;
      color: var(--bgn-text-muted, #666);
      margin-top: 12px;
      border-radius: 8px;
    }
    .pagination-info {
      font-size: 14px;
      white-space: nowrap;
    }
    .pagination-controls {
      display: flex;
      align-items: center;
      gap: 4px;
    }
    .nav-btn {
      width: 32px;
      height: 32px;
      color: var(--bgn-text-muted, #666);
    }
    .nav-btn:disabled {
      opacity: 0.35;
    }
    .page-pill {
      display: inline-flex;
      align-items: center;
      justify-content: center;
      min-width: 32px;
      height: 32px;
      padding: 0 8px;
      border-radius: 999px;
      background: rgba(229, 57, 53, 0.08);
      color: var(--bgn-primary, #e53935);
      font-weight: 600;
      font-size: 14px;
      border: 1px solid rgba(229, 57, 53, 0.15);
    }
    .page-size-field {
      width: 80px;
    }
    .page-size-field ::ng-deep .mat-mdc-form-field-wrapper {
      padding-bottom: 0;
    }
    .page-size-field ::ng-deep .mat-mdc-text-field-wrapper {
      height: 36px;
    }
    .page-size-field ::ng-deep .mat-mdc-form-field-infix {
      padding-top: 8px;
      padding-bottom: 8px;
      min-height: 36px;
    }
    @media (max-width: 600px) {
      .pagination-bar {
        flex-direction: column;
        gap: 8px;
      }
      .pagination-info {
        order: 1;
      }
      .pagination-controls {
        order: 2;
      }
      .page-size {
        order: 3;
      }
    }
  `]
})
export class PaginationComponent {
  @Input() page = 1;
  @Input() pageSize = 10;
  @Input() total = 0;
  @Input() label = 'items';
  @Output() pageChange = new EventEmitter<number>();
  @Output() pageSizeChange = new EventEmitter<number>();

  get totalPages(): number {
    if (this.total <= 0) return 1;
    return Math.ceil(this.total / this.pageSize);
  }

  get start(): number {
    if (this.total === 0) return 0;
    return (this.page - 1) * this.pageSize + 1;
  }

  get end(): number {
    if (this.total === 0) return 0;
    return Math.min(this.page * this.pageSize, this.total);
  }

  goFirst(): void {
    if (this.page > 1) this.pageChange.emit(1);
  }

  goPrev(): void {
    if (this.page > 1) this.pageChange.emit(this.page - 1);
  }

  goNext(): void {
    if (this.page < this.totalPages) this.pageChange.emit(this.page + 1);
  }

  goLast(): void {
    if (this.page < this.totalPages) this.pageChange.emit(this.totalPages);
  }

  onPageSizeChange(size: number): void {
    this.pageSizeChange.emit(size);
  }
}
