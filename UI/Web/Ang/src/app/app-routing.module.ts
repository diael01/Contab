
import { NgModule } from '@angular/core';
import { RouterModule , Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { OrgComponent } from './org/org.component';

const routes: Routes=[
 
  { path: 'home', component: HomeComponent, title: 'Home - Contab' },
  { path: 'org', component: OrgComponent, title: 'Org' },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
  
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
