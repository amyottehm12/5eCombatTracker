import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncounterHandlerComponent } from '../../../core/modules/encounter-handler/encounter-handler.component';

describe('EncounterGeneratorComponent', () => {
  let component: EncounterHandlerComponent;
  let fixture: ComponentFixture<EncounterHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncounterHandlerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EncounterHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
