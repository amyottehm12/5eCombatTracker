import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CombatLogComponent } from '../../../../core/modules/encounter-handler/combat-log/combat-log.component';

describe('LogComponent', () => {
  let component: CombatLogComponent;
  let fixture: ComponentFixture<CombatLogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CombatLogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CombatLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
