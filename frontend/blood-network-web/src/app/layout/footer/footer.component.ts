import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { RevealDirective } from '../../shared/directives/reveal.directive';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [RouterLink, MatIconModule, RevealDirective],
  template: `
    <footer class="footer">
      <div class="container footer-inner" appReveal>
        <div class="brand">
          <mat-icon class="brand-icon">water_drop</mat-icon>
          <div>
            <div class="brand-name">Blood Network <span>BD</span></div>
            <div class="brand-tag">Connecting donors with those in need.</div>
          </div>
        </div>
        <div class="links">
          <a routerLink="/find-blood">Find Blood</a>
          <a routerLink="/request-blood">Need Blood</a>
          <a routerLink="/register">Become a Donor</a>
          <a routerLink="/about">About</a>
          <a routerLink="/login">Login</a>
        </div>
      </div>
      <div class="container bottom">
        <span>&copy; 2026 Blood Network Bangladesh. All rights reserved.</span>
        <span class="disclaimer">
          Donor eligibility, blood compatibility, testing and transfusion decisions must be confirmed
          by qualified medical professionals.
        </span>
      </div>
    </footer>
  `,
  styles: [`
    .footer {
      background: var(--bgn-surface);
      border-top: 1px solid var(--bgn-border);
      padding: 36px 0 24px;
      margin-top: auto;
    }
    .footer-inner {
      display: flex; justify-content: space-between; gap: 24px; flex-wrap: wrap;
      padding-bottom: 20px; border-bottom: 1px solid var(--bgn-border);
    }
    .brand { display: flex; gap: 12px; align-items: center; }
    .brand-icon { color: var(--bgn-primary); font-size: 30px; height: 30px; width: 30px; transition: transform 0.3s ease-out; }
    .brand:hover .brand-icon { transform: scale(1.15) rotate(-8deg); }
    .brand-name { font-weight: 700; font-size: 1.05rem; }
    .brand-name span { color: var(--bgn-primary); }
    .brand-tag { color: var(--bgn-text-muted); font-size: 0.85rem; }
    .links { display: flex; gap: 22px; flex-wrap: wrap; align-items: center; }
    .links a {
      position: relative;
      color: var(--bgn-text-muted); text-decoration: none; font-size: 0.92rem;
      transition: color 0.2s ease;
    }
    .links a::after {
      content: ''; position: absolute; left: 0; bottom: -3px; width: 0; height: 1.5px;
      background: var(--bgn-primary); transition: width 0.22s ease-out;
    }
    .links a:hover { color: var(--bgn-primary); }
    .links a:hover::after { width: 100%; }
    .bottom {
      display: flex; justify-content: space-between; gap: 16px; flex-wrap: wrap;
      padding-top: 18px; font-size: 0.8rem; color: var(--bgn-text-faint);
    }
    .disclaimer { max-width: 560px; }
  `]
})
export class FooterComponent {}
