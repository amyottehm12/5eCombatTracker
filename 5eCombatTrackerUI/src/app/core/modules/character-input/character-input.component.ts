import { Component } from '@angular/core';
import { Character, ICharacter } from '../../models/ICharacter';
import { EncounterHandlerService } from '../../services/encounter-handler.service';

@Component({
  selector: 'app-character-input',
  templateUrl: './character-input.component.html',
  styleUrls: ['./character-input.component.css']
})
export class CharacterInputComponent {
  public characters: ICharacter[] = [];

  constructor(private encounterHandler: EncounterHandlerService) {
    this.getCharacters();
  }

  getCharacters(): void {
    this.encounterHandler.getCharacters()
    .subscribe((data: ICharacter[]) =>
    {
      this.characters = data
    })
  }

  saveInput(name: string, initiative: string) {
    if (name == "") {
      alert("Need name!");
      return;
    }

    if (initiative === "") {
      initiative = "0";
    }
    
    this.encounterHandler.addCharacter(name, parseInt(initiative));
  }

  deleteCharacter(id: number) {
    this.encounterHandler.removeCharacter(id);
  }

  updateInitiative(initiative: number, id: number) {
    this.encounterHandler.updateCharacterInitiative(initiative, id);
  }

  updateName(name: string, id: number) {
    this.encounterHandler.updateCharacterName(name, id);
  }
}