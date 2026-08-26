import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 1200px; margin: 0 auto;">
      <h1>Admin Dashboard</h1>
      <p><em>Admin dashboard will be implemented in Phase G.</em></p>
    </main>
    <app-footer />
  `
})
export class AdminDashboardComponent {}
