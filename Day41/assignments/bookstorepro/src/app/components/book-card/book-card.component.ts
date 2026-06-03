import { Component, Input } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe, UpperCasePipe, SlicePipe } from '@angular/common';
import { Book } from '../../models/book.model';
import { DiscountPipe } from '../../pipes/discount.pipe';

@Component({
  selector: 'app-book-card',
  standalone: true,
  imports: [CommonModule, CurrencyPipe, DatePipe, UpperCasePipe, SlicePipe, DiscountPipe],
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent {
  @Input({ required: true }) book!: Book;
  @Input() discountPercent: number = 15;

  get starArray(): number[] {
    return Array.from({ length: 5 }, (_, i) => i + 1);
  }
}
