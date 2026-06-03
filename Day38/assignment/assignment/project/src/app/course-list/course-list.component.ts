import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from '../course.model';

@Component({
  selector: 'app-course-list',
  standalone: false,
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.css'
})
export class CourseListComponent {
  @Input() courses: Course[] = [];
  @Input() selectedCourseId: number | null = null;

  // Event binding: emits the selected course when "View Details" is clicked
  @Output() courseSelected = new EventEmitter<Course>();

  onViewDetails(course: Course): void {
    this.courseSelected.emit(course);
  }
}
