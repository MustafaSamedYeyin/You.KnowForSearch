import { Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { QuestionsService } from '../shared/proxy/services/questions/questions.service';
import { Question } from '../shared/proxy/services/questions/dtos/question-dto';
import { FormsModule } from '@angular/forms';
import { QuestionPipe } from '../shared/pipes/question.pipe';
import { StringHelper } from '../shared/utils/string-helper';
import { DropDownDataService } from '../shared/data/dropdown-data-service';
import { Observable, Subscription, switchMap, tap } from 'rxjs';
import { DropDown } from '../shared/proxy/services/drop-down/dtos/dropdown';
import { DeckComponent } from './deck/deck.component';
import { DeckItemsComponent } from './deck-items/deck-items.component';
import { Deck } from '../shared/proxy/services/deck/dtos/deck';
import { CommonModule } from '@angular/common';
import { SafePipe } from "../shared/pipes/safe.pipe";
import { ResourceComponent } from "../resource/resource.component";

@Component({
  selector: 'app-questions',
  standalone: true,
  templateUrl: './questions.component.html',
  styleUrl: './questions.component.css',
  imports: [FormsModule, QuestionPipe, DeckComponent, DeckItemsComponent, CommonModule, SafePipe, ResourceComponent]
})
export class QuestionsComponent implements OnInit, OnDestroy {
  questions!: Question[];
  topic: string = '';
  problemValue: string = '';
  diffTopic: string = '';
  stringHelper: StringHelper;
  dropdownSubscription: Subscription | undefined;
  resourcePanelOpen = false;

  constructor(private questionService: QuestionsService, private dropDownDataService: DropDownDataService) {
    this.stringHelper = new StringHelper(dropDownDataService)
  }
  ngOnDestroy(): void {
    if (this.dropdownSubscription) {
      this.dropdownSubscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.subscribeToDropdownChanges();
  }

  subscribeToDropdownChanges(): void {
    this.dropdownSubscription = this.dropDownDataService.selectDropDownTextValue$.subscribe((dropDown: DropDown | null) => {
      var result = this.GetQuestionsFromService().subscribe((value: Question[]) => this.questions = value);
    });
  }


  public GetQuestionsFromService(): Observable<Question[]> {
    return this.questionService.getQuestionsData();
  }

  public Search(event: any): void {
    var dectText = this.deck ? this.deck.text : '';
    var questionLink = "https://www.google.com/search?q=" + this.stringHelper.ReplaceQuestionFormats(event, this.topic, this.problemValue, this.diffTopic,dectText );
    window.open(questionLink, '_blank');
  }
  public deck!: Deck;
  @ViewChild(DeckItemsComponent) deckItemsComponent!: DeckItemsComponent;

  public selectDeck(deck: Deck): void {
    this.deck = deck;
    console.log("Selected deck:", deck);
    this.deckItemsComponent.getDeckItems(deck.id);
  }

  public setTopic(topic: string): void {
    this.topic = topic;
  }

  // Add to your component class
sidebarOpen: boolean = false;
touchStartX: number = 0;
touchEndX: number = 0;
swipeThreshold: number = 70; // Minimum distance to detect a swipe
  
  toggleSidebar(): void {
    this.sidebarOpen = !this.sidebarOpen;
  }

  touchStart(event: TouchEvent): void {
    this.touchStartX = event.touches[0].clientX;
  }

  touchMove(event: TouchEvent): void {
  }

  touchEnd(event: TouchEvent): void {
    this.touchEndX = event.changedTouches[0].clientX;
    this.handleSwipe();
  }

  handleSwipe(): void {
    if (this.touchEndX - this.touchStartX > this.swipeThreshold && !this.sidebarOpen) {
      this.sidebarOpen = true;
    }

    if (this.touchStartX - this.touchEndX > this.swipeThreshold && this.sidebarOpen) {
      this.sidebarOpen = false;
    }
  }
public openInChatGpt(topic: string): void {
    window.open(`https://chat.openai.com/?prompt=Explain ${topic} you have max 150 characters`, '_blank');
  }

  public openInGemini(topic: string): void {
    window.open(`https://gemini.google.com/app?text=Explain ${topic} concisely`, '_blank');
  }

  public openInDeepSeek(topic: string): void {
    window.open(`https://chat.deepseek.com/?q=Explain ${topic} you have max 150 characters`, '_blank');
  }

  public openInClaude(topic: string): void {
    window.open(`https://claude.ai/chat?prompt=Explain ${topic} briefly`, '_blank');
  }

  public openInPerplexity(topic: string): void {
    window.open(`https://www.perplexity.ai/?q=Explain ${topic} concisely`, '_blank');
  }

  public openInBard(topic: string): void {
    window.open(`https://bard.google.com/chat?prompt=Explain ${topic} in simple terms`, '_blank');
  }

  public openInBing(topic: string): void {
    window.open(`https://www.bing.com/search?q=${topic}&showconv=1`, '_blank');
  }
  
}
