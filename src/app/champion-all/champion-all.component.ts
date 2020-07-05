import { Component, OnInit, ViewChild } from '@angular/core';
import { Champion } from '../models/champion';
import { ChampionService } from '../services/champions/champions.service';
import { PaginatedResults, Pagination } from '../models/Pagination';
import { Filters } from '../models/Filters';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-champion-all',
  templateUrl: './champion-all.component.html',
  styleUrls: ['./champion-all.component.css'],
})
export class ChampionAllComponent implements OnInit {
  grid = false;
  champions: Champion[];
  topBarTitle = '';
  response: PaginatedResults<Champion[]>;
  paginationSettings: Pagination;


  pageEvent = new PageEvent();
  pageSizeOptions: number[] = [3, 5, 7, 10, 50];

  filters: Filters;
  orderBy: string;

  @ViewChild("paginator") matPaginator: MatPaginator

  constructor(private championService: ChampionService,private router: Router,public auth: AuthService) {
    this.paginationSettings = {currentPage: 1, itemsPerPage: 5, totalItems: 10, totalPages:1}
    console.log(this.paginationSettings);
  }

  ngOnInit(): void {
   this.championService.getChampions().subscribe(res => {
    this.champions=res.data;
   });
   this.filters = { firstName: "", defaultPosition: ""};
  }
  // ngAfterViewInit(){
    
  // }

  toggleGrid() {
    this.grid = !this.grid;
    this.topBarTitle = '';
  }

  setTopBarTitle(text: string) {
    this.topBarTitle = text;
  }

  getChampions(event?: PageEvent, filters?: Filters, orderBy?: string) {
    if(event) {
      console.log(event.pageIndex);
      console.log(event.pageSize);
      this.championService.getChampions(event.pageIndex + 1, event.pageSize, filters, orderBy).subscribe(data => {
        this.response = data;
        this.champions= this.response.data;
        console.log(this.champions);
        console.log(this.response);
        this.paginationSettings = this.response.pagination;
      }, error => {
        console.log("Error while fetching users!");
        console.log(error);
      })
      return event;
    } else {
      this.championService.getChampions().subscribe(data => {
        this.response = data;
        this.champions= this.response.data;
        this.paginationSettings = this.response.pagination;
      }, error => {
        console.log("Error while fetching users!");
        console.log(error);
        
      })
      return event;
    }
  }
  peopleListChanged(): void {
    this.ngOnInit();
  }

  filterResults() {
    this.getChampions(this.pageEvent, this.filters, this.orderBy);
  }

  resetFilters() {
    this.filters = { firstName: "", defaultPosition: ""};
    this.getChampions(this.pageEvent, null, this.orderBy);
  }

  orderByChanged() {
    this.getChampions(this.pageEvent, this.filters, this.orderBy);
  }

  getCsvFile() {
    this.championService.getChampionsAllCsv(this.filters, this.orderBy).subscribe(data => {
      const blob = new Blob([data], {type: 'text/csv'});
      var downloadURL = window.URL.createObjectURL(data);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = 'champions.csv';
      link.click();
    })
  }

  isAdmin(): boolean {
    return !!this.auth.isAdmin();
  }
  loggedIn() {
    return !!this.auth.loggedIn();
  }
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/']);
  }

}
