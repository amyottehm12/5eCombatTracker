import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterInputComponent } from './character-input.component';

describe('CharacterInputComponent', () => {
  let component: CharacterInputComponent;
  let fixture: ComponentFixture<CharacterInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharacterInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
