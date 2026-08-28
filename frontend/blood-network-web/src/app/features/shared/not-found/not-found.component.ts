import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="not-found-wrap">
      <div class="not-found-card bgn-fade-up" style="--i:0">
        <svg class="drop-icon bgn-float" viewBox="0 0 24 24" width="56" height="56" fill="currentColor" aria-hidden="true">
          <path d="M12 2.5s7 5.8 7 11.2A7 7 0 1 1 5 13.7C5 8.3 12 2.5 12 2.5z"/>
        </svg>
        <h1 class="code">404</h1>
        <p class="title">Page not found</p>
        <p class="subtitle">The page you are looking for doesn't exist or was moved.</p>
        <a routerLink="/" class="home-btn bgn-press">Go to homepage</a>
      </div>
    </div>
  `,
  styles: [`
    .not-found-wrap {
      display: flex;
      align-items: center;
      justify-content: center;
      min-height: 70vh;
      text-align: center;
      padding: 24px;
      background: var(--bgn-bg);
    }
    .not-found-card {
      display: flex;
      flex-direction: column;
      align-items: center;
    }
    .drop-icon {
      color: var(--bgn-primary);
      margin-bottom: 8px;
    }
    .code {
      font-size: 72px;
      margin: 0;
      font-weight: 800;
      background: var(--bgn-gradient);
      -webkit-background-clip: text;
      background-clip: text;
      -webkit-text-fill-color: transparent;
    }
    .title {
      font-size: 18px;
      color: var(--bgn-text);
      margin: 12px 0 8px;
      font-weight: 500;
    }
    .subtitle {
      color: var(--bgn-text-muted);
      margin: 0 0 28px;
      max-width: 360px;
    }
    .home-btn {
      display: inline-block;
      padding: 12px 28px;
      background: var(--bgn-gradient);
      color: #fff;
      border-radius: var(--bgn-radius-pill);
      text-decoration: none;
      font-weight: 600;
      box-shadow: var(--bgn-shadow-md);
      transition: transform 0.2s ease-out, box-shadow 0.2s ease-out;
    }
    .home-btn:hover {
      transform: translateY(-2px);
      box-shadow: var(--bgn-shadow-lg);
    }
  `]
})
export class NotFoundComponent {}
