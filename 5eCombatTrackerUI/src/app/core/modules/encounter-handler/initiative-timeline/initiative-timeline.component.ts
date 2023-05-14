import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { IMonster } from 'src/app/core/models/IMonster';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';

@Component({
  selector: 'app-initiative-timeline',
  templateUrl: './initiative-timeline.component.html',
  styleUrls: ['./initiative-timeline.component.css']
})
export class InitiativeTimelineComponent {
  @Input() public encounterName: string = "";
  @Input() public displayEncounter: boolean = false;
  @Output("displayEncounterChanged") displayEncounterChanged: EventEmitter<boolean> = new EventEmitter;
  public monsters: IMonster[] = [];

  constructor(private encounterHandler: EncounterHandlerService) {
    this.getMonsters();
  }
  
  getMonsters(): void {
    this.encounterHandler.getMonsters()
    .subscribe((data: IMonster[]) =>
    {
      this.monsters = data;
      if (this.monsters.length == 0) { 
        this.displayEncounter = false;
        this.displayEncounterChanged.emit(false);
      }
    })
  }

  getURL(url: string) {
    return url;
  }

  async onSelected(data:string, id:string): Promise<void> {
    if (data === "0") await this.encounterHandler.removeMonster(parseInt(id));
  }
}