export interface ICharacter {
    name: string;
    initiative: number; 
}

export class Character implements ICharacter {
    name: string;
    initiative: number;

    constructor(name: string, initiative: number) {
        this.name = name;
        this.initiative = initiative;
    }
}