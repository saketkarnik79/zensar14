import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
// import { HomeComponent } from './home-component/home-component';
// import { AboutComponent } from './about-component/about-component';
// import { ContactUsComponent } from './contact-us-component/contact-us-component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLink],//, HomeComponent, AboutComponent, ContactUsComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('ModuleDemo');
}
