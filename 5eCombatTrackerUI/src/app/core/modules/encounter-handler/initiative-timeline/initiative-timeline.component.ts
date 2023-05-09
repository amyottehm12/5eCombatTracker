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
	console.log("test");
	Chart.register(LineController, LineElement, PointElement, LinearScale, CategoryScale);
    this.createChart();
  }

  createChart(){
    this.chart = new Chart("MyChart", {
      type: 'line',

      data: {
        labels: ['30', '25', '20','15',
								 '10', '5', '1' ], 
	       datasets: [
          {
            label: "Monsters",
            data: [],
            backgroundColor: 'blue'
          } 
        ]
      },
      options: {
        aspectRatio:5
      }
      
    });
  }
}
