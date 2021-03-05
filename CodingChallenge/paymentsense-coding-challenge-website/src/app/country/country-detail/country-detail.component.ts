import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryService } from '../../services/country.service';
import { CountryDto } from '../../services/Interfaces/country-interface';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.scss']
})
export class CountryDetailComponent implements OnInit {

  title:string;  
  name: string;
  errorMessage: any;
  countries : Observable<CountryDto[]>;
  
  displayedColumns :any[]=['name','flag', 'capital', 'currencies.code'];
  dataSource = new MatTableDataSource<CountryDto>();
  
   constructor(
              private __avRoute: ActivatedRoute,
              private _router: Router, 
              private _countryService: CountryService,
              private http: HttpClient) {
    if(this.__avRoute.snapshot.params["name"]){
      this.name = this.__avRoute.snapshot.params["name"];
    }

    _countryService.getCountryDataByName(this.name);

    this.countries = _countryService.countriesData;
    
    this.getCountryDetails();
    this.displayedColumns = this.GetTableColumnHeadings();
       
  }
  
  ngOnInit(): void {
    if(this.name != null)
    {
      this.title = this.name;
      
    }
    this.getCountryDetails();
  }
  
  getCountryDetails() {
    this.countries.subscribe(data => this.dataSource.data = data
      ,error => this.errorMessage = error);
  }
 

  GetTableColumnHeadings() : any []
  {
    return ['name',
    'flag',
    'capital',
    'population',
    'borders',
    'timezones',
    'currencies',
    'languages'
    
    
    ];
  }

  onBackToList() {
    this._router.navigate(['/country-list']);
  }

}
