import { Component, EventEmitter, Input, Output } from '@angular/core';

import { IMonster } from 'src/app/core/models/IMonster';
import { CombatLogService } from 'src/app/core/services/combat-log.service';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';



@Component({
  selector: 'app-round-handler',
  templateUrl: './round-handler.component.html',
  styleUrls: ['./round-handler.component.css']
})
export class RoundHandlerComponent {
  public monsters: IMonster[] = [];
  public currentMonster!: IMonster;

  public currentTurn: number = 0;
  public currentRound: number = 0;

  @Input() public displayEncounter: boolean = false;
  public activationReady: boolean = false;
  private firstRound: boolean = true;

  constructor(private encounterHandler: EncounterHandlerService,
              private logService: CombatLogService) {
    this.getMonsters();
  }

  getMonsters(): void {
    this.encounterHandler.getMonsters()
    .subscribe((data: IMonster[]) =>
    {
      this.monsters = data
    })
  }

  async roundHandler(): Promise<void> {
    this.activationReady = false;
    if (this.currentTurn == this.monsters.length - 1) {
      this.currentRound ++;
      this.currentTurn = 0;
    }
    else if (!this.firstRound) {
      this.currentTurn ++;
    }
    
    if (this.firstRound) this.firstRound = false;
    else {
      this.encounterHandler.shiftMonsters();
    }

    await this.encounterHandler.setMonsterAttack();
    
    this.currentMonster = this.monsters[0];
    this.activationReady = true;
    this.writeAttackToLog(this.currentMonster);
  }

  async showLogModal(): Promise<void> {

  }
  
  async roundReset(): Promise<void> {
    this.firstRound = true;
    this.activationReady = false;
    this.currentRound = 1;
  }

  public writeAttackToLog(monsterData: IMonster) {
    this.logService.logPush(
      monsterData.name + " " +
      "attack " + this.currentRound + " " +
      monsterData.attacks.weaponName + " " +
      monsterData.attacks.damageResult
    );
}


}
