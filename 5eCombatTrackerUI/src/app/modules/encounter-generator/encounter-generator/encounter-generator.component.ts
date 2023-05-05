import { Component, OnInit } from '@angular/core';
import { first, firstValueFrom } from 'rxjs';
import { IEncounter } from 'src/app/model/IEncounter';
import { IMonster } from 'src/app/model/IMonster';
import { BiomeTypeService } from 'src/app/services/biometype.service';
import { EncounterService } from 'src/app/services/encounter.service';
import { MonsterAttackService } from 'src/app/services/monster-attack.service';
import { MonsterService } from 'src/app/services/monster.service';


@Component({
  selector: 'app-encounter-generator',
  templateUrl: './encounter-generator.component.html',
  styleUrls: ['./encounter-generator.component.css']
})
export class EncounterGeneratorComponent implements OnInit {

  constructor(private encounterService : EncounterService, 
              private biomeTypeService: BiomeTypeService,
              private monsterService: MonsterService,
              private monsterAttackService: MonsterAttackService) { 
  }

  public monsters: IMonster[] = [];
  public encounter!: IEncounter;
  public biomeTypes!: string[];
  public biomeType!: string;
  public currentInitiative!: number;
  public currentRound: number = 0;
  public firstRound: boolean = true;

  ngOnInit() {
    this.getAllBiomeTypes();
  }

  async encounterHandler() {
    this.monsters = [];
    await this.getRandomEncounter();

    await this.encounter.monsters.forEach(monster => {
        this.getMonsterData(monster);
      })
  }

  roundHandler() {
    if (this.firstRound) {
      //Set initial initiative
      this.firstRoundSetup()
    }
    else {
      //if we've reached the end of turn order, start new turn order
      if (this.currentInitiative == this.monsters.length) {
        this.currentRound ++;
        this.currentInitiative = 0;
      }
      else {
        this.currentInitiative ++;
      }
    }

    this.getMonsterAttack();
  }

  firstRoundSetup() {
    this.currentInitiative = 0;
    this.currentRound = 1;
    this.firstRound = false;
  }

  async getRandomEncounter() {
    const response = await firstValueFrom(this.encounterService.getRandomEncounter(this.biomeType));
    this.encounter = response;
  }

  async getMonsterData(monster: string) {
    const response = await firstValueFrom(this.monsterService.getMonsterData(monster));
    response.initiative = this.encounterService.getInitiativeValue();
    this.monsters.push(response);
  }

  async getMonsterAttack() {
    const response = await firstValueFrom(this.monsterAttackService.getMonsterAttack(this.monsters[this.currentInitiative].name))
    this.monsters[this.currentInitiative].attacks = response;
  }

  sortFn = (a: IMonster, b: IMonster): number => {
    console.log("sortFn");
    if (a.initiative < b.initiative) return -1;
    if (a.initiative === b.initiative) return 0; 
    if (a.initiative > b.initiative) return 1;
    else return 1;
  }

  getAllBiomeTypes() {
    this.biomeTypeService.getAllBiomeTypes()
    .subscribe((data: string[]) =>
    {
      this.biomeTypes = data
    })
  }

  onSelected(data:string) {
    this.biomeType = data;
  }

}
