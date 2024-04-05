import { Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { CompositorComponent } from './streaming/compositor/compositor.component';
import { LoginComponent } from './login/login.component';
import { LoginAddComponent } from './login/login-add/login-add.component';

export const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'compositor',
    component: CompositorComponent
  },
  {
    path: 'loginAdd',
    component: LoginAddComponent
  }
];
