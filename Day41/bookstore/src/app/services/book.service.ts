import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({ providedIn: 'root' })
export class BookService {
  private books: Book[] = [
    { id: 1, title: 'The Silent Patient', author: 'Alex Michaelides', description: 'A gripping psychological thriller.', price: 299, imageUrl: 'https://picsum.photos/seed/b1/200/280', category: 'best-sellers' },
    { id: 2, title: 'Atomic Habits', author: 'James Clear', description: 'Build good habits, break bad ones.', price: 399, imageUrl: 'https://picsum.photos/seed/b2/200/280', category: 'best-sellers' },
    { id: 3, title: 'Where the Crawdads Sing', author: 'Delia Owens', description: 'A coming-of-age mystery.', price: 350, imageUrl: 'https://picsum.photos/seed/b3/200/280', category: 'best-sellers' },

    { id: 4, title: '1984', author: 'George Orwell', description: 'A dystopian classic.', price: 250, imageUrl: 'https://picsum.photos/seed/b4/200/280', category: 'fiction' },
    { id: 5, title: 'To Kill a Mockingbird', author: 'Harper Lee', description: 'A novel of childhood and morality.', price: 280, imageUrl: 'https://picsum.photos/seed/b5/200/280', category: 'fiction' },
    { id: 6, title: 'The Great Gatsby', author: 'F. Scott Fitzgerald', description: 'Jazz age tragedy.', price: 230, imageUrl: 'https://picsum.photos/seed/b6/200/280', category: 'fiction' },

    { id: 7, title: 'Sapiens', author: 'Yuval Noah Harari', description: 'A brief history of humankind.', price: 450, imageUrl: 'https://picsum.photos/seed/b7/200/280', category: 'non-fiction' },
    { id: 8, title: 'Educated', author: 'Tara Westover', description: 'A memoir of self-invention.', price: 380, imageUrl: 'https://picsum.photos/seed/b8/200/280', category: 'non-fiction' },

    { id: 9, title: 'Clean Code', author: 'Robert C. Martin', description: 'A handbook of agile software craftsmanship.', price: 599, imageUrl: 'https://picsum.photos/seed/b9/200/280', category: 'technology' },
    { id: 10, title: 'The Pragmatic Programmer', author: 'Andrew Hunt', description: 'Your journey to mastery.', price: 549, imageUrl: 'https://picsum.photos/seed/b10/200/280', category: 'technology' },
    { id: 11, title: 'You Don\'t Know JS', author: 'Kyle Simpson', description: 'Deep dive into JavaScript.', price: 499, imageUrl: 'https://picsum.photos/seed/b11/200/280', category: 'technology' },

    { id: 12, title: 'The 7 Habits of Highly Effective People', author: 'Stephen Covey', description: 'Powerful lessons in personal change.', price: 320, imageUrl: 'https://picsum.photos/seed/b12/200/280', category: 'self-help' },
    { id: 13, title: 'Think and Grow Rich', author: 'Napoleon Hill', description: 'Classic self-improvement.', price: 270, imageUrl: 'https://picsum.photos/seed/b13/200/280', category: 'self-help' },

    { id: 14, title: 'Harry Potter and the Sorcerer\'s Stone', author: 'J.K. Rowling', description: 'A boy discovers he is a wizard.', price: 420, imageUrl: 'https://picsum.photos/seed/b14/200/280', category: 'children-books' },
    { id: 15, title: 'Charlotte\'s Web', author: 'E.B. White', description: 'A timeless tale of friendship.', price: 220, imageUrl: 'https://picsum.photos/seed/b15/200/280', category: 'children-books' },

    { id: 16, title: 'Introduction to Algorithms', author: 'Thomas H. Cormen', description: 'Comprehensive algorithms textbook.', price: 899, imageUrl: 'https://picsum.photos/seed/b16/200/280', category: 'academic' },
    { id: 17, title: 'Calculus', author: 'James Stewart', description: 'Foundational calculus reference.', price: 750, imageUrl: 'https://picsum.photos/seed/b17/200/280', category: 'academic' }
  ];

  getBooks(): Book[] {
    return this.books;
  }

  getBooksByCategory(category: string): Book[] {
    return this.books.filter(b => b.category === category);
  }

  getBookById(id: number): Book | undefined {
    return this.books.find(b => b.id === id);
  }
}
