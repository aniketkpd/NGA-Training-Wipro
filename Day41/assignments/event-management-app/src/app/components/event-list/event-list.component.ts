import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  trigger,
  transition,
  style,
  animate,
  query,
  stagger
} from '@angular/animations';
import { Event } from '../../models/event.model';
import { PriceFormatPipe } from '../../pipes/price-format.pipe';
import { HighlightDirective } from '../../directives/highlight.directive';

@Component({
  selector: 'app-event-list',
  standalone: true,
  imports: [CommonModule, PriceFormatPipe, HighlightDirective],
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss'],
  animations: [
    trigger('pageEnter', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(-20px)' }),
        animate('600ms ease-out', style({ opacity: 1, transform: 'translateY(0)' }))
      ])
    ]),
    trigger('listAnimation', [
      transition('* => *', [
        query(':enter', [
          style({ opacity: 0, transform: 'translateX(-30px)' }),
          stagger(120, [
            animate('500ms ease-out', style({ opacity: 1, transform: 'translateX(0)' }))
          ])
        ], { optional: true })
      ])
    ])
  ]
})
export class EventListComponent {
  events: Event[] = [
    { name: 'Tech Innovators Conference', date: '2025-09-12', price: 3500, category: 'Conference' },
    { name: 'Creative Writing Workshop',  date: '2025-10-05', price: 800,  category: 'Workshop'   },
    { name: 'Rock Music Concert',         date: '2025-11-20', price: 2500, category: 'Concert'    },
    { name: 'AI & Machine Learning Summit', date: '2025-12-02', price: 5000, category: 'Conference' }
  ];

  getCategoryClass(category: string): string {
    return category.toLowerCase().replace(/\s+/g, '-');
  }

  isPremium(price: number): boolean {
    return price > 2000;
  }
}
