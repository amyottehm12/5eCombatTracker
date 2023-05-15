import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { IMonster } from '../models/IMonster';

import { MonsterAttackService } from './api-services/monster-attack.service';
import { DieRoller } from '../shared-helpers/die-roller';
import { IMonsterEncounter } from '../models/IEncounter';
import { environmentVariables } from 'src/environments/variables';
import { Observables } from './observables';

@Injectable({
  providedIn: 'root'
})
export class EncounterHandlerService extends Observables {


    constructor(private monsterAttackService: MonsterAttackService,
                private dieRoller: DieRoller) {
          super();
    }

    public async setupMonsterData(monsterEncounter: IMonsterEncounter[]): Promise<void> {
        this.resetMonsters();
        let generatedMonsterIdentifier = 0;
        for (let i = 0; i < monsterEncounter.length; i++) {
            console.log(monsterEncounter);
            for (let j = 1; j <= monsterEncounter[i].quantity; j++) {
                let initiative = await this.dieRoller.rollDie(20, 0);
                generatedMonsterIdentifier++;

                this._internalMonsters.push({
                    id: monsterEncounter[i].monster.id,
                    name: monsterEncounter[i].monster.name,
                    hp: monsterEncounter[i].monster.hp,
                    currentHp: monsterEncounter[i].monster.hp,
                    ac: monsterEncounter[i].monster.ac,
                    initiative: initiative,
                    attacks: monsterEncounter[i].monster.attacks,
                    imageURL: this.generateImageURL(monsterEncounter[i].monster.name),
                    generatedMonsterIdentifier: generatedMonsterIdentifier
                });
            }
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
            this.monsterAttackService.getMonsterAttack(this._internalMonsters[0].id)
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

    private  generateImageURL(name: string): string {
        return environmentVariables.imageBaseURL + name.replace(' ', '-').toLowerCase() + '.png';
    }

}