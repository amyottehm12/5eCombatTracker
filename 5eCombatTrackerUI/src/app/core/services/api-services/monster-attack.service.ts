import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environmentVariables } from 'src/environments/variables';

import { IMonsterAttack } from '../../models/IMonsterAttack';

@Injectable({
  providedIn: 'root'
})
export class MonsterAttackService {

  constructor(private http: HttpClient) {
  }

  getMonsterAttack(monsterId: number): Observable<IMonsterAttack> {
    return this.http.get<IMonsterAttack>(environmentVariables.baseURL + 'api/MonsterAttack/random/?id=' + monsterId);
  }
}
