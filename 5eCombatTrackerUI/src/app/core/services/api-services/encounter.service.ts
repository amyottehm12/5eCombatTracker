import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';

import { environmentVariables } from 'src/environments/variables';
import { IEncounter } from '../../models/IEncounter';


@Injectable({
  providedIn: 'root'
})
export class EncounterService {

  constructor(private http: HttpClient) {
  }

  getRandomEncounter(BiomeType: string): Observable<IEncounter> {
    return this.http.get<IEncounter>(environmentVariables.baseURL + 'api/RandomEncounter/GetRandomEncounter/' + BiomeType);
  }
}
