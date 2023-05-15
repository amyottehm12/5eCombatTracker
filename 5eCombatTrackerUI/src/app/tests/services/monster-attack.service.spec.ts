import { TestBed } from '@angular/core/testing';

import { MonsterAttackService } from 'src/app/core/services/api-services/monster-attack.service';

describe('MonsterAttackService', () => {
  let service: MonsterAttackService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonsterAttackService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
