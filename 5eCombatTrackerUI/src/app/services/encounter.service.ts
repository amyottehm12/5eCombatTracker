import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { IEncounterModel } from '../model/encountermodel';


@Injectable({
  providedIn: 'root'
})
export class EncounterService {

  constructor(private http: HttpClient) {
      console.log('Constructing EncounterService, including HttpClient') 
  }

  getRandomEncounter(): Observable<IEncounterModel> {
    return this.http.get<IEncounterModel>('https://localhost:7237/api/RandomEncounter/GetRandomEncounter/Dungeon');
  }

}
