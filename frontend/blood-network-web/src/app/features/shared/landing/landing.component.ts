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
      <section class="hero">
        <h1>Blood Network Bangladesh</h1>
        <p class="tagline">Connecting donors with those in need, quickly and safely.</p>
        <div class="cta-buttons">
          <a mat-raised-button color="warn" routerLink="/request-blood" class="cta-btn">
            I NEED BLOOD
          </a>
          <a mat-raised-button color="primary" routerLink="/register" class="cta-btn">
            I WANT TO DONATE
          </a>
        </div>
        <a mat-button routerLink="/find-blood">Find a Donor</a>
      </section>

      <section class="how-it-works">
        <h2>How It Works</h2>
        <div class="steps">
          <mat-card>
            <mat-card-header>
              <mat-card-title>1. Create Request</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              Submit a blood request with your location and requirements.
            </mat-card-content>
          </mat-card>
          <mat-card>
            <mat-card-header>
              <mat-card-title>2. Get Matched</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              Our system finds compatible, available donors nearby.
            </mat-card-content>
          </mat-card>
          <mat-card>
            <mat-card-header>
              <mat-card-title>3. Connect</mat-card-title>
            </mat-card-header>
            <mat-card-content>
              Donors accept and coordinate with you directly.
            </mat-card-content>
          </mat-card>
        </div>
      </section>

      <section class="disclaimer">
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
    .hero {
      text-align: center;
      padding: 60px 20px;
      background: linear-gradient(135deg, #e53935 0%, #b71c1c 100%);
      color: white;
    }
    .hero h1 { font-size: 2.5em; margin-bottom: 10px; }
    .tagline { font-size: 1.2em; margin-bottom: 30px; opacity: 0.9; }
    .cta-buttons { display: flex; gap: 20px; justify-content: center; flex-wrap: wrap; margin-bottom: 20px; }
    .cta-btn { font-size: 1.1em; padding: 10px 30px; }
    .how-it-works { padding: 40px 20px; text-align: center; }
    .how-it-works h2 { margin-bottom: 30px; }
    .steps { display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 20px; max-width: 900px; margin: 0 auto; }
    .disclaimer { padding: 20px; text-align: center; background: #fff3e0; margin: 20px; border-radius: 8px; }
    .disclaimer p { max-width: 700px; margin: 0 auto; font-size: 0.9em; color: #e65100; }
  `]
})
export class LandingComponent {}
