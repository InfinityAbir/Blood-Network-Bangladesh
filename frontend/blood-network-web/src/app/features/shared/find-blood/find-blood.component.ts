import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-find-blood',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 900px; margin: 0 auto;">
      <h1>Find Blood Donors</h1>
      <p>Search for available donors by blood group and location.</p>
      <p><em>Search functionality will be implemented in Phase C.</em></p>
    </main>
    <app-footer />
  `
})
export class FindBloodComponent {}
