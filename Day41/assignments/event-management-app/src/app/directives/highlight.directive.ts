import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective implements OnInit {
  @Input() appHighlight: number = 0;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit(): void {
    if (this.appHighlight > 2000) {
      this.renderer.setStyle(this.el.nativeElement, 'background-color', 'rgba(255, 215, 0, 0.12)');
      this.renderer.setStyle(this.el.nativeElement, 'border-left', '4px solid #ffd700');
      this.renderer.setStyle(this.el.nativeElement, 'box-shadow', '0 0 16px rgba(255, 215, 0, 0.15)');
    }
  }
}
