import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => {
    console.error(err);
    document.body.innerHTML = `
      <div style="display:flex;align-items:center;justify-content:center;min-height:100vh;font-family:sans-serif;text-align:center;padding:20px;">
        <div>
          <h1 style="color:#e53935;">Something went wrong</h1>
          <p>Please refresh the page or <a href="/">go to homepage</a>.</p>
          <details style="margin-top:16px;text-align:left;">
            <summary>Error details</summary>
            <pre style="margin-top:8px;padding:12px;background:#f5f5f5;border-radius:8px;overflow:auto;font-size:13px;">${err}</pre>
          </details>
        </div>
      </div>
    `;
  });
