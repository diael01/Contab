import { Component } from '@angular/core';
import { SiteHeaderComponent } from './site-header/site-header.component';
import { OrgComponent } from "./org/org.component";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  //imports: [SiteHeaderComponent],
})
export class AppComponent {
  title = 'Contab-UI-Ang';
}
