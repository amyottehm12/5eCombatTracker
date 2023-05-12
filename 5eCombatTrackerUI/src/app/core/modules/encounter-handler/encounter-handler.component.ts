import { Component, ViewChild } from '@angular/core';

import { RoundHandlerComponent } from './round-handler/round-handler.component';

import { IMonster } from 'src/app/core/models/IMonster';
import { InitiativeTimelineComponent } from './initiative-timeline/initiative-timeline.component';

@Component({
  selector: 'app-encounter-handler',
  templateUrl: './encounter-handler.component.html',
  styleUrls: ['./encounter-handler.component.css']
})
export class EncounterHandlerComponent {

  @ViewChild(RoundHandlerComponent) roundHandlerChild!: any;
  @ViewChild(InitiativeTimelineComponent) initiativeTimelineChild!: any;

  public encounterName: string = "";
  public monsters: IMonster[] = [];

  public displayEncounter: boolean = false;

  reset() {
    this.roundHandlerChild.roundReset();
  }

  async monsterCreatedOrChanged(monsters: IMonster[]) {
    console.log("Encounter handler has heard monsters has created or been edited");
    this.monsters = monsters;
    console.log("Awaiting timeline update monsters");
    await this.initiativeTimelineChild.updateMonsters(monsters);
  }

  async monsterOrderUpdates(monsters: IMonster[]) {

  }

  encounterReady(displayEncounter: boolean) {
    this.displayEncounter = displayEncounter;
  }

  encounterNameSet(encounterName: string) {
    this.encounterName = encounterName;
  }

}
