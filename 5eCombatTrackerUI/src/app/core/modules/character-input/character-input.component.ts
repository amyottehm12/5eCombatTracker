import { Component } from '@angular/core';
import { Character, ICharacter } from '../../models/ICharacter';

@Component({
  selector: 'app-character-input',
  templateUrl: './character-input.component.html',
  styleUrls: ['./character-input.component.css']
})
export class CharacterInputComponent {
  public characters: ICharacter[] = [new Character(1, "Test rogue", 15), new Character(2, "Test cleric", 2)];
}
