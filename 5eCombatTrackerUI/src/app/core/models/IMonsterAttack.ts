export interface IMonsterAttack {
    weaponName: string;
    damageDie: number;
    hitRoll: number;
    damageBonus: number;
    extraEffect: string;
    numberOfDice: number;
    numberOfAttacks: number;
}

export interface IMonsterAttackResult {
    toHitResult: number;
    damageResult: number;
    crit: boolean;
}