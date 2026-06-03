# EduLearn – Course Management SPA

An Angular 19 Single Page Application built for the Day 19 Case Study Assignment.

## Features

- View a list of available courses
- Click "View Details" to load a course into the detail panel
- Edit the course title in real time with changes reflected back in the list

---

## How to Install & Run

### Prerequisites
- Node.js 18+ and npm installed

### Steps

```bash
# 1. Install dependencies
npm install

# 2. Start the development server
npm start
```

Open your browser at `http://localhost:4200`.

---

## Data Binding Explained

### 1. Property Binding

**Where:** `app.component.html`

```html
<app-course-list
  [courses]="courses"
  [selectedCourseId]="selectedCourse?.id ?? null"
  ...
></app-course-list>

<app-course-detail
  [course]="selectedCourse"
  ...
></app-course-detail>
```

The `[courses]`, `[selectedCourseId]`, and `[course]` attributes use square-bracket syntax to pass data **from parent to child** component. Also used inside `course-detail.component.html` with `[textContent]="course.instructor"` and `[title]="'Level: ' + course.level"`.

---

### 2. Event Binding

**Where:** `app.component.html`

```html
<app-course-list
  ...
  (courseSelected)="onCourseSelected($event)"
></app-course-list>

<app-course-detail
  ...
  (titleChanged)="onTitleChanged($event)"
></app-course-detail>
```

Parenthesis syntax `(eventName)` listens for custom events emitted by child components using `@Output() EventEmitter`. When the user clicks "View Details", `CourseListComponent` emits `courseSelected`, which the parent handles in `onCourseSelected()`.

---

### 3. Two-Way Binding

**Where:** `course-detail.component.html`

```html
<input
  [(ngModel)]="course.title"
  (ngModelChange)="onTitleChange($event)"
/>
<p>Live preview: <strong>{{ course.title }}</strong></p>
```

`[(ngModel)]` (banana-in-a-box syntax) combines property binding and event binding so the input value and `course.title` stay in sync in real time. `ngModelChange` additionally notifies the parent to update the master list.

---

## Project Structure

```
src/
  app/
    app.module.ts               — Root NgModule (imports BrowserModule, FormsModule)
    app.component.ts/html/css   — Root component; owns course data and state
    course.model.ts             — Course interface
    course-list/
      course-list.component.ts  — Displays course cards; emits selected course
      course-list.component.html
      course-list.component.css
    course-detail/
      course-detail.component.ts  — Shows/edits selected course details
      course-detail.component.html
      course-detail.component.css
  main.ts         — App bootstrap via AppModule
  index.html
  global_styles.css
```

---

## Evaluation Criteria Coverage

| Criteria | Implementation |
|---|---|
| Project setup & CLI usage | Angular 19, `@angular/build:application` builder |
| Module & component structure | AppModule declares 3 components; FormsModule imported for ngModel |
| Property binding | `[courses]`, `[course]`, `[selectedCourseId]`, `[textContent]`, `[title]` |
| Event binding | `(courseSelected)`, `(titleChanged)`, `(click)` |
| Two-way binding | `[(ngModel)]` on title input in CourseDetailComponent |
| Code readability | Angular naming conventions, single-responsibility components |
