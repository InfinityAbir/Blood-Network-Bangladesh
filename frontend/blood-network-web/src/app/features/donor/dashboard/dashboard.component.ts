import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-donor-dashboard',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 900px; margin: 0 auto;">
      <h1>Donor Dashboard</h1>
      <p><em>Donor dashboard will be implemented in Phase C.</em></p>
    </main>
    <app-footer />
  `
})
export class DonorDashboardComponent {}
