import { Component } from '@angular/core';
import { Course } from './course.model';

@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  courses: Course[] = [
    {
      id: 1,
      title: 'Introduction to Angular',
      instructor: 'Sarah Johnson',
      duration: '6 weeks',
      level: 'Beginner',
      description: 'Learn the fundamentals of Angular including components, modules, services, and data binding. Build your first SPA from scratch.'
    },
    {
      id: 2,
      title: 'Advanced TypeScript',
      instructor: 'Michael Chen',
      duration: '4 weeks',
      level: 'Advanced',
      description: 'Deep dive into TypeScript generics, decorators, advanced types, and design patterns used in enterprise applications.'
    },
    {
      id: 3,
      title: 'RxJS & Reactive Programming',
      instructor: 'Priya Sharma',
      duration: '5 weeks',
      level: 'Intermediate',
      description: 'Master observables, operators, and reactive patterns with RxJS. Learn to handle async data streams in Angular applications.'
    },
    {
      id: 4,
      title: 'Angular Material UI',
      instructor: 'David Williams',
      duration: '3 weeks',
      level: 'Beginner',
      description: 'Build beautiful, accessible user interfaces using Angular Material components, theming, and layout tools.'
    },
    {
      id: 5,
      title: 'NgRx State Management',
      instructor: 'Emily Rodriguez',
      duration: '5 weeks',
      level: 'Advanced',
      description: 'Implement predictable, scalable state management using NgRx Store, Effects, Selectors, and Entity patterns.'
    }
  ];

  selectedCourse: Course | null = null;

  // Event binding handler: called when CourseListComponent emits courseSelected
  onCourseSelected(course: Course): void {
    this.selectedCourse = course;
  }

  // Two-way binding sync: updates the master list when title is changed in detail
  onTitleChanged(event: { id: number; title: string }): void {
    const course = this.courses.find(c => c.id === event.id);
    if (course) {
      course.title = event.title;
    }
  }
}
