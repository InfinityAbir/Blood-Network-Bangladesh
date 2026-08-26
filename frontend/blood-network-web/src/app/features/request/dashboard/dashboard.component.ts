import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-requester-dashboard',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 900px; margin: 0 auto;">
      <h1>Requester Dashboard</h1>
      <p><em>Requester dashboard will be implemented in Phase D.</em></p>
    </main>
    <app-footer />
  `
})
export class RequesterDashboardComponent {}
