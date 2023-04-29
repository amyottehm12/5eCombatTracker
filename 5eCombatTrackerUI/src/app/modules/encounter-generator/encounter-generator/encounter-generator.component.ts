import { Component, OnInit } from '@angular/core';
import { IEncounterModel } from 'src/app/model/encountermodel';
import { EncounterService } from 'src/app/services/encounter.service';

@Component({
  selector: 'app-encounter-generator',
  templateUrl: './encounter-generator.component.html',
  styleUrls: ['./encounter-generator.component.css']
})
export class EncounterGeneratorComponent implements OnInit {

  constructor(private encounterService : EncounterService) {  
    console.log('Constructing EncounterGeneratorComponent, injecting EncounterService')
  }  

  public encounter!: IEncounterModel;
  
  ngOnInit() {
    console.log('ngOnInit App.Component')
    this.getRandomEncounter();
  }

  getRandomEncounter() {
    this.encounterService.getRandomEncounter()
    .subscribe((data: IEncounterModel) =>
    {
      console.log(data)
      this.encounter = data;
    });
  }
}
