import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { Deck } from '../../shared/proxy/services/deck/dtos/deck';
import { DeckService } from '../../shared/proxy/services/deck/deck.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-deck',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './deck.component.html',
  styleUrl: './deck.component.css'
})
export class DeckComponent {

  public decks: Deck[] = new Array<Deck>();

  @Output() deck = new EventEmitter<Deck>();

  public selectedDeck!: Deck;
  constructor(private deckService: DeckService) {
    this.getDeck();
  }

  public getDeck(): void {
    this.deckService.getDeck().subscribe((value: Deck[]) => {
      this.decks = value;
    });
  }

  public selectDeck(deck: Deck): void {
    this.deck.emit(deck);
  }
}