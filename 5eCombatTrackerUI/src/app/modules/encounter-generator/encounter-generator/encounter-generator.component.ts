import { Component, OnInit } from '@angular/core';
import { IEncounter } from 'src/app/model/IEncounter';
import { BiomeTypeService } from 'src/app/services/biometype.service';
import { EncounterService } from 'src/app/services/encounter.service';

@Component({
  selector: 'app-encounter-generator',
  templateUrl: './encounter-generator.component.html',
  styleUrls: ['./encounter-generator.component.css']
})
export class EncounterGeneratorComponent implements OnInit {

  constructor(private encounterService : EncounterService, private biomeTypeService: BiomeTypeService) {  
    console.log('Constructing EncounterGeneratorComponent, injecting EncounterService, BiomeTypeService')
  }  

  public encounter!: IEncounter;
  public biomeTypes!: string[];
  public biomeType!: string;
  
  ngOnInit() {
    console.log('ngOnInit App.Component')
    // this.getRandomEncounter();
    this.getAllBiomeTypes();
  }

  getRandomEncounter() {
    this.encounterService.getRandomEncounter(this.biomeType)
    .subscribe((data: IEncounter) =>
    {
      this.encounter = data;
    });
  }

  getAllBiomeTypes() {
    this.biomeTypeService.getAllBiomeTypes()
    .subscribe((data: string[]) =>
    {
      this.biomeTypes = data
    })
  }

  onSelected(data:string) {
    console.log(data);
    this.biomeType = data;
  }

}
