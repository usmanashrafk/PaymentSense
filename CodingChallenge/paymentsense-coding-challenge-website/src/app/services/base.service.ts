import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  mainAppURL: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private httpclient: HttpClient) { 
    this.mainAppURL = baseUrl;      
}

  // GET
  get<T>(path:string): Observable<T> {
 
      return this.httpclient.get<T>(path);
    
  }  


}
