import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../../../environment';
import { Register } from './dtos/register';
import { RegisterResponse } from './dtos/registerResponse';
import { LoginResponse } from './dtos/loginResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLogin: boolean = false;

  constructor(private HttpClient: HttpClient) { }

  login(credentials: { email: string, password: string }) : Observable<LoginResponse> {
    return this.HttpClient.post<LoginResponse>(`${environment.apiUrl}/api/Auth/login`, credentials);
  }

  register(credentials: Register): Observable<RegisterResponse> {
    return this.HttpClient.post<RegisterResponse>(`${environment.apiUrl}/api/Auth/register`, credentials);
  }

  validateToken(token: string): Observable<boolean>
  {
    var result =  this.HttpClient.post<boolean>(`${environment.apiUrl}/api/Auth/ValidateToken`, { Token: token } );
    if (result)
    {
      this.isLogin = true;
    }
    else
    {
      this.isLogin = false;
    }
    return result;
  }
}
