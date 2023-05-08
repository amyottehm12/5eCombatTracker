import { Component, Input } from '@angular/core';

import { EncounterHandler } from 'src/app/helpers/encounter-handler';

import { IMonster } from 'src/app/model/IMonster';

@Component({
  selector: 'app-monster-attacks',
  templateUrl: './monster-attacks.component.html',
  styleUrls: ['./monster-attacks.component.css']
})
export class MonsterAttacksComponent {
  constructor(private encounterHandler: EncounterHandler) { }


  @Input() public monsters: IMonster[] = [];
  public currentMonster!: IMonster;

  public currentInitiative!: number;
  public currentRound: number = 0;

  @Input() public displayEncounter: boolean = false;
  public activationReady: boolean = false;
  private firstRound: boolean = true;

  async roundHandler(): Promise<void> {
    if (this.firstRound) {
      //Set initial initiative
      await this.firstRoundSetup()
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

    this.monsters[this.currentInitiative].attacks = 
    await this.encounterHandler.setMonsterAttack(this.monsters[this.currentInitiative].name);

    this.currentMonster = this.monsters[this.currentInitiative];
    this.activationReady = true;
  }
  
  async firstRoundSetup(): Promise<void> {
    this.currentInitiative = 0;
    this.currentRound = 1;
    this.firstRound = false;
  }

  async roundAndEncounterReset(): Promise<void> {
    this.firstRound = true;
    this.activationReady = false;
  }

}
