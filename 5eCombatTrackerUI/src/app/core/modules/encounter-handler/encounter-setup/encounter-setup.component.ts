import { Component, EventEmitter, Output } from '@angular/core';

import { IEncounter } from 'src/app/core/models/IEncounter';
import { IMonster } from 'src/app/core/models/IMonster';
import { BiomeTypeService } from 'src/app/core/services/biome-type.service';
import { EncounterGeneratorService } from 'src/app/core/services/encounter-generator.service';



@Component({
  selector: 'app-encounter-setup',
  templateUrl: './encounter-setup.component.html',
  styleUrls: ['./encounter-setup.component.css']
})
export class EncounterSetupComponent {
  constructor(private biomeTypeService: BiomeTypeService,
              private encounterHandler: EncounterGeneratorService) { }

  @Output("reset") reset: EventEmitter<any> = new EventEmitter;
  @Output("monsterCreated") monsterCreated: EventEmitter<IMonster[]> = new EventEmitter;
  @Output("encounterReady") encounterReady: EventEmitter<boolean> = new EventEmitter; 
  @Output("encounterNameSet") encounterNameSet: EventEmitter<string> = new EventEmitter; 

  public encounter!: IEncounter;
  public monsters: IMonster[] = [];
  public biomeTypes: string[] = [];
  public biomeType!: string;

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

    this.encounterReady.emit(true);
    this.monsterCreated.emit(this.monsters);
    this.encounterNameSet.emit(this.encounter.name);
  }

  async encounterReset(): Promise<void> {
    this.monsters = [];
    this.encounterReady.emit(false);
    this.reset.emit();
  }

  async orderMonsterData(): Promise<void> {
    console.log(this.monsters.sort((a,b) => (b.initiative > a.initiative) ? 1 : ((a.initiative > b.initiative) ? -1 : 0)));
  }

  
}
