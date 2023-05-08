import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoundHandler } from './round-handler.component';

describe('MonsterAttacksComponent', () => {
  let component: RoundHandler;
  let fixture: ComponentFixture<RoundHandler>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoundHandler ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoundHandler);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
