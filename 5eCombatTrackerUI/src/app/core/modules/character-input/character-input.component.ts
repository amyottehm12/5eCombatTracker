import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICharacter } from '../../models/ICharacter';
import { EncounterHandlerService } from '../../services/encounter-handler.service';

@Component({
  selector: 'app-character-input',
  templateUrl: './character-input.component.html',
  styleUrls: ['./character-input.component.css']
})
export class CharacterInputComponent {
  @Input() initiative!: number;
  @Output() initiativeChanged = new EventEmitter<number>();
  @Input() name!: string;
  @Output() nameChanged = new EventEmitter<string>();
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

  nameUpdated(name: string) {
    this.name = name;
    this.nameChanged.emit(this.name);
  }

  initiativeUpdated(initiative: string) {
    if (initiative === "") initiative = "0";
    this.initiative = parseInt(initiative);
    this.initiativeChanged.emit(this.initiative)
  }

  saveInput() {
    if (this.name == "" || this.name === undefined) {
      alert("Need name!");
      return;
    }

    if (this.initiative === undefined) this.initiative = 0;

    this.encounterHandler.addCharacter(this.name, this.initiative);
    this.initiative = 0;
    this.name = "";
  }

  deleteCharacter(id: number) {
    this.encounterHandler.removeCharacter(id);
  }

  updateInitiative(initiative: string, id: number) {
    this.encounterHandler.updateCharacterInitiative(parseInt(initiative), id);
  }

  updateName(name: string, id: number) {
    this.encounterHandler.updateCharacterName(name, id);
  }
}