import { Component, EventEmitter, Output } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { BiomeTypeService } from 'src/app/core/services/api-services/biome-type.service';
import { EncounterService } from 'src/app/core/services/api-services/encounter.service';
import { EncounterHandlerService } from 'src/app/core/services/encounter-handler.service';

@Component({
  selector: 'app-encounter-setup',
  templateUrl: './encounter-setup.component.html',
  styleUrls: ['./encounter-setup.component.css']
})
export class EncounterSetupComponent {
  constructor(private biomeTypeService: BiomeTypeService,
              private encounterService: EncounterService,
              private encounterHandlerService: EncounterHandlerService) { }

  @Output("reset") reset: EventEmitter<any> = new EventEmitter;
  @Output("displayEncounterChanged") displayEncounterChanged: EventEmitter<boolean> = new EventEmitter; 
  @Output("encounterNameSet") encounterNameSet: EventEmitter<string> = new EventEmitter; 

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
    await this.encounterReset();

    let encounter = await firstValueFrom(this.encounterService.getRandomEncounter(this.biomeType));
    await this.encounterHandlerService.setupMonsterData(encounter.monsters);

    this.displayEncounterChanged.emit(true);
    this.encounterNameSet.emit(encounter.name);
  }

  async encounterReset(): Promise<void> {
    this.displayEncounterChanged.emit(false);
    this.reset.emit();
  }  
}
