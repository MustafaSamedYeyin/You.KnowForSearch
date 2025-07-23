import { environment } from './../../../../../../environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DeckItem } from './dtos/deck-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeckItemsService {
  apiUrl = environment.apiUrl;
  constructor(private httpClient : HttpClient) 
  {
  }
  public getDeckItems(deckId : number): Observable<DeckItem[]> {
    return this.httpClient.get<DeckItem[]>(`${this.apiUrl}/api/DeckItem/GetDeckItems?id=${deckId}`);
  }
}
