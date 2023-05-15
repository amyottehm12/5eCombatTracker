import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MonsterDetailsModalComponent } from 'src/app/core/modules/encounter-handler/initiative-timeline/monster-details/monster-details-modal/monster-details-modal.component';



describe('MonsterDetailsModalComponent', () => {
  let component: MonsterDetailsModalComponent;
  let fixture: ComponentFixture<MonsterDetailsModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonsterDetailsModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonsterDetailsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
