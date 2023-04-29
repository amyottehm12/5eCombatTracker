import { Component, OnInit } from '@angular/core';
import { IEncounter } from 'src/app/model/IEncounter';
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

  public encounter!: IEncounter;
  
  ngOnInit() {
    console.log('ngOnInit App.Component')
    this.getRandomEncounter();
  }

  getRandomEncounter() {
    this.encounterService.getRandomEncounter('Dungeon')
    .subscribe((data: IEncounter) =>
    {
      console.log(data)
      this.encounter = data;
    });
  }
}
