import { Component, OnInit } from '@angular/core';
import { first, firstValueFrom } from 'rxjs';
import { IEncounter } from 'src/app/model/IEncounter';
import { IMonster } from 'src/app/model/IMonster';
import { BiomeTypeService } from 'src/app/services/biometype.service';
import { EncounterService } from 'src/app/services/encounter.service';
import { MonsterService } from 'src/app/services/monster.service';


@Component({
  selector: 'app-encounter-generator',
  templateUrl: './encounter-generator.component.html',
  styleUrls: ['./encounter-generator.component.css']
})
export class EncounterGeneratorComponent implements OnInit {

  constructor(private encounterService : EncounterService, 
              private biomeTypeService: BiomeTypeService,
              private monsterService: MonsterService) { 
  }

  public monsters: IMonster[] = [];
  public encounter!: IEncounter;
  public biomeTypes!: string[];
  public biomeType!: string;
  
  ngOnInit() {
    this.getAllBiomeTypes();
  }

  async encounterHandler() {
    this.monsters = [];
    await this.getRandomEncounter();

    await this.encounter.monsters.forEach(monster => {
        this.getMonsterData(monster);
      })
    
    
  }

  async getRandomEncounter() {
    const response = await firstValueFrom(this.encounterService.getRandomEncounter(this.biomeType));
    this.encounter = response;
  }

  async getMonsterData(monster: string) {
    const response = await firstValueFrom(this.monsterService.getMonsterData(monster));
    response.initiative = this.encounterService.getInitiativeValue();
    this.monsters.push(response);
  }

  sortFn = (a: IMonster, b: IMonster): number => {
    console.log("sortFn");
    if (a.initiative < b.initiative) return -1;
    if (a.initiative === b.initiative) return 0; 
    if (a.initiative > b.initiative) return 1;
    else return 1;
  }

  getAllBiomeTypes() {
    this.biomeTypeService.getAllBiomeTypes()
    .subscribe((data: string[]) =>
    {
      this.biomeTypes = data
    })
  }

  onSelected(data:string) {
    this.biomeType = data;
  }

}
