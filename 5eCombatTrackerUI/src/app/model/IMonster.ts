import { IMonsterAttack } from "./IMonsterAttack";

export interface IMonster {
    name: string;
    hp: number;
    ac: number;
    initiative: number;
    attacks: IMonsterAttack;
}
