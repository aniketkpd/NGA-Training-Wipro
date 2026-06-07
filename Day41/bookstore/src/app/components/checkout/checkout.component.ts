import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  template: `
    <h1>Checkout</h1>
    <div *ngIf="success" class="success">
      <h2>✅ Order Placed Successfully</h2>
      <p>Thank you for your purchase!</p>
      <a routerLink="/" class="btn btn-success">Continue Shopping</a>
    </div>

    <form *ngIf="!success" [formGroup]="form" (ngSubmit)="onSubmit()" class="form">
      <label>Customer Name *
        <input type="text" formControlName="name" />
        <span class="err" *ngIf="ctrl('name').touched && ctrl('name').errors?.['required']">Name is required</span>
      </label>

      <label>Email *
        <input type="email" formControlName="email" />
        <span class="err" *ngIf="ctrl('email').touched && ctrl('email').errors?.['required']">Email is required</span>
        <span class="err" *ngIf="ctrl('email').touched && ctrl('email').errors?.['email']">Enter a valid email</span>
      </label>

      <label>Mobile Number *
        <input type="tel" formControlName="mobile" />
        <span class="err" *ngIf="ctrl('mobile').touched && ctrl('mobile').errors?.['required']">Mobile is required</span>
        <span class="err" *ngIf="ctrl('mobile').touched && ctrl('mobile').errors?.['pattern']">Mobile must be 10 digits</span>
      </label>

      <label>Address *
        <textarea formControlName="address" rows="3"></textarea>
        <span class="err" *ngIf="ctrl('address').touched && ctrl('address').errors?.['required']">Address is required</span>
      </label>

      <label>City
        <input type="text" formControlName="city" />
      </label>

      <label>State
        <input type="text" formControlName="state" />
      </label>

      <label>Postal Code *
        <input type="text" formControlName="postalCode" />
        <span class="err" *ngIf="ctrl('postalCode').touched && ctrl('postalCode').errors?.['required']">Postal code is required</span>
      </label>

      <button type="submit" class="btn btn-success" [disabled]="form.invalid">Place Order</button>
    </form>
  `,
  styles: [`
    h1 { color:#2c3e50; }
    .form { background:#fff; padding:24px; border-radius:8px; max-width:600px; box-shadow:0 2px 8px rgba(0,0,0,0.08); display:flex; flex-direction:column; gap:14px; }
    label { display:flex; flex-direction:column; font-weight:600; color:#34495e; font-size:0.9rem; }
    input, textarea { margin-top:4px; padding:8px 10px; border:1px solid #bdc3c7; border-radius:4px; font-family:inherit; font-size:0.95rem; }
    .err { color:#e74c3c; font-size:0.8rem; font-weight:400; margin-top:4px; }
    .success { background:#fff; padding:40px; border-radius:8px; text-align:center; box-shadow:0 2px 8px rgba(0,0,0,0.08); }
    .success h2 { color:#27ae60; }
    button[disabled] { opacity:0.5; cursor:not-allowed; }
  `]
})
export class CheckoutComponent {
  form: FormGroup;
  success = false;

  constructor(private fb: FormBuilder, private cartService: CartService, private router: Router) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      mobile: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      address: ['', Validators.required],
      city: [''],
      state: [''],
      postalCode: ['', Validators.required]
    });
  }

  ctrl(name: string) { return this.form.get(name)!; }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.cartService.clearCart();
    this.success = true;
  }
}
