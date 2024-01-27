export interface ICharacter {
    generatedId: number;
    name: string;
    initiative: number; 
}

export class Character implements ICharacter {
    generatedId: number;
    name: string;
    initiative: number;

    constructor(id: number, name: string, initiative: number) {
        this.generatedId = id;
        this.name = name;
        this.initiative = initiative;
    }
}