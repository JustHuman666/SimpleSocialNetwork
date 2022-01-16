import { TestBed } from '@angular/core/testing';
import { IsNotLoggedIn } from './is-not-logged-in';

describe('AuthentificationGuard', () => {
  let guard: IsNotLoggedIn;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsNotLoggedIn);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});