import { Injectable } from '@angular/core';
import { environment } from '../../../../../../environment';
import { HttpClient } from '@angular/common/http';
import { Question } from './dtos/question-dto';
import { Observable, shareReplay } from 'rxjs';
import { DropDownDataService } from '../../../data/dropdown-data-service';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {
  private apiUrl = environment.apiUrl;
  private questionsDropDownAndValueCache$ = new Map<number, Observable<Question[]>>();

  constructor(private http: HttpClient,private sharedDataService: DropDownDataService) { }

  getQuestionsData(): Observable<Question[]> {
    const dropDownValue : number = this.sharedDataService.getDropDownNumber() || 0;

     if (this.questionsDropDownAndValueCache$.has(dropDownValue)) {
       return this.questionsDropDownAndValueCache$.get(dropDownValue)!; // Return cached observable
     }
    const questionGetByNameRequest$ = this.http.get<Question[]>(this.apiUrl + "/api/Questions/GetByQuestionTab?Id=" +dropDownValue);

    this.questionsDropDownAndValueCache$.set(dropDownValue, questionGetByNameRequest$);

    return questionGetByNameRequest$;
  }
}
