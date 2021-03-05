import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import { RoutingModule } from './modules/routing/routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CountryListComponent } from './country/country-list.component';
import { CountryDetailComponent } from './country/country-detail/country-detail.component';

import { CommonModule } from '@angular/common';
import { MaterialModule } from './shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CountryService } from './services/country.service';
import { MatTooltipModule } from '@angular/material/tooltip';


const routes: Routes = [
  {path: '**', redirectTo: 'country-list'}
];



@NgModule({
  declarations: [
    AppComponent,
    CountryListComponent,
    CountryDetailComponent
  ],
  imports: [
    BrowserModule,
    RoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    CommonModule,
    MaterialModule,
    MatTooltipModule,

    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [PaymentsenseCodingChallengeApiService],
            
  bootstrap: [AppComponent]
})
export class AppModule { }
