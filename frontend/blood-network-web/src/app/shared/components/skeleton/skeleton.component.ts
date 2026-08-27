import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-skeleton',
  standalone: true,
  imports: [CommonModule],
  template: `
    @if (type === 'line') {
      <div class="sk-line" [style.width]="width" [style.height]="height"></div>
    } @else if (type === 'circle') {
      <div class="sk-circle" [style.width]="width" [style.height]="width"></div>
    } @else if (type === 'rect') {
      <div class="sk-rect" [style.width]="width" [style.height]="height"></div>
    }
  `,
  styles: [`
    :host { display: contents; }
    .sk-line, .sk-circle, .sk-rect {
      background: linear-gradient(90deg, var(--bgn-skeleton-from, #e0e0e0) 25%, var(--bgn-skeleton-mid, #f0f0f0) 50%, var(--bgn-skeleton-from, #e0e0e0) 75%);
      background-size: 200% 100%;
      animation: shimmer 1.5s ease-in-out infinite;
      border-radius: 4px;
    }
    .sk-circle { border-radius: 50%; }
    .sk-rect { border-radius: 8px; }
    @keyframes shimmer {
      0% { background-position: 200% 0; }
      100% { background-position: -200% 0; }
    }
  `]
})
export class SkeletonComponent {
  @Input() type: 'line' | 'circle' | 'rect' = 'line';
  @Input() width = '100%';
  @Input() height = '16px';
}
