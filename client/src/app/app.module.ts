import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VideosComponent } from './video/videos/videos.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { VideoDetailComponent } from './video/video-detail/video-detail.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { VideoCreateComponent } from './video/video-create/video-create.component';
import { VideoUpdateComponent } from './video/video-update/video-update.component';
import { VideoDeleteComponent } from './video/video-delete/video-delete.component';
import {TokenInterceptorService} from './services/token-interceptor.service';
import {ErrorInterceptorService} from './services/error-interceptor.service';
import {AuthService} from './services/auth.service';
import {AuthGuardService} from './services/auth-guard.service';
import {VideoService} from './services/video.service';
import {ToastrModule} from 'ngx-toastr';
import { NavbarComponent } from './navbar/navbar.component';
import { UserpartComponent } from './user/userpart/userpart.component';
import { ContactsComponent } from './contacts/contacts.component';
import { SucsessComponent } from './user/sucsess/sucsess.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'sucsess', component: SucsessComponent },
  {
    path: 'videos',
    component: VideosComponent,
    children: [
      {
        path: 'detail',
        component: VideoDetailComponent,
      },
      {
        path: 'create',
        component: VideoCreateComponent,
      },
      {
        path: 'update',
        component: VideoUpdateComponent,
      },
      {
        path: 'delete',
        component: VideoDeleteComponent,
      }
    ]
  }
];
@NgModule({
  declarations: [
    AppComponent,
    VideosComponent,
    VideoDetailComponent,
    LoginComponent,
    RegisterComponent,
    VideoCreateComponent,
    VideoUpdateComponent,
    VideoDeleteComponent,
    NavbarComponent,
    UserpartComponent,
    ContactsComponent,
    SucsessComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot()
  ],
  providers: [
    AuthService,
    VideoService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
