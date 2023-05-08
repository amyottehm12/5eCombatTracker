import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonsterAttacksComponent } from './monster-attacks.component';

describe('MonsterAttacksComponent', () => {
  let component: MonsterAttacksComponent;
  let fixture: ComponentFixture<MonsterAttacksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonsterAttacksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonsterAttacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
