import { IMonsterAttack, IMonsterAttackResult } from "./IMonsterAttack";

export interface IMonster {
    id: number;
    name: string;
    hp: number;
    currentHp: number;
    ac: number;
    initiative: number;
    attacks: IMonsterAttack;
    attackResult: IMonsterAttackResult[];
    imageURL: string;
    generatedMonsterIdentifier: number;
    player: boolean;
}