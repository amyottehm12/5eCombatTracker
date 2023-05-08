import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })
export class DieRoller {
    async rollDie(dieSize: number, dieBonus: number): Promise<number> {
        return Math.floor((Math.random() * dieSize) + 1 + dieBonus);
    }
}