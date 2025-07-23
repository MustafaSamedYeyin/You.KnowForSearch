import { HttpClient  } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DropDown } from './dtos/dropdown';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../environment';

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {

  }

  getDropdownData(): Observable<DropDown[]> {
    return this.http.get<DropDown[]>(this.apiUrl+"/api/Tab/GetAll");
  }
}
