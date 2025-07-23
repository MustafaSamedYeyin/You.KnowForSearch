import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DeckItemsService } from '../../shared/proxy/services/deck-items/deck-items.service';
import { DeckItem } from '../../shared/proxy/services/deck-items/dtos/deck-item';
import { CommonModule } from '@angular/common';
import { Deck } from '../../shared/proxy/services/deck/dtos/deck';


@Component({
  selector: 'app-deck-items',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './deck-items.component.html',
  styleUrl: './deck-items.component.css',
})
export class DeckItemsComponent {

  @Input() public selectedDeck!: Deck;
  public deckItems: DeckItem[] = [];

  constructor(private deckItemsService: DeckItemsService) { }

  public getDeckItems(number: number): void {
    this.deckItemsService.getDeckItems(number).subscribe((value: DeckItem[]) => {
      this.deckItems = value;
    });
  }

  @Output() topic = new EventEmitter<string>();
  public setTopic(topic: string): void {
    this.topic.emit(topic);
  }
}