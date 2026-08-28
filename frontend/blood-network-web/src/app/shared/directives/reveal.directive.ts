import { Directive, ElementRef, Input, OnDestroy, OnInit } from '@angular/core';

/**
 * Adds `.bgn-reveal` + fades the host in via `.bgn-visible` once it scrolls into view.
 * Usage: <div appReveal [appRevealDelay]="i">...</div>
 */
@Directive({
  selector: '[appReveal]',
  standalone: true
})
export class RevealDirective implements OnInit, OnDestroy {
  @Input() appRevealDelay = 0;

  private observer?: IntersectionObserver;

  constructor(private el: ElementRef<HTMLElement>) {}

  ngOnInit(): void {
    const host = this.el.nativeElement;
    host.classList.add('bgn-reveal');
    if (this.appRevealDelay) {
      host.style.transitionDelay = `${Math.min(this.appRevealDelay * 70, 560)}ms`;
    }

    if (typeof IntersectionObserver === 'undefined') {
      host.classList.add('bgn-visible');
      return;
    }

    this.observer = new IntersectionObserver(
      (entries) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            host.classList.add('bgn-visible');
            this.observer?.unobserve(host);
          }
        });
      },
      { threshold: 0.15 }
    );
    this.observer.observe(host);
  }

  ngOnDestroy(): void {
    this.observer?.disconnect();
  }
}
