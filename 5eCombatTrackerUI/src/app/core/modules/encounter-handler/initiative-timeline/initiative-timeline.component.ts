import { Component, Input, OnInit } from '@angular/core';
import { Chart, LineController, LineElement, LinearScale, PointElement } from 'chart.js';
import { CategoryScale } from 'chart.js/dist';

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
      type: 'line', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['2022-05-10', '2022-05-11', '2022-05-12','2022-05-13',
								 '2022-05-14', '2022-05-15', '2022-05-16','2022-05-17', ], 
	       datasets: [
          {
            label: "Sales",
            data: ['467','576', '572', '79', '92',
								 '574', '573', '576'],
            backgroundColor: 'blue'
          },
          {
            label: "Profit",
            data: ['542', '542', '536', '327', '17',
									 '0.00', '538', '541'],
            backgroundColor: 'limegreen'
          }  
        ]
      },
      options: {
        aspectRatio:2.5
      }
      
    });
  }
}
