import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-initiative-timeline',
  templateUrl: './initiative-timeline.component.html',
  styleUrls: ['./initiative-timeline.component.css']
})
export class InitiativeTimelineComponent {
  @Input() public encounterName: string = "";
}
