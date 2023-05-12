import { Component, Input, OnInit } from '@angular/core';

import { IMonster } from 'src/app/core/models/IMonster';

@Component({
  selector: 'app-initiative-timeline',
  templateUrl: './initiative-timeline.component.html',
  styleUrls: ['./initiative-timeline.component.css']
})
export class InitiativeTimelineComponent implements OnInit {
  @Input() public encounterName: string = "";
  @Input() public monsters: IMonster[] = [];

  public chart: any;

  ngOnInit() {
  }

  async updateMonsters(monsters: IMonster[]): Promise<void> {
    console.log("Timeline component monsters update");
    this.monsters = monsters;
    console.log(this.monsters);
  }
}