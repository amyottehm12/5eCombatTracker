import { BehaviorSubject, Observable } from "rxjs";
import { IMonster } from "../../models/IMonster";

export abstract class MonsterObservable {
    public monsters: Observable<IMonster[]> = new Observable<IMonster[]>;
    protected _monsters: BehaviorSubject<IMonster[]> = new BehaviorSubject<IMonster[]>([]);
    protected _internalMonsters: IMonster[] = [];

    constructor() {
          this.monsters = this._monsters.asObservable();
    }

    public getMonsters(): Observable<IMonster[]> {
        return this.monsters;
    }   

    protected setMonsters(): void {
        this._monsters.next(this._internalMonsters);
    }

}