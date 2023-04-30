import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { environmentVariables } from 'src/environments/variables';

@Injectable({
  providedIn: 'root'
})
export class BiomeTypeService {

  constructor(private http: HttpClient) {
    console.log('Constructing BiomeserviceService, including HttpClient') 
  }

  getAllBiomeTypes(): Observable<string[]> {
    return this.http.get<string[]>(environmentVariables.baseURL + 'api/BiomeType/GetAllBiomes');
  }
}
