import { Injectable } from '@angular/core';
import {Champion} from '../../models/champion';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { UploadResult } from 'src/app/models/upload-result';

@Injectable({
  providedIn: 'root'
})
export class ChampionService {

  baseUrl = 'https://localhost:5001/champions';

  constructor ( private httpClient: HttpClient) { }

  getChampion(id: number): Observable<Champion> {
    return this.httpClient.get<Champion>(`${this.baseUrl}/${id}`);
  }

  getChampions(): Observable<Array<Champion>> {
    return this.httpClient.get<Array<Champion>>(`${this.baseUrl}`);
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
