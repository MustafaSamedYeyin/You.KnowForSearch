import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from './shared/proxy/services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthService) {

  }

  Logged(state: boolean): void {
    this.authService.isLogin = state;
  }

  GetLogIn(): boolean {
    return this.authService.isLogin;
  }

  ngOnInit(): void {
    localStorage.getItem('token');
    if (localStorage.getItem('token')) {
      this.authService.isLogin = true;
    } else {
      this.authService.isLogin = false;
    }
  }
}
