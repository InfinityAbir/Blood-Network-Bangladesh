import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [RouterLink, MatButtonModule, MatCardModule, HeaderComponent, FooterComponent],
  template: `
    <app-header />

    <main class="landing">
      <!-- HERO -->
      <section class="hero">
        <div class="hero-glow"></div>
        <div class="container hero-inner">
          <span class="badge">
            <svg class="bgn-icon" viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"/><path d="M9 12l2 2 4-4"/></svg>
            Trusted blood donor network across Bangladesh
          </span>
          <h1>Every drop counts.<br /><span class="hero-accent">Save a life today.</span></h1>
          <p class="tagline">
            Blood Network Bangladesh connects verified donors with patients in need —
            fast, safe, and powered by smart blood-group matching.
          </p>
          <div class="cta-buttons">
            <a mat-flat-button class="cta cta-need" routerLink="/request-blood">
              <svg class="bgn-icon" viewBox="0 0 24 24" width="20" height="20" fill="currentColor" aria-hidden="true"><path d="M12 21s-6.5-4.2-8.2-8.2A4.6 4.6 0 0 1 7 6a3.9 3.9 0 0 1 5 2 3.9 3.9 0 0 1 5-2 4.6 4.6 0 0 1 3.2 6.8C18.5 16.8 12 21 12 21z"/></svg>
              I Need Blood
            </a>
            <a mat-flat-button class="cta cta-donate" routerLink="/register">
              <svg class="bgn-icon" viewBox="0 0 24 24" width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M19 8v6M22 11h-6"/></svg>
              I Want to Donate
            </a>
          </div>
          <a mat-button class="ghost-link" routerLink="/find-blood">
            <svg class="bgn-icon" viewBox="0 0 24 24" width="18" height="18" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="11" cy="11" r="7"/><path d="M20 20l-3.5-3.5"/></svg>
            Find a donor near you
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
            <div class="step-icon" aria-hidden="true">
              <svg viewBox="0 0 24 24" width="28" height="28" fill="none" stroke="white" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round"><path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"/><path d="M18.5 2.5a2.12 2.12 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"/></svg>
            </div>
            <h3>1. Create a request</h3>
            <p>Submit a blood request with your location, blood group and urgency.</p>
          </mat-card>
          <mat-card class="step">
            <div class="step-icon" aria-hidden="true">
              <svg viewBox="0 0 24 24" width="28" height="28" fill="none" stroke="white" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round"><path d="M12 3l1.7 3.5L17 8l-3.3 2 0.7 4L12 12l-2.4 2 0.7-4L7 8l3.3-1.5z"/><path d="M5 16l0.8 1.6L7.5 18l-1.7 1 0.4 2L5 20l-1.2 1 .4-2L2.5 18l1.7-.4z"/><path d="M19 13l0.8 1.6 1.7.4-1.3 1 0.3 1.8L19 16.5l-1.5 1.3.3-1.8-1.3-1 1.7-.4z"/></svg>
            </div>
            <h3>2. Get matched</h3>
            <p>Our engine finds compatible, available donors closest to you.</p>
          </mat-card>
          <mat-card class="step">
            <div class="step-icon" aria-hidden="true">
              <svg viewBox="0 0 24 24" width="28" height="28" fill="none" stroke="white" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round"><path d="M11 15h2"/><path d="M12 12a3 3 0 0 0-3-3H5a3 3 0 0 0 0 6h3"/><path d="M12 12a3 3 0 0 1 3-3h4a3 3 0 0 1 0 6h-4"/><path d="M8 9V7a2 2 0 0 1 4 0v2"/><path d="M16 9V7a2 2 0 0 1 4 0v2"/></svg>
            </div>
            <h3>3. Connect</h3>
            <p>Donors accept and coordinate the donation directly with you.</p>
          </mat-card>
        </div>
      </section>

      <!-- FEATURES -->
      <section class="features container">
        <div class="feature">
          <svg class="feat-icon" viewBox="0 0 24 24" width="30" height="30" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><rect x="4" y="4" width="16" height="16" rx="2"/><path d="M9 9h6M9 12h6M9 15h6"/><circle cx="15" cy="8.5" r="0.5" fill="currentColor" stroke="none"/><circle cx="15" cy="11.5" r="0.5" fill="currentColor" stroke="none"/><circle cx="15" cy="14.5" r="0.5" fill="currentColor" stroke="none"/></svg>
          <h3>Smart matching</h3>
          <p>Blood-group compatibility, distance and availability scored in real time.</p>
        </div>
        <div class="feature">
          <svg class="feat-icon" viewBox="0 0 24 24" width="30" height="30" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"/><path d="M9 12l2 2 4-4"/></svg>
          <h3>Verified donors</h3>
          <p>Profiles are reviewed by admins so recipients can trust who they meet.</p>
        </div>
        <div class="feature">
          <svg class="feat-icon" viewBox="0 0 24 24" width="30" height="30" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M6 8a6 6 0 0 1 12 0c0 7-6 11-6 11s-6-4-6-11"/><path d="M10.3 21a1.9 1.9 0 0 0 3.4 0"/><path d="M12 11v-1"/><path d="M12 4v1"/></svg>
          <h3>Instant alerts</h3>
          <p>Matched donors are notified immediately to respond to your request.</p>
        </div>
        <div class="feature">
          <svg class="feat-icon" viewBox="0 0 24 24" width="30" height="30" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M12 21s-7-4.5-7-10a7 7 0 0 1 14 0c0 5.5-7 10-7 10z"/><circle cx="12" cy="11" r="2.5"/></svg>
          <h3>Location aware</h3>
          <p>Division, district and upazila based search across Bangladesh.</p>
        </div>
        <a class="feature feature-link" routerLink="/eligibility">
          <svg class="feat-icon" viewBox="0 0 24 24" width="30" height="30" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M9 11l3 3L22 4"/><path d="M21 12v7a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h11"/></svg>
          <h3>Eligibility Check / যোগ্যতা পরীক্ষা</h3>
          <p>Check if you are eligible to donate blood with our self-assessment tool.</p>
        </a>
      </section>

      <!-- CTA BANNER -->
      <section class="cta-banner container">
        <div class="cta-banner-inner">
          <div>
            <h2>Ready to make a difference?</h2>
            <p>Join thousands of donors saving lives every day.</p>
          </div>
          <a mat-flat-button class="cta cta-donate" routerLink="/register">
            <svg class="bgn-icon" viewBox="0 0 24 24" width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M19 8v6M22 11h-6"/></svg>
            Become a Donor
          </a>
        </div>
      </section>

      <section class="disclaimer container">
        <svg viewBox="0 0 24 24" width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.9" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true" style="color:var(--bgn-warning);flex-shrink:0;margin-top:2px"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"/><path d="M12 8v6"/><circle cx="12" cy="17" r="1" fill="currentColor" stroke="none"/></svg>
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
    .bgn-icon { flex-shrink: 0; }
    .hero h1 { font-size: clamp(2.2rem, 5vw, 3.6rem); line-height: 1.1; margin: 0 0 16px; font-weight: 800; }
    .hero-accent { color: #ffd2d2; }
    .tagline { font-size: 1.15rem; max-width: 620px; margin: 0 auto 32px; opacity: 0.94; }
    .cta-buttons { display: flex; gap: 16px; justify-content: center; flex-wrap: wrap; margin-bottom: 18px; align-items: center; }
    .cta { height: 52px !important; border-radius: var(--bgn-radius-pill) !important; font-size: 1rem !important; font-weight: 600 !important; padding: 0 28px !important; white-space: nowrap !important; }
    .cta .mdc-button__label { display: inline-flex !important; flex-direction: row !important; flex-wrap: nowrap !important; align-items: center !important; justify-content: center !important; gap: 8px !important; line-height: 1 !important; white-space: nowrap !important; }
    .cta .bgn-icon { display: inline-block; flex-shrink: 0; vertical-align: middle; }
    .cta-need { background: #fff !important; color: #b71c1c !important; }
    .cta-donate { background: rgba(255,255,255,0.16) !important; color: #fff !important; border: 1px solid rgba(255,255,255,0.4) !important; }
    .ghost-link { color: #fff !important; opacity: 1 !important; font-weight: 500 !important; background: rgba(255,255,255,0.14) !important; border: 1px solid rgba(255,255,255,0.28) !important; border-radius: var(--bgn-radius-pill) !important; backdrop-filter: blur(4px); }
    .ghost-link:hover { background: rgba(255,255,255,0.22) !important; }
    .ghost-link .mdc-button__label { display: inline-flex !important; flex-direction: row !important; flex-wrap: nowrap !important; align-items: center !important; gap: 6px !important; white-space: nowrap !important; }

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
    .feat-icon { color: var(--bgn-primary); margin-bottom: 10px; display: block; }
    .feature h3 { margin: 0 0 6px; font-size: 1.05rem; }
    .feature p { color: var(--bgn-text-muted); margin: 0; font-size: 0.92rem; }
    .feature-link {
      text-decoration: none;
      cursor: pointer;
      transition: transform 0.2s ease, box-shadow 0.2s ease;
    }
    .feature-link:hover { transform: translateY(-4px); box-shadow: var(--bgn-shadow-md); }

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
    .disclaimer p { margin: 0; font-size: 0.9rem; color: var(--bgn-text-muted); }

    @media (max-width: 720px) {
      .stats { grid-template-columns: repeat(2, 1fr); }
      .cta-banner-inner { flex-direction: column; text-align: center; align-items: stretch; }
    }
  `]
})
export class LandingComponent {}
