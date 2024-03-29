import { Component, Input } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';

import { IMonster } from 'src/app/core/models/IMonster';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';
import { CombatLogComponent } from '../combat-log/combat-log.component';

@Component({
  selector: 'app-round-handler',
  templateUrl: './round-handler.component.html',
  styleUrls: ['./round-handler.component.css']
})
export class RoundHandlerComponent {
  public monsters: IMonster[] = [];
  public combatLog: string[] = [];
  public currentMonster!: IMonster;

  public currentTurn: number = 0;
  public currentRound: number = 0;

  @Input() public displayEncounter: boolean = false;
  public activationReady: boolean = false;
  private firstRound: boolean = true;

  constructor(private encounterHandler: EncounterHandlerService,
              private dialog: MatDialog) {
    this.getMonsters();
    this.getLog();
    this.roundReset();
  }

  getMonsters(): void {
    this.encounterHandler.getMonsters()
    .subscribe((data: IMonster[]) =>
    {
      this.monsters = data
    })
  }

  getLog(): void {
    this.encounterHandler.getLog()
    .subscribe((data: string[])=>
    {
      this.combatLog = data
    })
  }

  async roundHandler(): Promise<void> {
    this.activationReady = true;
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

    await this.encounterHandler.setMonsterAttack(this.currentRound);
    
    this.currentMonster = this.monsters[0];
  }

  async showLogModal(): Promise<void> {
      const dialogRef = this.dialog.open(CombatLogComponent, { 
        autoFocus: false, data: this.combatLog
      });
  }
  
  async roundReset(): Promise<void> {
    this.firstRound = true;
    this.activationReady = false;
    this.currentRound = 1;
    this.encounterHandler.logReset();
  }
}