import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 500px; margin: 0 auto;">
      <h1>Register</h1>
      <p><em>Registration form will be implemented in Phase B.</em></p>
    </main>
    <app-footer />
  `
})
export class RegisterComponent {}
