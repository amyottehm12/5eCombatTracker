import { TestBed } from '@angular/core/testing';

import { EncounterService } from 'src/app/core/services/api-services/encounter.service';

describe('EncounterService', () => {
  let service: EncounterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EncounterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
