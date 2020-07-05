import { Injectable } from '@angular/core';
import {Champion} from '../../models/champion';
import {HttpClient, HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';
import { UploadResult } from 'src/app/models/upload-result';
import { Filters } from 'src/app/models/Filters';
import { PaginatedResults } from 'src/app/models/Pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ChampionService {

  baseUrl = 'https://localhost:5001/champions';

  constructor ( private httpClient: HttpClient) { }

  getChampion(id: number): Observable<Champion> {
    return this.httpClient.get<Champion>(`${this.baseUrl}/${id}`);
  }

  // getChampions1(): Observable<Array<Champion>> {
  //   return this.httpClient.get<Array<Champion>>(`${this.baseUrl}`);
  // }
  
  getChampions(page?, itemsPerPage?, filters?: Filters, orderBy?: string): Observable<PaginatedResults<Champion[]>> {
    const paginatedResult: PaginatedResults<Champion[]> = new PaginatedResults<Champion[]>();
    let params = new HttpParams();
    if (page !=null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    if (filters){
      if (filters.firstName) {
        params = params.append('firstName', filters.firstName);
      }
      if (filters.defaultPosition)
      {
        params = params.append('defaultPosition', filters.defaultPosition);
      }
    }
    if (orderBy) {
      params = params.append('orderBy', orderBy);
    }
    console.log(params.toString());

    return this.httpClient.get<Champion[]>(this.baseUrl, {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.data = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get("Pagination"));
        }
        return paginatedResult;
      })
    )
  }

  getChampionsAllCsv(filters?: Filters, orderBy?: string): Observable<Blob> {
    let params = new HttpParams();
    if (filters) {
      if (filters.firstName) {
        params = params.append('firstName', filters.firstName);
      }
      if (filters.defaultPosition){
        params = params.append('defaultPosition', filters.defaultPosition)
      }
    }
    if (orderBy)
    {
      params = params.append('orderBy', orderBy)
    }
  
    return this.httpClient.get<Blob>('https://localhost:5001/champions'+ '/csv', {params, responseType: 'blob' as 'json'});
  }


  addChampion(champion: Champion) {
    return this.httpClient.post(`${this.baseUrl}/add`, champion);
  }

  updateChampion(champion: Champion): Observable<number> {
    return this.httpClient.put<number>(`${this.baseUrl}/update`, champion);
  }

  deleteChampion(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.baseUrl}/delete/${id}`);
  }
  uploadImage(data: FormData) : Observable<UploadResult> {
    return this.httpClient.post<UploadResult>(`${this.baseUrl}/upload-image`,data);
  }
}
