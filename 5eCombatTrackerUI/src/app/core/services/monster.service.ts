import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';

import { environmentVariables } from 'src/environments/variables';

import { IMonster } from '../core/model/IMonster';

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
