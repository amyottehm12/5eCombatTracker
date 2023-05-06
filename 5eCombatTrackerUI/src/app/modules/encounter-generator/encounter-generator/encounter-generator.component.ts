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
  public currentMonster!: IMonster;
  public encounter!: IEncounter;
  public biomeTypes!: string[];
  public biomeType!: string;

  public currentInitiative!: number;
  public currentRound: number = 0;
  
  public displayEncounter: boolean = false;
  public activationReady: boolean = false;
  private firstRound: boolean = true;
  
  ngOnInit() {
    this.setBiomeTypes();
  }

  async encounterSetup() {
    await this.roundAndEncounterReset();

    console.log("calling set random encounter");
    await this.setRandomEncounter();

    console.log("calling set monster data");
    for (let i = 0; i < this.encounter.monsters.length; i++){
      await this.setMonsterData(this.encounter.monsters[i]);
    }
    
    console.log("calling order function");
    await this.orderMonsterData();

    this.displayEncounter = true;
  }

  async roundHandler(): Promise<void> {
    this.activationReady = false;

    if (this.firstRound) {
      //Set initial initiative
      this.firstRoundSetup()
    }
    else {
      //if we've reached the end of turn order, start new turn order
      if (this.currentInitiative == this.monsters.length - 1) {
        this.currentRound ++;
        this.currentInitiative = 0;
      }
      else {
        this.currentInitiative ++;
      }
    }

    await this.setMonsterAttack();
    this.currentMonster = this.monsters[this.currentInitiative];
    this.activationReady = true;
  }

  async roundAndEncounterReset(): Promise<void> {
    this.monsters = [];
    this.firstRound = true;
    this.activationReady = false;
    this.displayEncounter = false;
  }

  firstRoundSetup(): void {
    this.currentInitiative = 0;
    this.currentRound = 1;
    this.firstRound = false;
  }

  async setRandomEncounter(): Promise<void> {
    const response = await firstValueFrom(this.encounterService.getRandomEncounter(this.biomeType));
    this.encounter = response;
    console.log("random encounter set");
  }

  async setMonsterData(monster: string): Promise<void> {
    const response = await firstValueFrom(this.monsterService.getMonsterData(monster));
    response.initiative = await this.encounterService.getInitiativeValue();
    this.monsters.push(response);
    console.log("monster initiative set: " + response.initiative);
  }

  async orderMonsterData(): Promise<void> {
    console.log(this.monsters.sort((a,b) => (b.initiative > a.initiative) ? 1 : ((a.initiative > b.initiative) ? -1 : 0)));
  }

  async setMonsterAttack(): Promise<void> {
    const response = await firstValueFrom(this.monsterAttackService.getMonsterAttack(this.monsters[this.currentInitiative].name))
    this.monsters[this.currentInitiative].attacks = response;
  }

  setBiomeTypes(): void {
    this.biomeTypeService.getAllBiomeTypes()
    .subscribe((data: string[]) =>
    {
      this.biomeTypes = data
    })
  }

  onSelected(data:string): void {
    this.biomeType = data;
  }

}
