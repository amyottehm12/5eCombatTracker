import { TestBed } from '@angular/core/testing';

import { BiomeTypeService } from '../biome-type.service';

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
