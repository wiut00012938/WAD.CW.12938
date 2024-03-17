import { TestBed } from '@angular/core/testing';

import { ServiceGradetrackerService } from './service-gradetracker.service';

describe('ServiceGradetrackerService', () => {
  let service: ServiceGradetrackerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceGradetrackerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
