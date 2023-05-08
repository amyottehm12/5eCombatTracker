export interface IMonsterAttack {
    weaponName: string;
    damageDie: number;
    hitRoll: number;
    damageBonus: number;
    extraEffect: string;
    toHitResult: number;
    damageResult: number
}