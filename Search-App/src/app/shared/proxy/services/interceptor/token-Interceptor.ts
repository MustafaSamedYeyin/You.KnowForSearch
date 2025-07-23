import { HttpEvent, HttpHandlerFn, HttpRequest, HttpErrorResponse } from "@angular/common/http";
import { Observable, catchError, throwError } from "rxjs";
import { AuthService } from "../auth/auth.service";
import { inject } from "@angular/core";
import { Router } from "@angular/router";

export const tokenInterceptor: (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
) => Observable<HttpEvent<unknown>> = (req, next) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (token != null) {
    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

    return next(authReq).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          authService.isLogin = false;
          router.navigate(['/Login']);
        }
        return throwError(() => error);
      })
    );
  }

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        authService.isLogin = false;
        router.navigate(['/Login']);
      }
      return throwError(() => error);
    })
  );
};
