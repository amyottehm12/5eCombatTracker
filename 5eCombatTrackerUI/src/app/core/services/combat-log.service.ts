import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CombatLogService {
  private log: string[] = [];

  constructor() { }

  public async logPush(data: string): Promise<void> {
    this.log.push(data);
  }

  public async getLog(): Promise<string[]>{
    return this.log;
  }

}
