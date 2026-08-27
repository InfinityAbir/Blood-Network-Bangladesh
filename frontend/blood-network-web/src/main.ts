import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => {
    console.error(err);
    const wrapper = document.createElement('div');
    wrapper.style.cssText = 'display:flex;align-items:center;justify-content:center;min-height:100vh;font-family:sans-serif;text-align:center;padding:20px;';
    const inner = document.createElement('div');
    const h1 = document.createElement('h1');
    h1.style.color = '#e53935';
    h1.textContent = 'Something went wrong';
    const p = document.createElement('p');
    p.appendChild(document.createTextNode('Please refresh the page or '));
    const a = document.createElement('a');
    a.href = '/';
    a.textContent = 'go to homepage';
    p.appendChild(a);
    p.appendChild(document.createTextNode('.'));
    const details = document.createElement('details');
    details.style.cssText = 'margin-top:16px;text-align:left;';
    const summary = document.createElement('summary');
    summary.textContent = 'Error details';
    const pre = document.createElement('pre');
    pre.style.cssText = 'margin-top:8px;padding:12px;background:#f5f5f5;border-radius:8px;overflow:auto;font-size:13px;';
    pre.textContent = String(err);
    details.appendChild(summary);
    details.appendChild(pre);
    inner.appendChild(h1);
    inner.appendChild(p);
    inner.appendChild(details);
    wrapper.appendChild(inner);
    document.body.appendChild(wrapper);
  });
