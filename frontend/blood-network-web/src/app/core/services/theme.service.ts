import { Injectable, signal, effect } from '@angular/core';

export type ThemeMode = 'light' | 'dark';

const STORAGE_KEY = 'bgn-theme';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  readonly mode = signal<ThemeMode>(this.readInitial());

  constructor() {
    effect(() => {
      const mode = this.mode();
      const root = document.documentElement;
      root.classList.toggle('dark', mode === 'dark');
      root.classList.toggle('light', mode === 'light');
      root.style.colorScheme = mode;
      try {
        localStorage.setItem(STORAGE_KEY, mode);
      } catch {
        /* ignore storage errors */
      }
    });
  }

  toggle(): void {
    this.mode.update(m => (m === 'dark' ? 'light' : 'dark'));
  }

  set(mode: ThemeMode): void {
    this.mode.set(mode);
  }

  private readInitial(): ThemeMode {
    try {
      const stored = localStorage.getItem(STORAGE_KEY) as ThemeMode | null;
      if (stored === 'light' || stored === 'dark') {
        return stored;
      }
    } catch {
      /* ignore */
    }
    const prefersDark = window.matchMedia?.('(prefers-color-scheme: dark)').matches;
    return prefersDark ? 'dark' : 'light';
  }
}
