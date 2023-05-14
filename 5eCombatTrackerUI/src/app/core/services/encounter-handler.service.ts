import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { IMonster } from '../models/IMonster';

import { MonsterService } from './api-services/monster.service';
import { MonsterAttackService } from './api-services/monster-attack.service';
import { CombatLogService } from './combat-log.service';
import { DieRoller } from '../shared-helpers/die-roller';
import { Observables } from './observables';

@Injectable({
  providedIn: 'root'
})
export class EncounterHandlerService extends Observables {

    constructor(private monsterService: MonsterService,
                private monsterAttackService: MonsterAttackService,
                private dieRoller: DieRoller) {
          super();
    }

    public async setupMonsterData(monsterNames: string[]): Promise<void> {
        await this.resetMonsters();
        
        for (let i = 0; i < monsterNames.length; i++) {
            let response = await firstValueFrom(this.monsterService.getMonsterData(monsterNames[i]));
            response.initiative = await this.dieRoller.rollDie(20, 0);
            response.currentHp = response.hp;
            response.id = i;
            response.imageURL = "assets/monster-images/" + response.name + ".png";
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

    public async removeMonster(id: number): Promise<void> {
        this._internalMonsters.splice(this._internalMonsters.findIndex(x => x.id == id), 1);
        this.setMonsters();
    }

}