import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { BloodRequest, CreateBloodRequest, RequestStatus } from '../models/blood-request';
import { PagedResult } from '../models/paged-result';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private readonly apiUrl = `${environment.apiUrl}/blood-requests`;

  constructor(private http: HttpClient) {}

  createRequest(data: CreateBloodRequest): Observable<BloodRequest> {
    return this.http.post<BloodRequest>(this.apiUrl, data);
  }

  getRequest(id: string): Observable<BloodRequest> {
    return this.http.get<BloodRequest>(`${this.apiUrl}/${id}`);
  }

  getMyRequests(status?: RequestStatus, page = 1, pageSize = 20): Observable<PagedResult<BloodRequest>> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());
    if (status) params = params.set('status', status);
    return this.http.get<PagedResult<BloodRequest>>(`${this.apiUrl}/my`, { params });
  }

  searchOpenRequests(filters: {
    bloodGroup?: string;
    districtId?: string;
    urgency?: string;
    page?: number;
    pageSize?: number;
  }): Observable<PagedResult<BloodRequest>> {
    let params = new HttpParams();
    if (filters.bloodGroup) params = params.set('bloodGroup', filters.bloodGroup);
    if (filters.districtId) params = params.set('districtId', filters.districtId);
    if (filters.urgency) params = params.set('urgency', filters.urgency);
    if (filters.page) params = params.set('page', filters.page.toString());
    if (filters.pageSize) params = params.set('pageSize', filters.pageSize.toString());
    return this.http.get<PagedResult<BloodRequest>>(`${this.apiUrl}/open`, { params });
  }

  cancelRequest(id: string): Observable<BloodRequest> {
    return this.http.patch<BloodRequest>(`${this.apiUrl}/${id}/cancel`, {});
  }

  fulfillRequest(id: string, unitsFulfilled: number): Observable<BloodRequest> {
    return this.http.patch<BloodRequest>(`${this.apiUrl}/${id}/fulfill`, { unitsFulfilled });
  }
}
