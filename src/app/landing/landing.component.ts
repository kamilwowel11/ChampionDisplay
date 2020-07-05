import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {Champion} from '../models/champion';
import {ChampionService} from '../services/champions/champions.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  grid = false;
  champions: Champion[];
  topBarTitle = '';

  constructor(private service: ChampionService) {}

  ngOnInit(): void {
   this.service.getChampions().subscribe(res => {
    this.champions=res.data;
   });
  }

  toggleGrid() {
    this.grid = !this.grid;
    this.topBarTitle = '';
  }

  setTopBarTitle(text: string) {
    this.topBarTitle = text;
  }
}
