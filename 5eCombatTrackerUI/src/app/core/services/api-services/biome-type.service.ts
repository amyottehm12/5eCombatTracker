import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environmentVariables } from 'src/environments/variables';

@Injectable({
  providedIn: 'root'
})
export class BiomeTypeService {

  constructor(private http: HttpClient) {
  }

  getAllBiomeTypes(): Observable<string[]> {
    return this.http.get<string[]>(environmentVariables.baseURL + 'api/BiomeType');
  }
}
