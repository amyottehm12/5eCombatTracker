import { Component, OnInit, ViewChild } from '@angular/core';

import { EncounterHelper } from 'src/app/helpers/encounter-helper';
import { BiomeTypeService } from 'src/app/services/biometype.service';

import { IEncounter } from 'src/app/model/IEncounter';
import { IMonster } from 'src/app/model/IMonster';
import { RoundHandler } from '../round-handler/round-handler.component';

@Component({
  selector: 'app-encounter-handler',
  templateUrl: './encounter-handler.component.html',
  styleUrls: ['./encounter-handler.component.css']
})
export class EncounterHandlerComponent implements OnInit {

  constructor(private biomeTypeService: BiomeTypeService,
              private encounterHandler: EncounterHelper) { 
  }

  @ViewChild(RoundHandler) child!: any;

  public encounter!: IEncounter;
  public monsters: IMonster[] = [];

  public biomeTypes!: string[];
  public biomeType!: string;
  
  public displayEncounter: boolean = false;
  
  ngOnInit() {
    this.setBiomeTypes();
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

  async encounterSetup() {
    console.log("Resetting round");
    await this.encounterReset();
    await this.child.roundReset();

    console.log("Calling set random encounter");
    this.encounter = await this.encounterHandler.setRandomEncounter(this.biomeType)
    console.log("Random encounter set");

    console.log("Calling set monster data");
    for (let i = 0; i < this.encounter.monsters.length; i++) {
      this.monsters.push(await this.encounterHandler.setMonsterData(this.encounter.monsters[i]));
      console.log("Monster initiative set: " + this.monsters[i].initiative);
    }
    console.log("All initiatives set");
    
    console.log("Calling order function");
    await this.orderMonsterData();
    console.log("Monsters ordered");

    this.displayEncounter = true;
  }

  async encounterReset(): Promise<void> {
    this.monsters = [];
    this.displayEncounter = false;
  }

  async orderMonsterData(): Promise<void> {
    console.log(this.monsters.sort((a,b) => (b.initiative > a.initiative) ? 1 : ((a.initiative > b.initiative) ? -1 : 0)));
  }

}
