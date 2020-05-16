import { Component, OnInit } from '@angular/core';
import { Champion } from '../models/champion';
import { ChampionService } from '../services/champions/champions.service';

@Component({
  selector: 'app-champion-all',
  templateUrl: './champion-all.component.html',
  styleUrls: ['./champion-all.component.css']
})
export class ChampionAllComponent implements OnInit {
  grid = false;
  champions: Champion[];
  topBarTitle = '';

  constructor(private service: ChampionService) {}

  ngOnInit(): void {
   this.service.getChampions().subscribe(res => {
    this.champions=res;
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
