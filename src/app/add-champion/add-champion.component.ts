import { Component, OnInit } from '@angular/core';
import { ChampionService } from '../services/champions/champions.service';
import { Champion } from '../models/champion';
import { FormControlName, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-add-champion',
  templateUrl: './add-champion.component.html',
  styleUrls: ['./add-champion.component.css']
})
export class AddChampionComponent implements OnInit {
  

  constructor(private championService:ChampionService, private route: ActivatedRoute, private router: Router) {

    this.route.data.pipe(first()).subscribe(result => {
      this.isEdit = result.isEdit;
    })

    this.route.paramMap.pipe(first()).subscribe(res =>{
      this.championId = Number(res.get('id'));
    })
   }

  isEdit: boolean
  champion: Champion;
  championId: number;
  form: FormGroup;

  initform(){
    let controls: any = {
      "firstName":new FormControl(this.champion.firstName),
      "description":new FormControl(this.champion.bio),
      "avatarUrl":new FormControl(this.champion.avatarUrl),
      "position":new FormControl(this.champion.defaultPosition),
    };

    this.form = new FormGroup(controls);
  }
  
  ngOnInit(): void {
    if (this.isEdit){
      this.championService.getChampion(this.championId).pipe(first()).subscribe(res => {
        this.champion = res;
        this.initform();
      });
    }
    else{
      this.champion = new Champion();
      this.initform();

    }

    this.initform();

  }

  submitChanges() {
    this.champion.firstName = this.form.controls["firstName"].value;
    this.champion.bio = this.form.controls["description"].value;
    this.champion.avatarUrl = this.form.controls["avatarUrl"].value;
    this.champion.pictureUrl = this.form.controls["avatarUrl"].value;
    this.champion.defaultPosition = this.form.controls["position"].value;

    if(this.isEdit) {
      this.championService
      .updateChampion(this.champion)
      .subscribe(id => {
        this.router.navigateByUrl(`champion-details/${id}`);
      });
    }
    else {
      this.championService
      .addChampion(this.champion)
      .subscribe(id => {
        this.router.navigateByUrl(`champion-details/${id}`);
      });
    }
  }
  uploadFinished(filePath: string) {
    this.champion.avatarUrl = filePath;
    this.champion.pictureUrl = filePath;
  }
}
