import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';

import { environmentVariables } from 'src/environments/variables';

import { IMonster } from '../../models/IMonster';

@Injectable({
  providedIn: 'root'
})
export class MonsterService {

  constructor(private http: HttpClient) {
  }

  getMonsterData(monsterId: number): Observable<IMonster> {
    return this.http.get<IMonster>(environmentVariables.baseURL + 'api/Monster/' + monsterId);
  }

}
