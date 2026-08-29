import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-avatar',
  standalone: true,
  imports: [MatIconModule],
  template: `
    <div class="bgn-avatar" [style.width.px]="size" [style.height.px]="size">
      @if (photoUrl && !imgError) {
        <img [src]="photoUrl" (error)="imgError = true" alt="Profile photo" />
      } @else {
        <mat-icon [style.font-size.px]="size * 0.5" [style.width.px]="size * 0.5" [style.height.px]="size * 0.5">person</mat-icon>
      }
    </div>
  `,
  styles: [`
    .bgn-avatar {
      border-radius: 50%;
      background: color-mix(in srgb, var(--bgn-primary) 12%, transparent);
      display: flex;
      align-items: center;
      justify-content: center;
      overflow: hidden;
      flex: none;
    }
    .bgn-avatar img { width: 100%; height: 100%; object-fit: cover; }
    .bgn-avatar mat-icon { color: var(--bgn-primary); }
  `]
})
export class AvatarComponent {
  @Input() size = 64;

  imgError = false;
  private _photoUrl: string | null | undefined;

  @Input()
  set photoUrl(value: string | null | undefined) {
    this._photoUrl = value;
    this.imgError = false;
  }
  get photoUrl(): string | null | undefined {
    return this._photoUrl;
  }
}
