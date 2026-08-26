import { Component } from '@angular/core';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  template: `
    <app-header />
    <main style="padding: 20px; max-width: 400px; margin: 0 auto;">
      <h1>Login</h1>
      <p><em>Login form will be implemented in Phase B.</em></p>
    </main>
    <app-footer />
  `
})
export class LoginComponent {}
