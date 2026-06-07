import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Book } from '../models/book';
import { CartItem } from '../models/cart-item';

const STORAGE_KEY = 'bookstore_cart';

@Injectable({ providedIn: 'root' })
export class CartService {
  private items: CartItem[] = [];
  private cartSubject = new BehaviorSubject<CartItem[]>([]);
  cart$ = this.cartSubject.asObservable();

  constructor() {
    const saved = typeof localStorage !== 'undefined' ? localStorage.getItem(STORAGE_KEY) : null;
    if (saved) {
      try { this.items = JSON.parse(saved); } catch { this.items = []; }
    }
    this.cartSubject.next(this.items);
  }

  private persist(): void {
    if (typeof localStorage !== 'undefined') {
      localStorage.setItem(STORAGE_KEY, JSON.stringify(this.items));
    }
    this.cartSubject.next([...this.items]);
  }

  addToCart(book: Book): void {
    const existing = this.items.find(i => i.book.id === book.id);
    if (existing) {
      existing.quantity += 1;
    } else {
      this.items.push({ book, quantity: 1 });
    }
    this.persist();
  }

  removeFromCart(bookId: number): void {
    this.items = this.items.filter(i => i.book.id !== bookId);
    this.persist();
  }

  increaseQuantity(bookId: number): void {
    const item = this.items.find(i => i.book.id === bookId);
    if (item) { item.quantity += 1; this.persist(); }
  }

  decreaseQuantity(bookId: number): void {
    const item = this.items.find(i => i.book.id === bookId);
    if (item) {
      item.quantity -= 1;
      if (item.quantity <= 0) {
        this.removeFromCart(bookId);
      } else {
        this.persist();
      }
    }
  }

  clearCart(): void {
    this.items = [];
    this.persist();
  }

  getCartItems(): CartItem[] {
    return [...this.items];
  }

  getTotalBooks(): number {
    return this.items.reduce((sum, i) => sum + i.quantity, 0);
  }

  getTotalPrice(): number {
    return this.items.reduce((sum, i) => sum + i.quantity * i.book.price, 0);
  }
}
