import { Injectable } from '@angular/core';
import { BaseService } from '../services/base.service';
import { Country, ResponseDto, CountryDto  } from '../services/Interfaces/country-interface';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  countryServiceURL: string;
  private _countriesUrl: string;
  private _countries : BehaviorSubject<Country[]>;
   countriesData : Observable<CountryDto[]>;
  private dataStore: {
    countries : Country[]
  }

  constructor(private http: HttpClient) {
    this.dataStore = { countries: []};
    this._countries = new BehaviorSubject<Country[]>([]);

    this._countriesUrl = "https://localhost:44385/api/Countries";
   }

   get countries() : Observable<Country[]> {
    return this._countries.asObservable();
  }

  loadAll()
  {
    return this.http.get<Country[]>(this._countriesUrl)
    .subscribe( data => {
      this.dataStore.countries = data;
      this._countries.next(Object.assign({}, this.dataStore).countries);
    }, error => {
      console.log("Failed to fetch countries");
    });
  }

  getCountries() { 
   
    return this.http.get<Country[]>(this._countriesUrl);
  }


  getCountriesData()
  {
      this.countriesData = this.http.get<CountryDto[]>(this._countriesUrl).pipe(
    shareReplay(1)
   );
  }

  getCountryDataByName(name: string)
  {
    const countryByNameURL = this._countriesUrl+'/GetCountryDetailsByFullName/'+name;
    
    this.countriesData = this.http.get<CountryDto[]>(countryByNameURL).pipe(
      shareReplay(1)
     );
  }

   
}
