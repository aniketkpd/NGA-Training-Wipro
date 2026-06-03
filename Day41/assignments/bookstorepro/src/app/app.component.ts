import { Component } from '@angular/core';
import { BooksComponent } from './components/books/books.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BooksComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentYear = new Date().getFullYear();
}
