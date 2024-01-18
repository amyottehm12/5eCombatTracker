import { Component } from '@angular/core';
import { IMonster } from 'src/app/core/models/IMonster';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';

@Component({
  selector: 'app-monster-details',
  templateUrl: './monster-details.component.html',
  styleUrls: ['./monster-details.component.css']
})
export class MonsterDetailsComponent {
  public currentMonster!: IMonster;
  
  constructor(private encounterHandler: EncounterHandlerService) {
    this.getMonsters();
  }

  getMonsters(): void {
    this.encounterHandler.getMonsters()
    .subscribe((data: IMonster[]) =>
    {
      this.currentMonster = data[0];
    })
  }
}