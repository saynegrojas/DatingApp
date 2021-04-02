import { TestBed } from '@angular/core/testing';

import { TestErrorsService } from './test-errors.service';

describe('TestErrorsService', () => {
  let service: TestErrorsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestErrorsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
