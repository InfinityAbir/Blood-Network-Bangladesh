import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div style="display:flex;align-items:center;justify-content:center;min-height:70vh;text-align:center;padding:24px;font-family:sans-serif;">
      <div>
        <h1 style="font-size:72px;margin:0;color:#e53935;">404</h1>
        <p style="font-size:18px;color:#555;margin:12px 0 20px;">Page not found</p>
        <p style="color:#777;margin-bottom:24px;">The page you are looking for doesn't exist or was moved.</p>
        <a routerLink="/" style="display:inline-block;padding:10px 22px;background:#e53935;color:#fff;border-radius:8px;text-decoration:none;">Go to homepage</a>
      </div>
    </div>
  `
})
export class NotFoundComponent {}
