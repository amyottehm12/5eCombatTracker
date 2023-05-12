import { Component, EventEmitter, Input, Output } from '@angular/core';

import { IMonster } from 'src/app/core/models/IMonster';
import { EncounterGeneratorService } from 'src/app/core/services/encounter-generator.service';

@Component({
  selector: 'app-round-handler',
  templateUrl: './round-handler.component.html',
  styleUrls: ['./round-handler.component.css']
})
export class RoundHandlerComponent {
  constructor(private encounterHandler: EncounterGeneratorService) { 

  }
  
  @Output("monsterCreatedOrChanged") monsterCreatedOrChanged: EventEmitter<IMonster[]> = new EventEmitter;

  @Input() public monsters: IMonster[] = [];
  public currentMonster!: IMonster;

  public currentTurn: number = 0;
  public currentRound: number = 0;

  @Input() public displayEncounter: boolean = false;
  public activationReady: boolean = false;
  private firstRound: boolean = true;

  async roundHandler(): Promise<void> {
    console.log("round handler begin");
    if (this.currentTurn == this.monsters.length) {
      this.currentRound ++;
      this.currentTurn = 0;
    }
    else {
      this.currentTurn ++;
    }
    
    console.log("processing attack " + this.currentTurn + " of round: " + this.currentRound);
    this.monsters[0].attacks = 
    await this.encounterHandler.setMonsterAttack(this.monsters[0].name);
    console.log("Attack set");
    
    if (this.firstRound) this.firstRound = false;
    else {
      console.log("reordering monsters");
      await this.reorderMonsters();
    }

    console.log("setting current monster");
    this.currentMonster = this.monsters[0];
    console.log("setting activation ready to display attack");
    this.activationReady = true;
  }
  
  async roundReset(): Promise<void> {
    this.firstRound = true;
    this.activationReady = false;
    this.currentRound = 1;
  }

  async reorderMonsters(): Promise<void> {
    console.log("reordering monsters");
    let hold: IMonster = this.monsters[0];

    for (let i = 0; i < this.monsters.length - 1; i++) {
      this.monsters[i] = this.monsters[i+1];
    }

    this.monsters[this.monsters.length - 1] = hold;
    console.log("emitting monster order changed");
    await this.monsterCreatedOrChanged.emit(this.monsters);
  }

}
