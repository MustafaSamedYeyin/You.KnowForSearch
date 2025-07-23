import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CommonModule } from '@angular/common';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LoginComponent } from './login/login.component';
import { tokenInterceptor } from './shared/proxy/services/interceptor/token-Interceptor';
import { ResourceComponent } from './resource/resource.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NavBarComponent,
    CommonModule,
    OAuthModule.forRoot(),
    LoginComponent
],
  providers: [
     provideHttpClient(
      withInterceptors([tokenInterceptor])
    )
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
