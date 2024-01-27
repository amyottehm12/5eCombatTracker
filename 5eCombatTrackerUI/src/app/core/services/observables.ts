import { BehaviorSubject, Observable } from "rxjs";
import { IMonster } from "../models/IMonster";
import { ICharacter } from "../models/ICharacter";

export abstract class Observables {

    constructor() {
          this.monsters = this._monsters.asObservable();
          this.log = this._log.asObservable();
          this.characterList = this._characterList.asObservable();
    }   

    //Monsters List
    public monsters: Observable<IMonster[]> = new Observable<IMonster[]>;
    protected _monsters: BehaviorSubject<IMonster[]> = new BehaviorSubject<IMonster[]>([]);
    protected _internalMonsters: IMonster[] = [];       
    public getMonsters(): Observable<IMonster[]> {
        return this.monsters;
    }       
    protected setMonsters(): void {
        this._monsters.next(this._internalMonsters);
    }

    //Combat Log
    public log: Observable<string[]> = new Observable<string[]>;
    protected _log: BehaviorSubject<string[]> = new BehaviorSubject<string[]>([]);
    protected _logEntry: string = "";  
    public getLog(): Observable<string[]>{
      return this.log;
    }   
    protected logPush(): void {
      var currentLog: string[] = this._log.getValue();
      currentLog.unshift(this._logEntry)
      this._log.next(currentLog)
    }   

    //Character List
    public characterList: Observable<ICharacter[]> = new Observable<ICharacter[]>;
    protected _characterList: BehaviorSubject<ICharacter[]> = new BehaviorSubject<ICharacter[]>([]);
    protected _internalCharacterList: ICharacter[] = [];

    public getCharacters(): Observable<ICharacter[]> {
      return this.characterList;
    }

    protected setCharacters(): void {
      this._characterList.next(this._internalCharacterList);
    }

}