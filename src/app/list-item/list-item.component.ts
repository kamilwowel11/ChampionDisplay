import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Champion} from '../models/champion';
import { Router } from '@angular/router';
import { ChampionService } from '../services/champions/champions.service';
import { first } from 'rxjs/operators';
import { Variable } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent implements OnInit {
  @Input() champion: Champion;
  @Output() titleBarText = new EventEmitter<string>();
  @Output() titleBarText1 = new EventEmitter<string>();
  adressTemp: string;
  adressTemp1: string;
  private expanded = false;

  constructor(private championService: ChampionService, private router: Router) { }
  

  ngOnInit(): void {
    this.champion.adress ="";
    this.adressTemp = this.champion.avatarUrl;
    this.adressTemp1 = "https://localhost:5001/";
    this.champion.adress = this.adressTemp1.concat(this.adressTemp);
    //console.log(this.champion.avatarUrl);
  }
  
  onDelete() {
    this.championService
    .deleteChampion(this.champion.id)
    .pipe(first())
    .subscribe(success=>{
      if(success) {
        console.log("Poprawnie usunięto Championa");
      }
      else {
        console.log("Nie udało się usunąć Championa");
      }
    });
  }

  setTitleBarText(text: string) {
    if (this.expanded) {
      this.titleBarText.emit(" ");
      this.expanded = false;
    } else {
      this.titleBarText.emit(text);
      this.expanded = true;
    }
  }
}
