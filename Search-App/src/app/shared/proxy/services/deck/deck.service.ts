import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Deck } from './dtos/deck';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../environment';

@Injectable({
  providedIn: 'root'
})
export class DeckService {

  
  private apiUrl = environment.apiUrl;

  constructor(private httpClient : HttpClient) { }

  getDeck() : Observable<Deck[]> {
    return this.httpClient.get<Deck[]>(`${this.apiUrl}/api/Deck/GetDecks`);;
  }
}
