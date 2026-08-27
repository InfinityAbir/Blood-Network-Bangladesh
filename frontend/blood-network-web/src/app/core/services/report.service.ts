import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface CreateReport {
  reportedUserId: string;
  bloodRequestId?: string;
  reason: string;
  description?: string;
}

@Injectable({ providedIn: 'root' })
export class ReportService {
  private readonly apiUrl = `${environment.apiUrl}/reports`;

  constructor(private http: HttpClient) {}

  createReport(report: CreateReport): Observable<{ message: string }> {
    return this.http.post<{ message: string }>(this.apiUrl, report);
  }
}
