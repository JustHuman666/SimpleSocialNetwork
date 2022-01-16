import { TestBed } from '@angular/core/testing';
import { IsLoggedIn } from './is-logged-in';

describe('AuthentificationGuard', () => {
  let guard: IsLoggedIn;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsLoggedIn);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});