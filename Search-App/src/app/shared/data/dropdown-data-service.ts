import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DropDown } from '../proxy/services/drop-down/dtos/dropdown';

@Injectable({
  providedIn: 'root'
})
export class DropDownDataService {

  private selectDropDownTextSource = new BehaviorSubject<DropDown | null>(null);
  selectDropDownTextValue$: Observable<DropDown | null> = this.selectDropDownTextSource.asObservable();
  constructor() { }

  updateDropDownValue(newValue: DropDown | null): void {
    this.selectDropDownTextSource.next(newValue);
  }

  getDropDownName(): string | undefined {
    return this.selectDropDownTextSource.getValue()?.name;
  }

  getDropDownNumber(): number | undefined {
    return this.selectDropDownTextSource.getValue()?.id;
  }
}