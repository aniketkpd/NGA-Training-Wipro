import { Component } from '@angular/core';
import { EventListComponent } from './components/event-list/event-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EventListComponent],
  template: `<app-event-list></app-event-list>`
})
export class AppComponent {}
