import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, MatToolbarModule, MatButtonModule],
  template: `
    <mat-toolbar color="primary">
      <a routerLink="/" class="logo">Blood Network BD</a>
      <span class="spacer"></span>
      <a mat-button routerLink="/find-blood">Find Blood</a>
      <a mat-button routerLink="/request-blood">Need Blood</a>
      @if (authService.isAuthenticated()) {
        <a mat-button routerLink="/donor/dashboard">Dashboard</a>
        <button mat-button (click)="authService.logout()">Logout</button>
      } @else {
        <a mat-button routerLink="/login">Login</a>
        <a mat-raised-button color="accent" routerLink="/register">Register</a>
      }
    </mat-toolbar>
  `,
  styles: [`
    .logo { text-decoration: none; color: white; font-weight: bold; font-size: 1.2em; }
    .spacer { flex: 1 1 auto; }
  `]
})
export class HeaderComponent {
  constructor(public authService: AuthService) {}
}
