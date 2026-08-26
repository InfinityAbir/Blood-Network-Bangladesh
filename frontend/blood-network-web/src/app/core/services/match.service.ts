import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { BloodRequestMatch, RespondToMatch } from '../models/match';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private readonly apiUrl = `${environment.apiUrl}/matches`;

  constructor(private http: HttpClient) {}

  getMatchesForRequest(requestId: string): Observable<BloodRequestMatch[]> {
    return this.http.get<BloodRequestMatch[]>(`${this.apiUrl}/request/${requestId}`);
  }

  getMyMatches(): Observable<BloodRequestMatch[]> {
    return this.http.get<BloodRequestMatch[]>(`${this.apiUrl}/donor`);
  }

  getMatch(id: string): Observable<BloodRequestMatch> {
    return this.http.get<BloodRequestMatch>(`${this.apiUrl}/${id}`);
  }

  respondToMatch(matchId: string, response: RespondToMatch): Observable<BloodRequestMatch> {
    return this.http.post<BloodRequestMatch>(`${this.apiUrl}/${matchId}/respond`, response);
  }
}
