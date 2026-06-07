import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

interface Category { name: string; route: string; icon: string; }

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <h1>Welcome to the Online Book Store</h1>
    <p>Browse our categories and find your next favorite read.</p>
    <div class="grid">
      <a *ngFor="let c of categories" [routerLink]="c.route" class="card">
        <div class="icon">{{c.icon}}</div>
        <h3>{{c.name}}</h3>
      </a>
    </div>
  `,
  styles: [`
    h1 { color:#2c3e50; }
    .grid { display:grid; grid-template-columns:repeat(auto-fill, minmax(200px,1fr)); gap:20px; margin-top:24px; }
    .card { background:#fff; padding:30px; border-radius:8px; text-align:center; box-shadow:0 2px 8px rgba(0,0,0,0.08); transition:transform 0.2s; }
    .card:hover { transform:translateY(-4px); box-shadow:0 6px 16px rgba(0,0,0,0.12); }
    .icon { font-size:3rem; margin-bottom:12px; }
    h3 { margin:0; color:#34495e; }
  `]
})
export class HomeComponent {
  categories: Category[] = [
    { name: 'Best Sellers', route: '/best-sellers', icon: '⭐' },
    { name: 'Fiction', route: '/fiction', icon: '📖' },
    { name: 'Non-Fiction', route: '/non-fiction', icon: '📰' },
    { name: 'Technology', route: '/technology', icon: '💻' },
    { name: 'Self-Help', route: '/self-help', icon: '🌱' },
    { name: "Children's Books", route: '/children-books', icon: '🧸' },
    { name: 'Academic', route: '/academic', icon: '🎓' }
  ];
}
