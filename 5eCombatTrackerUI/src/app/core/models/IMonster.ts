import { IMonsterAttack } from "./IMonsterAttack";

export interface IMonster {
    id: number;
    name: string;
    hp: number;
    ac: number;
    initiative: number;
    attacks: IMonsterAttack;
}
