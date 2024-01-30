import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })
export class DieRoller {
    async rollDie(dieSize: number, dieBonus: number, numberOfDice: number): Promise<number> {
        let result: number = 0;
        for (let i = 0; i < numberOfDice; i++) {
            result += Math.floor((Math.random() * dieSize) + 1);
        }
        result += dieBonus;
        return result
    }
}