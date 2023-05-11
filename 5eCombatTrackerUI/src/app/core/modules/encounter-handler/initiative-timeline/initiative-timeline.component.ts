import { Component, Input, OnInit } from '@angular/core';
import { Chart, LineController, LineElement, LinearScale, PointElement, CategoryScale } from 'chart.js';

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
	  Chart.register(LineController, LineElement, PointElement, LinearScale, CategoryScale);
  }

  async updateMonsters(monsters: IMonster[]): Promise<void> {
    console.log("timeline component monsters update");
    this.monsters = monsters;
    console.log(this.monsters);
  }

  createChart() {
    console.log("creating chart");

    let chartData: chartDataObject[] = [];
    for (let i = 0; i < this.monsters.length; i++){
      chartData.push(new chartDataObject(this.monsters[i].name, this.monsters[i].initiative));
    }

    console.log(chartData);

    this.chart = new Chart("MyChart", {
      type: 'line',
      data: {
        labels: chartData.map(monster => monster.name + " " + monster.initiative),
	      datasets: [
          {
            label: "Monster Initiative",
            data: chartData.map(monster => monster.initiative)
          } 
        ]
      },
      options: {
        aspectRatio: 3,
        scales: {
          y: {
            max: 30,
            min: 0
          }
        }
      }
      
    });

    console.log(this.chart.datasets);
  }

}

class chartDataObject {
  name: string;
  initiative: number;

  constructor(name: string, initiative: number) {
    this.name = name;
    this.initiative = initiative;
  }
}