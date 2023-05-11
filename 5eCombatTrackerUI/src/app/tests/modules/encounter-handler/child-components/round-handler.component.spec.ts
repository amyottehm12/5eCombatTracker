import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundHandlerComponent } from '../../../../core/modules/encounter-handler/round-handler/round-handler.component';

describe('MonsterAttacksComponent', () => {
  let component: RoundHandlerComponent;
  let fixture: ComponentFixture<RoundHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoundHandlerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoundHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
