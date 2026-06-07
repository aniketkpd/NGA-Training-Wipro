import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { BestSellersComponent } from './components/best-sellers/best-sellers.component';
import { FictionComponent } from './components/fiction/fiction.component';
import { NonFictionComponent } from './components/non-fiction/non-fiction.component';
import { TechnologyComponent } from './components/technology/technology.component';
import { SelfHelpComponent } from './components/self-help/self-help.component';
import { ChildrenBooksComponent } from './components/children-books/children-books.component';
import { AcademicComponent } from './components/academic/academic.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'best-sellers', component: BestSellersComponent },
  { path: 'fiction', component: FictionComponent },
  { path: 'non-fiction', component: NonFictionComponent },
  { path: 'technology', component: TechnologyComponent },
  { path: 'self-help', component: SelfHelpComponent },
  { path: 'children-books', component: ChildrenBooksComponent },
  { path: 'academic', component: AcademicComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: '**', redirectTo: '' }
];
