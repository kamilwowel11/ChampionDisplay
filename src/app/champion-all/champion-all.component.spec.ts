import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChampionAllComponent } from './champion-all.component';

describe('ChampionAllComponent', () => {
  let component: ChampionAllComponent;
  let fixture: ComponentFixture<ChampionAllComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChampionAllComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChampionAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
