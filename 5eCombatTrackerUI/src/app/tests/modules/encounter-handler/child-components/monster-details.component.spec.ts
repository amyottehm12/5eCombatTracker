import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MonsterDetailsComponent } from 'src/app/core/modules/encounter-handler/initiative-timeline/monster-details/monster-details.component';


describe('MonsterDetailsComponent', () => {
  let component: MonsterDetailsComponent;
  let fixture: ComponentFixture<MonsterDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonsterDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonsterDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
