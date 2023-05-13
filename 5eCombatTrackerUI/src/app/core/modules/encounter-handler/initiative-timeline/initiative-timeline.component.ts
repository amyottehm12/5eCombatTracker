import { Component, Input, OnInit } from '@angular/core';

import { IMonster } from 'src/app/core/models/IMonster';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';

@Component({
  selector: 'app-initiative-timeline',
  templateUrl: './initiative-timeline.component.html',
  styleUrls: ['./initiative-timeline.component.css']
})
export class InitiativeTimelineComponent {
  @Input() public encounterName: string = ""
  @Input() public displayEncounter: boolean = false;;
  public monsters: IMonster[] = [];

  constructor(private encounterHandler: EncounterHandlerService) {
    this.getMonsters();
  }
  
  getMonsters(): void {
    this.encounterHandler.getMonsters()
    .subscribe((data: IMonster[]) =>
    {
      this.monsters = data
    })
  }

  onSelected(data:string, id:string): void {
    if (data === "0") this.encounterHandler.removeMonster(parseInt(id));
  }
}