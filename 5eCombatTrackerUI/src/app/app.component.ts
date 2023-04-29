import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = '5eCombatTrackerUI';
  
  constructor() {  
    console.log('Constructing AppComponent')
  }

}
