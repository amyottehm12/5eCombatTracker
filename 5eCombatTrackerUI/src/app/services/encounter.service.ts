import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { IEncounter } from '../model/IEncounter';
import { environmentVariables } from 'src/environments/variables';

@Injectable({
  providedIn: 'root'
})
export class EncounterService {

  constructor(private http: HttpClient) {
      console.log('Constructing EncounterService, including HttpClient') 
  }

  getRandomEncounter(BiomeType: string): Observable<IEncounter> {
    return this.http.get<IEncounter>(environmentVariables.baseURL + 'api/RandomEncounter/GetRandomEncounter/' + BiomeType);
  }

  async getInitiativeValue(initiative = 0): Promise<number> {
    return Math.floor((Math.random() * 20) + 1 + initiative);
  }

}
