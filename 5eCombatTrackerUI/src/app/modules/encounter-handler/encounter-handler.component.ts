import { Component, ViewChild } from '@angular/core';

import { RoundHandler } from './round-handler/round-handler.component';

import { IMonster } from 'src/app/core/model/IMonster';

@Component({
  selector: 'app-encounter-handler',
  templateUrl: './encounter-handler.component.html',
  styleUrls: ['./encounter-handler.component.css']
})
export class EncounterHandlerComponent {

  @ViewChild(RoundHandler) child!: any;

  public encounterName: string = "";
  public monsters: IMonster[] = [];

  public displayEncounter: boolean = false;

  reset() {
    this.child.roundReset();
  }

  monsterCreated(monsters: IMonster[]) {
    this.monsters = monsters;
  }

  encounterReady(displayEncounter: boolean) {
    this.displayEncounter = displayEncounter;
  }

  encounterNameSet(encounterName: string) {
    this.encounterName = encounterName;
  }

}
