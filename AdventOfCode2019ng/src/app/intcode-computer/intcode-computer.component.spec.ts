import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntcodeComputerComponent } from './intcode-computer.component';

describe('IntcodeComputerComponent', () => {
  let component: IntcodeComputerComponent;
  let fixture: ComponentFixture<IntcodeComputerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntcodeComputerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntcodeComputerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
