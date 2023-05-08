import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncounterSetupComponent } from '../../../../core/modules/encounter-handler/encounter-setup/encounter-setup.component';

describe('EncounterSetupComponent', () => {
  let component: EncounterSetupComponent;
  let fixture: ComponentFixture<EncounterSetupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncounterSetupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EncounterSetupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
