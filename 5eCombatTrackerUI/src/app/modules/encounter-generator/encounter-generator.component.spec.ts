import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncounterGeneratorComponent } from './encounter-generator.component';

describe('EncounterGeneratorComponent', () => {
  let component: EncounterGeneratorComponent;
  let fixture: ComponentFixture<EncounterGeneratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncounterGeneratorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EncounterGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
