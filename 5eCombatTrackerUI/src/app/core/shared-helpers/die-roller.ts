import { Injectable } from "@angular/core";
import { IRollResult } from "../models/IRollResult";

@Injectable({
    providedIn: 'root'
  })
export class DieRoller {
    async rollDie(dieSize: number, dieBonus: number, numberOfDice: number, crit: boolean): Promise<number> {
        let result: number = 0;
        if (crit) numberOfDice = numberOfDice * 2;
        for (let i = 0; i < numberOfDice; i++) {
            result += Math.floor((Math.random() * dieSize) + 1);
        }
        result += dieBonus;
        return result
    }

    async rollDieCritable(dieSize: number, dieBonus: number, numberOfDice: number): Promise<IRollResult> {
        let response: IRollResult = {
            crit: false,
            result: 0
        };
        
        for (let i = 0; i < numberOfDice; i++) {
            response.result += Math.floor((Math.random() * dieSize) + 1);
        }

        if (response.result == 20) {
            response.crit = true;
        }

        response.result += dieBonus;

        return response
    }
}
