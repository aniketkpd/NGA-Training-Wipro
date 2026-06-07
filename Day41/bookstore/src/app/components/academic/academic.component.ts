import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../models/book';
import { BookService } from '../../services/book.service';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-academic',
  standalone: true,
  imports: [CommonModule, BookCardComponent],
  template: `
    <h1>Academic</h1>
    <div class="grid">
      <app-book-card *ngFor="let book of books" [book]="book"></app-book-card>
    </div>
    <p *ngIf="books.length === 0" class="empty">No books available in this category.</p>
  `,
  styles: [`
    h1 { color:#2c3e50; }
    .grid { display:grid; grid-template-columns:repeat(auto-fill, minmax(240px,1fr)); gap:20px; margin-top:20px; }
    .empty { color:#7f8c8d; font-style:italic; }
  `]
})
export class AcademicComponent implements OnInit {
  books: Book[] = [];
  constructor(private bookService: BookService) {}
  ngOnInit(): void { this.books = this.bookService.getBooksByCategory('academic'); }
}
