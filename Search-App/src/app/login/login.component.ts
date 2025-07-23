import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { AuthService } from '../shared/proxy/services/auth/auth.service';
import { Register } from '../shared/proxy/services/auth/dtos/register';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    RouterModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  isSubmitting = false;
  loginError = '';
  @Output() isLogin = new EventEmitter<boolean>();
  router: Router = inject(Router);

  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      rememberMe: [false]
    });
  }

  onLogin(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.isSubmitting = true;
    this.loginError = '';

    const credentials = this.loginForm.value;
    var result = this.authService.login({ email: credentials.email, password: credentials.password })
      .subscribe(i => {
        window.localStorage.setItem('token', i.token);
        this.authService.isLogin = true;
        this.isLogin.emit(true);
      });
      this. router.navigate(['/Questions']);

  }

  onRegister(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.isSubmitting = false;
    this.loginError = '';

    const credentials = this.loginForm.value;
    var result = this.authService.register(
      {
        name: credentials.name,
        email: credentials.email,
        passwordHash: credentials.password,
      } as Register
    )
    .subscribe(i => {
    });
  }
}
