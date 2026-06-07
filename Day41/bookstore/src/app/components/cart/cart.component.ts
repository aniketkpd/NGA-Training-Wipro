import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CartItem } from '../../models/cart-item';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <h1>Shopping Cart</h1>
    <div *ngIf="items.length === 0" class="empty">
      Your cart is empty. <a routerLink="/">Browse books</a>
    </div>
    <div *ngIf="items.length > 0">
      <table class="cart-table">
        <thead>
          <tr><th>Image</th><th>Book</th><th>Quantity</th><th>Price</th><th>Total</th><th>Action</th></tr>
        </thead>
        <tbody>
          <tr *ngFor="let item of items">
            <td><img [src]="item.book.imageUrl" [alt]="item.book.title" /></td>
            <td>{{item.book.title}}</td>
            <td>
              <button class="qty" (click)="dec(item.book.id)">-</button>
              <span class="q">{{item.quantity}}</span>
              <button class="qty" (click)="inc(item.book.id)">+</button>
            </td>
            <td>₹{{item.book.price}}</td>
            <td>₹{{item.book.price * item.quantity}}</td>
            <td><button class="btn btn-danger" (click)="remove(item.book.id)">Remove</button></td>
          </tr>
        </tbody>
      </table>
      <div class="summary">
        <p><strong>Total Books:</strong> {{totalBooks}}</p>
        <p><strong>Grand Total:</strong> ₹{{totalPrice}}</p>
        <div class="actions">
          <button class="btn btn-danger" (click)="clear()">Clear Cart</button>
          <a routerLink="/checkout" class="btn btn-success">Proceed to Checkout</a>
        </div>
      </div>
    </div>
  `,
  styles: [`
    h1 { color:#2c3e50; }
    .empty { background:#fff; padding:30px; border-radius:8px; text-align:center; }
    .empty a { color:#e67e22; font-weight:600; }
    .cart-table { width:100%; border-collapse:collapse; background:#fff; border-radius:8px; overflow:hidden; box-shadow:0 2px 8px rgba(0,0,0,0.08); }
    .cart-table th, .cart-table td { padding:12px; text-align:left; border-bottom:1px solid #ecf0f1; }
    .cart-table th { background:#34495e; color:#fff; }
    img { width:60px; height:80px; object-fit:cover; border-radius:4px; }
    .qty { width:30px; height:30px; border:none; background:#2c3e50; color:#fff; border-radius:4px; font-weight:700; }
    .q { padding:0 12px; font-weight:700; }
    .summary { background:#fff; padding:20px; margin-top:20px; border-radius:8px; box-shadow:0 2px 8px rgba(0,0,0,0.08); }
    .summary p { font-size:1.1rem; margin:6px 0; }
    .actions { display:flex; gap:12px; margin-top:16px; }
    .actions a { display:inline-block; text-align:center; line-height:1.5; }
  `]
})
export class CartComponent implements OnInit {
  items: CartItem[] = [];
  totalBooks = 0;
  totalPrice = 0;

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cartService.cart$.subscribe(items => {
      this.items = items;
      this.totalBooks = this.cartService.getTotalBooks();
      this.totalPrice = this.cartService.getTotalPrice();
    });
  }

  inc(id: number): void { this.cartService.increaseQuantity(id); }
  dec(id: number): void { this.cartService.decreaseQuantity(id); }
  remove(id: number): void { this.cartService.removeFromCart(id); }
  clear(): void { this.cartService.clearCart(); }
}
