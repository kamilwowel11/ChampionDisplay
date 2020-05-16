import { TestBed } from '@angular/core/testing';

import { ChampionService } from './champions.service';

describe('PeopleService', () => {
  let service: ChampionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChampionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
