import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { IMonster } from '../models/IMonster';

import { MonsterAttackService } from './api-services/monster-attack.service';
import { DieRoller } from '../shared-helpers/die-roller';
import { IRollResult } from "../models/IRollResult";
import { IMonsterEncounter } from '../models/IEncounter';
import { environmentVariables } from 'src/environments/variables';
import { Observables } from './observables';
import { IMonsterAttackResult } from '../models/IMonsterAttack';

@Injectable({
  providedIn: 'root'
})
export class EncounterHandlerService extends Observables {
    generatedId: number = 0;

    constructor(private monsterAttackService: MonsterAttackService,
                private dieRoller: DieRoller) {
          super();
    }

    public async setupMonsterData(monsterEncounter: IMonsterEncounter[]): Promise<void> {
        this.resetMonsters();
        for (let i = 0; i < monsterEncounter.length; i++) {
            for (let j = 1; j <= monsterEncounter[i].quantity; j++) {
                let initiative = await this.dieRoller.rollDie(20, 0, 1, false);
                this.generatedId++;

                this._internalMonsters.push({
                    id: monsterEncounter[i].monster.id,
                    name: monsterEncounter[i].monster.name,
                    hp: monsterEncounter[i].monster.hp,
                    currentHp: monsterEncounter[i].monster.hp,
                    ac: monsterEncounter[i].monster.ac,
                    initiative: initiative,
                    attacks: monsterEncounter[i].monster.attacks,
                    attackResult: [],
                    imageURL: this.generateImageURL(monsterEncounter[i].monster.name),
                    generatedMonsterIdentifier: this.generatedId,
                    player: false
                });
            }
        }

        this._internalCharacterList.forEach(character => {
            this._internalMonsters.push({
                id: 0,
                name: character.name,
                hp: 0,
                currentHp: 0,
                ac: 0,
                initiative: character.initiative,
                attacks: this._internalMonsters[0].attacks,
                attackResult: [],
                imageURL: "",
                generatedMonsterIdentifier: character.generatedId,
                player: true
            })
        });

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

    public async setMonsterAttack(round: number): Promise<void> {
        if (this._internalMonsters[0].player) {
            this.writePlayerTurnToLog(this._internalMonsters[0].name, round);
            return;
        }

        const response = await firstValueFrom(
            this.monsterAttackService.getMonsterAttack(this._internalMonsters[0].id)
        );
        this._internalMonsters[0].attacks = response;

        let attackResult: IMonsterAttackResult[] = [];
        let rollResult: IRollResult;
        for (let i = 0; i < response.numberOfAttacks; i++)
        {
            rollResult = await this.dieRoller.rollDieCritable(20, response.hitRoll, 1);
            attackResult.push({
                toHitResult: rollResult.result,
                damageResult: await this.dieRoller.rollDie(
                    response.damageDie, 
                    response.damageBonus, 
                    response.numberOfDice, 
                    rollResult.crit),
                crit: rollResult.crit
            });
        }

        this._internalMonsters[0].attackResult = attackResult;
        this.writeAttackToLog(this._internalMonsters[0], round)

        this.setMonsters();
    }

    public writeAttackToLog(monsterData: IMonster, round: number) {
        for (let i = 0; i < monsterData.attackResult.length; i++) {
            this._logEntry = 
                `${monsterData.name} ${monsterData.generatedMonsterIdentifier}
                attack ${round} with ${monsterData.attacks.weaponName}
                ${monsterData.attackResult[i].crit ? "critting" : "hitting"}
                 with a ${monsterData.attackResult[i].toHitResult}
                 for ${monsterData.attackResult[i].damageResult} damage`;
                this.logPush();
            }
    }

    public writePlayerTurnToLog(name: string, round: number) {
        this._logEntry = `${name}'s turn ${round}`;
        this.logPush();
    }

    private async resetMonsters(): Promise<void> {
        this._internalMonsters = [];
        this.setMonsters();
    }

    public async setHealth(id: number, hp: number): Promise<void> {
        let index: number = this._internalMonsters.findIndex(x => x.generatedMonsterIdentifier == id);
        this.writeHpChangeToLog(this._internalMonsters[index].name, this._internalMonsters[index].currentHp, hp);
        this._internalMonsters[index].currentHp = hp;
        this.setMonsters();
    }

    private async writeHpChangeToLog(monsterName: string, currentHp: number,  newMonsterHp: number): Promise<void> {
        let hpChange: number = currentHp - newMonsterHp;
        if (hpChange > 0) {
            this._logEntry = `${monsterName} lost ${hpChange} health`;
        }
        else {
            this._logEntry = `${monsterName} gained ${Math.abs(hpChange)} health`;
        }
        this.logPush();
    }

    public async removeMonster(id: number): Promise<void> {
        let index: number = this._internalMonsters.findIndex(x => x.generatedMonsterIdentifier == id);
        this.writeMonsterDeathToLog(this._internalMonsters[index].name, this._internalMonsters[index].generatedMonsterIdentifier);
        this._internalMonsters.splice(index, 1);
        this.setMonsters();
    }

    private async writeMonsterDeathToLog(monsterName: string, monsterId: number): Promise<void> {
        this._logEntry = `${monsterName} ${monsterId} died`;
        this.logPush();
    }

    private  generateImageURL(name: string): string {
        return environmentVariables.imageBaseURL + name.replace(' ', '-').toLowerCase() + '.png';
    }

    public async addCharacter(name: string, initiative: number): Promise<void> {
        this._internalCharacterList.push({
            name: name,
            initiative: initiative,
            generatedId: this.generatedId ++
        });

        this.setCharacters();
    }

    public async removeCharacter(id: number): Promise<void> {
        this._internalCharacterList.splice(this._internalCharacterList.findIndex(x => x.generatedId == id), 1);
        this.setCharacters();
    }

    public async updateCharacterName(newName: string, id: number): Promise<void> {
        this._internalCharacterList[this._internalCharacterList.findIndex(x => x.generatedId == id)].name = newName;
        this.setCharacters();
    } 

    public async updateCharacterInitiative(newInitiative: number, id: number): Promise<void> {
        this._internalCharacterList[this._internalCharacterList.findIndex(x => x.generatedId == id)].initiative = newInitiative;
        this.setCharacters();
    } 

}