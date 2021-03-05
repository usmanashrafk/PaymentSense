import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes, RouterModule} from '@angular/router';
import { CountryDetailComponent } from 'src/app/country/country-detail/country-detail.component';
import { CountryListComponent } from 'src/app/country/country-list.component';




const routes: Routes = [  
  { path: '', redirectTo: './country-list', pathMatch: 'full' },  
  { path: 'country-detail/:name', component: CountryDetailComponent},
  { path: 'country-list', component: CountryListComponent}
 
];

@NgModule({  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class RoutingModule { }
