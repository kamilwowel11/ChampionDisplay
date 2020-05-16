import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Champion } from '../models/champion';
import { Subscription, Observable } from 'rxjs';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { ChampionService } from '../services/champions/champions.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-champion-single',
  templateUrl: './champion-single.component.html',
  styleUrls: ['./champion-single.component.css'],
})
export class ChampionSingleComponent implements OnInit, OnDestroy {

  champion: Champion;
  champions: Champion[];
  isEdit: boolean;
  dataSubscription: Subscription;
  championId: number;
  adressTemp: string;
  adressTemp1: string;

  constructor(private championService:ChampionService, private route: ActivatedRoute) {

    this.route.paramMap.pipe(first()).subscribe(res =>{
      this.championId = Number(res.get('id'));
    })
   }

  ngOnInit(): void {
    this.championService.getChampion(this.championId).pipe(first()).subscribe(res => {
      this.champion = res;
      
    });
  }
  
  ngOnDestroy(): void {
   // this.dataSubscription.unsubscribe();
  }
}
