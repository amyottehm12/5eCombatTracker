import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, firstValueFrom } from 'rxjs';

import { IMonster } from '../models/IMonster';

import { EncounterService } from './api-services/encounter.service';
import { MonsterService } from './api-services/monster.service';
import { MonsterAttackService } from './api-services/monster-attack.service';
import { DieRoller } from '../shared-helpers/die-roller';
import { IEncounter } from '../models/IEncounter';

@Injectable({
  providedIn: 'root'
})
export class EncounterHandlerService {

    public monsters: Observable<IMonster[]> = new Observable<IMonster[]>;
    private _monsters: BehaviorSubject<IMonster[]> = new BehaviorSubject<IMonster[]>([]);
    private _internalMonsters: IMonster[] = [];

    constructor(private monsterService: MonsterService,
                private monsterAttackService: MonsterAttackService,
                private dieRoller: DieRoller) {
          this.monsters = this._monsters.asObservable();
    }

    public getMonsters(): Observable<IMonster[]> {
        return this.monsters;
    }   

    private setMonsters(): void {
        this._monsters.next(this._internalMonsters);
    }

    public async setupMonsterData(monsterNames: string[]): Promise<void> {
        await this.resetMonsters();

        for (let i = 0; i < monsterNames.length; i++) {
            let response = await firstValueFrom(this.monsterService.getMonsterData(monsterNames[i]));
            response.initiative = await this.dieRoller.rollDie(20, 0);
            response.id = i;
            this._internalMonsters.push(response);
        }

        await this.initiativeOrder();
        this.setMonsters();
    }

    private async initiativeOrder(): Promise<void> {
        this._internalMonsters.sort((a,b) => (b.initiative > a.initiative) ? 1 : ((a.initiative > b.initiative) ? -1 : 0));
    }

    public async shiftMonsters(): Promise<void> {
        let hold: IMonster = this._internalMonsters[0];

        for (let i = 0; i < this._internalMonsters.length - 1; i++) {
          this._internalMonsters[i] = this._internalMonsters[i+1];
        } 

        this._internalMonsters[this._internalMonsters.length - 1] = hold;
        
        this.setMonsters()
    }

    public async setMonsterAttack(): Promise<void> {
        const response = await firstValueFrom(
            this.monsterAttackService.getMonsterAttack(this._internalMonsters[0].name)
        );
        response.toHitResult = await this.dieRoller.rollDie(20, response.hitRoll);
        response.damageResult = await this.dieRoller.rollDie(response.damageDie, response.damageBonus);
        
        this._internalMonsters[0].attacks = response;
        this.setMonsters();
    }

    private async resetMonsters(): Promise<void> {
        this._internalMonsters = [];
        this.setMonsters();
    }

}