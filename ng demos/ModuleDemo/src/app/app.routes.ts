import { Routes } from '@angular/router';
import { HomeComponent } from './home-component/home-component';
import { AboutComponent } from './about-component/about-component';
import { ContactUsComponent } from './contact-us-component/contact-us-component';

export const routes: Routes = [
  {   path: '',   component: HomeComponent   },
  {   path: 'home',   component: HomeComponent   },
  {   path: 'contactus',   component: ContactUsComponent   },
  {   path: 'aboutus',   component: AboutComponent   },
];
