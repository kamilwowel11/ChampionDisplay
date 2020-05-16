import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Champion} from '../models/champion';
import {ChampionService} from '../services/champions/champions.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent implements OnInit {
  @Input() public champion: Champion;
  @Output() titleBarText = new EventEmitter<string>();
  private expanded = false;
  adressTemp: string;
  adressTemp1: string;
  championService: ChampionService;

  constructor(peopleService: ChampionService) {}

  ngOnInit(): void {
    this.champion.adress ="";
    this.adressTemp = this.champion.avatarUrl;
    this.adressTemp1 = "https://localhost:5001/";
    this.champion.adress = this.adressTemp1.concat(this.adressTemp);
    console.log(this.champion);
  }

  setTitleBarText(text: string) {
    if (this.expanded) {
      this.titleBarText.emit('');
      this.expanded = false;
    } else {
      this.titleBarText.emit(text);
      this.expanded = true;
    }
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
}
