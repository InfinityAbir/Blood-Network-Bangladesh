import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [RouterLink, MatButtonModule, MatCardModule, MatIconModule, HeaderComponent, FooterComponent],
  template: `
    <app-header />

    <main class="landing">
      <!-- HERO -->
      <section class="hero">
        <div class="hero-glow"></div>
        <div class="container hero-inner">
          <span class="badge">
            <mat-icon>verified</mat-icon> Trusted blood donor network across Bangladesh
          </span>
          <h1>Every drop counts.<br /><span class="hero-accent">Save a life today.</span></h1>
          <p class="tagline">
            Blood Network Bangladesh connects verified donors with patients in need —
            fast, safe, and powered by smart blood-group matching.
          </p>
          <div class="cta-buttons">
            <a mat-flat-button class="cta cta-need" routerLink="/request-blood">
              <mat-icon>favorite</mat-icon> I Need Blood
            </a>
            <a mat-flat-button class="cta cta-donate" routerLink="/register">
              <mat-icon>volunteer_activism</mat-icon> I Want to Donate
            </a>
          </div>
          <a mat-button class="ghost-link" routerLink="/find-blood">
            <mat-icon>search</mat-icon> Find a donor near you
          </a>
        </div>
      </section>

      <!-- STATS -->
      <section class="stats container">
        <div class="stat">
          <div class="stat-num">8</div>
          <div class="stat-label">Divisions covered</div>
        </div>
        <div class="stat">
          <div class="stat-num">55+</div>
          <div class="stat-label">Districts</div>
        </div>
        <div class="stat">
          <div class="stat-num">8</div>
          <div class="stat-label">Blood groups matched</div>
        </div>
        <div class="stat">
          <div class="stat-num">24/7</div>
          <div class="stat-label">Emergency requests</div>
        </div>
      </section>

      <!-- HOW IT WORKS -->
      <section class="how container">
        <div class="section-head">
          <h2>How it works</h2>
          <p>From urgent request to a confirmed donor — in three simple steps.</p>
        </div>
        <div class="steps">
          <mat-card class="step">
            <div class="step-icon"><mat-icon>edit_note</mat-icon></div>
            <h3>1. Create a request</h3>
            <p>Submit a blood request with your location, blood group and urgency.</p>
          </mat-card>
          <mat-card class="step">
            <div class="step-icon"><mat-icon>auto_awesome</mat-icon></div>
            <h3>2. Get matched</h3>
            <p>Our engine finds compatible, available donors closest to you.</p>
          </mat-card>
          <mat-card class="step">
            <div class="step-icon"><mat-icon>handshake</mat-icon></div>
            <h3>3. Connect</h3>
            <p>Donors accept and coordinate the donation directly with you.</p>
          </mat-card>
        </div>
      </section>

      <!-- FEATURES -->
      <section class="features container">
        <div class="feature">
          <mat-icon>smart_toy</mat-icon>
          <h3>Smart matching</h3>
          <p>Blood-group compatibility, distance and availability scored in real time.</p>
        </div>
        <div class="feature">
          <mat-icon>shield_check</mat-icon>
          <h3>Verified donors</h3>
          <p>Profiles are reviewed by admins so recipients can trust who they meet.</p>
        </div>
        <div class="feature">
          <mat-icon>notifications_active</mat-icon>
          <h3>Instant alerts</h3>
          <p>Matched donors are notified immediately to respond to your request.</p>
        </div>
        <div class="feature">
          <mat-icon>location_on</mat-icon>
          <h3>Location aware</h3>
          <p>Division, district and upazila based search across Bangladesh.</p>
        </div>
      </section>

      <!-- CTA BANNER -->
      <section class="cta-banner container">
        <div class="cta-banner-inner">
          <div>
            <h2>Ready to make a difference?</h2>
            <p>Join thousands of donors saving lives every day.</p>
          </div>
          <a mat-flat-button class="cta cta-donate" routerLink="/register">
            <mat-icon>volunteer_activism</mat-icon> Become a Donor
          </a>
        </div>
      </section>

      <section class="disclaimer container">
        <mat-icon>health_and_safety</mat-icon>
        <p>
          <strong>Important:</strong> This platform helps connect blood donors and recipients.
          Donor eligibility, blood compatibility, testing and transfusion decisions must be confirmed
          by qualified medical professionals or the relevant blood collection service.
        </p>
      </section>
    </main>

    <app-footer />
  `,
  styles: [`
    .landing { display: block; }

    /* HERO */
    .hero {
      position: relative;
      overflow: hidden;
      background: var(--bgn-header-bg);
      color: #fff;
      padding: 96px 0 110px;
    }
    .hero-glow {
      position: absolute; inset: 0;
      background: radial-gradient(circle at 20% 20%, rgba(255,255,255,0.18), transparent 45%),
                  radial-gradient(circle at 85% 80%, rgba(255,255,255,0.12), transparent 40%);
      pointer-events: none;
    }
    .hero-inner { position: relative; text-align: center; }
    .badge {
      display: inline-flex; align-items: center; gap: 6px;
      background: rgba(255,255,255,0.15);
      border: 1px solid rgba(255,255,255,0.25);
      padding: 6px 14px; border-radius: var(--bgn-radius-pill);
      font-size: 0.85rem; margin-bottom: 22px;
      backdrop-filter: blur(4px);
    }
    .badge mat-icon { font-size: 18px; height: 18px; width: 18px; }
    .hero h1 { font-size: clamp(2.2rem, 5vw, 3.6rem); line-height: 1.1; margin: 0 0 16px; font-weight: 800; }
    .hero-accent { color: #ffd2d2; }
    .tagline { font-size: 1.15rem; max-width: 620px; margin: 0 auto 32px; opacity: 0.94; }
    .cta-buttons { display: flex; gap: 16px; justify-content: center; flex-wrap: wrap; margin-bottom: 18px; }
    .cta { height: 52px !important; border-radius: var(--bgn-radius-pill) !important; font-size: 1rem !important; font-weight: 600 !important; padding: 0 28px !important; }
    .cta mat-icon { margin-right: 6px; }
    .cta-need { background: #fff !important; color: #b71c1c !important; }
    .cta-donate { background: rgba(255,255,255,0.16) !important; color: #fff !important; border: 1px solid rgba(255,255,255,0.4) !important; }
    .ghost-link { color: #fff !important; opacity: 0.9; }

    /* STATS */
    .stats {
      display: grid; grid-template-columns: repeat(4, 1fr); gap: 16px;
      margin-top: -56px; position: relative; z-index: 2;
    }
    .stat {
      background: var(--bgn-surface); border: 1px solid var(--bgn-border);
      border-radius: var(--bgn-radius-md); padding: 22px 16px; text-align: center;
      box-shadow: var(--bgn-shadow-md);
    }
    .stat-num { font-size: 2rem; font-weight: 800; color: var(--bgn-primary); }
    .stat-label { color: var(--bgn-text-muted); font-size: 0.9rem; margin-top: 4px; }

    /* SECTIONS */
    .section-head { text-align: center; margin: 72px 0 32px; }
    .section-head h2 { font-size: 2rem; margin: 0 0 8px; }
    .section-head p { color: var(--bgn-text-muted); margin: 0; }

    .steps { display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 20px; }
    .step {
      padding: 28px 24px !important; text-align: center;
      border-radius: var(--bgn-radius-md) !important;
      border: 1px solid var(--bgn-border) !important;
      transition: transform 0.2s ease, box-shadow 0.2s ease;
    }
    .step:hover { transform: translateY(-6px); box-shadow: var(--bgn-shadow-lg); }
    .step-icon {
      width: 56px; height: 56px; border-radius: 50%; margin: 0 auto 16px;
      display: grid; place-items: center;
      background: var(--bgn-gradient); color: #fff;
    }
    .step-icon mat-icon { font-size: 28px; height: 28px; width: 28px; }
    .step h3 { margin: 0 0 8px; font-size: 1.15rem; }
    .step p { color: var(--bgn-text-muted); margin: 0; font-size: 0.95rem; }

    .features {
      display: grid; grid-template-columns: repeat(auto-fit, minmax(220px, 1fr)); gap: 18px;
      margin-top: 56px;
    }
    .feature {
      background: var(--bgn-surface); border: 1px solid var(--bgn-border);
      border-radius: var(--bgn-radius-md); padding: 24px;
    }
    .feature mat-icon { color: var(--bgn-primary); font-size: 30px; height: 30px; width: 30px; margin-bottom: 10px; }
    .feature h3 { margin: 0 0 6px; font-size: 1.05rem; }
    .feature p { color: var(--bgn-text-muted); margin: 0; font-size: 0.92rem; }

    .cta-banner { margin-top: 64px; }
    .cta-banner-inner {
      background: var(--bgn-surface-2); border: 1px solid var(--bgn-border);
      border-radius: var(--bgn-radius-lg); padding: 36px 40px;
      display: flex; align-items: center; justify-content: space-between; gap: 20px; flex-wrap: wrap;
    }
    .cta-banner h2 { margin: 0 0 4px; }
    .cta-banner p { margin: 0; color: var(--bgn-text-muted); }

    .disclaimer {
      display: flex; gap: 12px; align-items: flex-start;
      margin-top: 48px; margin-bottom: 56px;
      background: var(--bgn-surface-2); border: 1px solid var(--bgn-border);
      border-left: 4px solid var(--bgn-warning);
      border-radius: var(--bgn-radius-md); padding: 18px 22px;
    }
    .disclaimer mat-icon { color: var(--bgn-warning); flex-shrink: 0; margin-top: 2px; }
    .disclaimer p { margin: 0; font-size: 0.9rem; color: var(--bgn-text-muted); }

    @media (max-width: 720px) {
      .stats { grid-template-columns: repeat(2, 1fr); }
      .cta-banner-inner { flex-direction: column; text-align: center; align-items: stretch; }
    }
  `]
})
export class LandingComponent {}
