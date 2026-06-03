import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Course } from '../course.model';

@Component({
  selector: 'app-course-detail',
  standalone: false,
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.css'
})
export class CourseDetailComponent {
  // Property binding: receives selected course from parent via [course] input
  @Input() course: Course | null = null;

  // Emits when the user edits the title so the parent list stays in sync
  @Output() titleChanged = new EventEmitter<{ id: number; title: string }>();

  onTitleChange(newTitle: string): void {
    if (this.course) {
      this.titleChanged.emit({ id: this.course.id, title: newTitle });
    }
  }
}
