import { TestBed } from '@angular/core/testing';

import { BiomeTypeService } from './biometype.service';

describe('BiomeserviceService', () => {
  let service: BiomeTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BiomeTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
