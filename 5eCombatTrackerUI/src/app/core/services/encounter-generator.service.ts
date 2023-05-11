import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";

import { EncounterService } from "./encounter.service";
import { MonsterService } from "./monster.service";
import { MonsterAttackService } from "./monster-attack.service";
import { DieRoller } from "../shared-helpers/die-roller";

import { IEncounter } from "../models/IEncounter";
import { IMonster } from "../models/IMonster";
import { IMonsterAttack } from "../models/IMonsterAttack";

@Injectable({
    providedIn: 'root'
  })
  export class EncounterGeneratorService {

    constructor(private encounterService : EncounterService,
                private monsterService: MonsterService,
                private monsterAttackService: MonsterAttackService,
                private dieRoller: DieRoller) {
        console.log('Constructing EncounterGeneratorService, including EncounterService, MonsterService, MonsterAttackService, DieRoller')
    }

    async setRandomEncounter(biomeType: string): Promise<IEncounter> {
        const response = await firstValueFrom(this.encounterService.getRandomEncounter(biomeType));

        return response;
    }

    async setMonsterData(monster: string): Promise<IMonster> {
        const response = await firstValueFrom(this.monsterService.getMonsterData(monster));
        response.initiative = await this.dieRoller.rollDie(20, 0);

        return response;
    }

    async setMonsterAttack(monsterName: string): Promise<IMonsterAttack> {
        const response = await firstValueFrom(this.monsterAttackService.getMonsterAttack(monsterName))
        response.toHitResult = await this.dieRoller.rollDie(20, response.hitRoll);
        response.damageResult = await this.dieRoller.rollDie(response.damageDie, response.damageBonus);
    
        return response;
    }

  }