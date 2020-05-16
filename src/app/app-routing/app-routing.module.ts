import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AddChampionComponent } from '../add-champion/add-champion.component';
import { LandingComponent } from '../landing/landing.component';
import { ChampionSingleComponent } from '../champion-single/champion-single.component';
import { ChampionAllComponent } from '../champion-all/champion-all.component';




const routes: Routes = [
  {
    path: '',
    component: LandingComponent,
    data: {
      isEdit: false
    }
  }, 
  {
      path: 'add-champion',
      component: AddChampionComponent,
      data: {
        isEdit: false
      }
  },  
  {
      path: 'edit-champion/:id',
      component: AddChampionComponent,
      data: {
        isEdit: true
      }
  }, 
  {
    path: 'champion-details/:id',
    component: ChampionSingleComponent, // nowy component do wyświetlania danych jednego championa
},
{
  path: 'champions',
  component: ChampionAllComponent, // nowy component do wyświetlania danych wyszstkich championów
}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
