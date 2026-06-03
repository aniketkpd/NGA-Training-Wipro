import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule, AsyncPipe } from '@angular/common';
import { Observable, Subscription } from 'rxjs';
import { Book } from '../../models/book.model';
import { DataService } from '../../services/data.service';
import { BookCardComponent } from '../book-card/book-card.component';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, AsyncPipe, BookCardComponent],
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit, OnDestroy {
  // Manual subscribe approach
  manualBooks: Book[] = [];
  loadingManual = true;
  errorManual: string | null = null;
  private booksSub!: Subscription;

  // Async pipe approach
  books$!: Observable<Book[]>;

  activeTab: 'manual' | 'async' = 'manual';
  discountPercent = 15;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    // Async pipe: just assign the observable — template handles subscription/cleanup
    this.books$ = this.dataService.getBooks();

    // Manual subscribe with cleanup in ngOnDestroy
    this.booksSub = this.dataService.getBooks().subscribe({
      next: (books) => {
        this.manualBooks = books;
        this.loadingManual = false;
      },
      error: (err) => {
        this.errorManual = 'Failed to load books. Please try again.';
        this.loadingManual = false;
        console.error(err);
      }
    });
  }

  ngOnDestroy(): void {
    // Clean up manual subscription to prevent memory leaks
    if (this.booksSub) {
      this.booksSub.unsubscribe();
    }
  }

  setTab(tab: 'manual' | 'async'): void {
    this.activeTab = tab;
  }
}
