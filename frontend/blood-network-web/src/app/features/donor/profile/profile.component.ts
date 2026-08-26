import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-donor-profile',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 600px; margin: 0 auto;">
      <h1>Donor Profile</h1>
      <p><em>Donor profile management will be implemented in Phase C.</em></p>
    </main>
    <app-footer />
  `
})
export class DonorProfileComponent {}
