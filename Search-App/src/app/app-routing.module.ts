import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'Login',
    loadComponent: () => import('./login/login.component')
      .then(m => m.LoginComponent),
  },
  {
    path: '',
    loadComponent: () => import('./questions/questions.component')
      .then(m => m.QuestionsComponent),
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
