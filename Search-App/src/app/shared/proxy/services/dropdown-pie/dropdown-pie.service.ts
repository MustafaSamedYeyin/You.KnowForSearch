import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../../environment';

@Injectable({
  providedIn: 'root'
})
export class DropdownPieService {
  private elasticUrl = environment.elasticUrl;

  constructor(private http: HttpClient) { }

  getDropdownPieData(): Observable<any> {
    return this.http.get<any>(`${this.elasticUrl}/api/Elasticsearch/`);
  }
}
