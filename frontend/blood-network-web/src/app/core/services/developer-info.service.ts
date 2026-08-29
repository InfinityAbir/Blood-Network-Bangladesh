import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { DeveloperInfo } from '../models/developer-info';

@Injectable({ providedIn: 'root' })
export class DeveloperInfoService {
  private readonly apiUrl = `${environment.apiUrl}/developer-info`;

  constructor(private http: HttpClient) {}

  get(): Observable<DeveloperInfo> {
    return this.http.get<DeveloperInfo>(this.apiUrl);
  }

  update(info: DeveloperInfo): Observable<DeveloperInfo> {
    return this.http.put<DeveloperInfo>(this.apiUrl, info);
  }
}
