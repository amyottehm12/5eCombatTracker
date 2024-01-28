import { IMonster } from "./IMonster";

export interface IEncounter {
    name: string;
    monsters: IMonsterEncounter[];
}

export interface IMonsterEncounter {
    quantity: number;
    monster: IMonster;
}