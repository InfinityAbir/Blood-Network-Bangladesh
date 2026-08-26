import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-request-blood',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 600px; margin: 0 auto;">
      <h1>Request Blood</h1>
      <p><em>Blood request form will be implemented in Phase D.</em></p>
    </main>
    <app-footer />
  `
})
export class RequestBloodComponent {}
