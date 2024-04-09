import { Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { CompositorComponent } from './streaming/compositor/compositor.component';
import { LoginComponent } from './login/login.component';
import { LoginAddComponent } from './login/login-add/login-add.component';
import { BandaComponent } from './streaming/banda/banda.component';
import { BandaDetailComponent } from './streaming/banda-detail/banda-detail.component';

export const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'loginAdd',
    component: LoginAddComponent
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
    path: 'banda',
    component: BandaComponent
  },
  {
      path: 'detail/:id',
      component: BandaDetailComponent
  }
];
