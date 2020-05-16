import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChampionSingleComponent } from './champion-single.component';

describe('ChampionSingleComponent', () => {
  let component: ChampionSingleComponent;
  let fixture: ComponentFixture<ChampionSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChampionSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChampionSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
