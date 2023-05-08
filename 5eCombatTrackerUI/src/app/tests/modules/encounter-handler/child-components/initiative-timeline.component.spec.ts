import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InitiativeTimelineComponent } from './initiative-timeline.component';

describe('InitiativeTimelineComponent', () => {
  let component: InitiativeTimelineComponent;
  let fixture: ComponentFixture<InitiativeTimelineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InitiativeTimelineComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InitiativeTimelineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
