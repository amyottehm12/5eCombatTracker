import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { IEncounter } from '../model/IEncounter';
import { environmentVariables } from 'src/environments/variables';
import { IMonster } from '../model/IMonster';

@Injectable({
  providedIn: 'root'
})
export class MonsterService {

  constructor(private http: HttpClient) {
    console.log('Constructing EncounterService, including HttpClient') 
  }

  getMonsterData(monster: string): Observable<IMonster> {
    return this.http.get<IMonster>(environmentVariables.baseURL + 'api/Monster/GetMonsterByName/' + monster);
  }

}
