import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  template: `
    <footer class="footer">
      <p>&copy; 2026 Blood Network Bangladesh. All rights reserved.</p>
      <p class="disclaimer">
        This platform helps connect blood donors and recipients. Donor eligibility, blood compatibility,
        testing and transfusion decisions must be confirmed by qualified medical professionals.
      </p>
    </footer>
  `,
  styles: [`
    .footer {
      background: #f5f5f5;
      padding: 20px;
      text-align: center;
      margin-top: auto;
    }
    .disclaimer {
      font-size: 0.85em;
      color: #666;
      max-width: 600px;
      margin: 10px auto 0;
    }
  `]
})
export class FooterComponent {}
