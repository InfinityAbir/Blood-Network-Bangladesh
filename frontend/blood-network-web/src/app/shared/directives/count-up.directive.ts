import { Directive, ElementRef, Input, OnDestroy, OnInit } from '@angular/core';

/**
 * Animates the host's text from 0 to [appCountUp] once it scrolls into view.
 * Usage: <span appCountUp="55" appCountUpSuffix="+">0</span>
 */
@Directive({
  selector: '[appCountUp]',
  standalone: true
})
export class CountUpDirective implements OnInit, OnDestroy {
  @Input('appCountUp') target = 0;
  @Input() appCountUpSuffix = '';
  @Input() appCountUpDuration = 1200;

  private observer?: IntersectionObserver;
  private rafId?: number;

  constructor(private el: ElementRef<HTMLElement>) {}

  ngOnInit(): void {
    const host = this.el.nativeElement;

    if (typeof IntersectionObserver === 'undefined') {
      host.textContent = `${this.target}${this.appCountUpSuffix}`;
      return;
    }

    this.observer = new IntersectionObserver(
      (entries) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            this.run();
            this.observer?.unobserve(host);
          }
        });
      },
      { threshold: 0.4 }
    );
    this.observer.observe(host);
  }

  private run(): void {
    const host = this.el.nativeElement;
    const start = performance.now();
    const step = (now: number) => {
      const progress = Math.min((now - start) / this.appCountUpDuration, 1);
      const eased = 1 - Math.pow(1 - progress, 3);
      const value = Math.round(this.target * eased);
      host.textContent = `${value.toLocaleString()}${this.appCountUpSuffix}`;
      if (progress < 1) {
        this.rafId = requestAnimationFrame(step);
      }
    };
    this.rafId = requestAnimationFrame(step);
  }

  ngOnDestroy(): void {
    this.observer?.disconnect();
    if (this.rafId) cancelAnimationFrame(this.rafId);
  }
}
