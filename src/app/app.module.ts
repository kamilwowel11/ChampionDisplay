import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LandingComponent } from './landing/landing.component';
import { CardComponent } from './card/card.component';
import { ListItemComponent } from './list-item/list-item.component';
import { AddChampionComponent } from './add-champion/add-champion.component';
import { UploadComponentComponent } from './upload-component/upload-component.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ChampionService } from './services/champions/champions.service';
import { HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon'; 
import { MatRadioModule } from '@angular/material/radio';
import {MatButtonModule} from '@angular/material/button'; 
import {MatDividerModule} from '@angular/material/divider';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChampionSingleComponent } from './champion-single/champion-single.component';
import { ChampionAllComponent } from './champion-all/champion-all.component';





@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    CardComponent,
    ListItemComponent,
    AddChampionComponent,
    UploadComponentComponent,
    ChampionSingleComponent,
    ChampionAllComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    MatTableModule,
    MatCardModule,
    MatGridListModule,
    MatToolbarModule,
    MatSnackBarModule,
    MatPaginatorModule,
    MatSortModule,
    MatRadioModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatExpansionModule,
    MatButtonToggleModule,
    BrowserAnimationsModule,
  ],
  providers: [
    ChampionService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
