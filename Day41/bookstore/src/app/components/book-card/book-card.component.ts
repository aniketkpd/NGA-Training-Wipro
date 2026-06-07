import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../models/book';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-book-card',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="book-card">
      <img [src]="book.imageUrl" [alt]="book.title" />
      <h3>{{book.title}}</h3>
      <p class="author">by {{book.author}}</p>
      <p class="desc">{{book.description}}</p>
      <p class="price">₹{{book.price}}</p>
      <button class="btn btn-success" (click)="add()">Add To Cart</button>
    </div>
  `,
  styles: [`
    .book-card { background:#fff; border-radius:8px; padding:16px; box-shadow:0 2px 8px rgba(0,0,0,0.08); display:flex; flex-direction:column; }
    img { width:100%; height:240px; object-fit:cover; border-radius:4px; }
    h3 { margin:12px 0 4px; color:#2c3e50; font-size:1.05rem; }
    .author { color:#7f8c8d; font-size:0.85rem; margin:0 0 8px; }
    .desc { color:#555; font-size:0.85rem; flex:1; }
    .price { font-size:1.2rem; font-weight:700; color:#e67e22; margin:8px 0; }
  `]
})
export class BookCardComponent {
  @Input() book!: Book;
  constructor(private cartService: CartService) {}
  add(): void { this.cartService.addToCart(this.book); }
}
