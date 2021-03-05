import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { CountryService } from  '../services/country.service';
import {CountryDto} from '../services/Interfaces/country-interface';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { MatSort } from '@angular/material/sort';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})

export class CountryListComponent implements OnInit, AfterViewInit {


  displayedColumns: string[] =['name', 'flag', 'actions'];
  
  dataSource = new MatTableDataSource<CountryDto>();

 countries : Observable<CountryDto[]>;
 error: any;


  @ViewChild (MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild (MatSort, {static: true}) sort: MatSort;


  constructor(private _countryService: CountryService, 
    private _router : Router,
    private http: HttpClient) {
     
      _countryService.getCountriesData();

      this.countries = _countryService.countriesData;
  
   this.getCountries();
   this.displayedColumns = this.GetTableColumnHeadings();
   }

   ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit(): void {
  this.getCountries();
  
  }
 
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getCountries() {
    this.countries.subscribe(data => this.dataSource.data = data
      ,error => this.error = error);
  }

  GetTableColumnHeadings() : string []
  {
    return ['name',
    'flag',
    'actions'
    ];
  }

}