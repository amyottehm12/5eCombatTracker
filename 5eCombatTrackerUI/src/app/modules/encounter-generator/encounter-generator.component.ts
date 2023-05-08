import { Component, OnInit, ViewChild } from '@angular/core';

import { EncounterHandler } from 'src/app/helpers/encounter-handler';
import { BiomeTypeService } from 'src/app/services/biometype.service';

import { IEncounter } from 'src/app/model/IEncounter';
import { IMonster } from 'src/app/model/IMonster';
import { MonsterAttacksComponent } from '../monster-attacks/monster-attacks.component';



@Component({
  selector: 'app-encounter-generator',
  templateUrl: './encounter-generator.component.html',
  styleUrls: ['./encounter-generator.component.css']
})
export class EncounterGeneratorComponent implements OnInit {

  constructor(private biomeTypeService: BiomeTypeService,
              private encounterHandler: EncounterHandler) { 
  }

  @ViewChild(MonsterAttacksComponent) child!: any;

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
    await this.roundAndEncounterReset();
    await this.child.roundAndEncounterReset();

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

  async roundAndEncounterReset(): Promise<void> {
    this.monsters = [];
    //this.firstRound = true;
    //this.activationReady = false;
    this.displayEncounter = false;
  }

  async orderMonsterData(): Promise<void> {
    console.log(this.monsters.sort((a,b) => (b.initiative > a.initiative) ? 1 : ((a.initiative > b.initiative) ? -1 : 0)));
  }

}
