import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AdminDashboardStats, AdminUser, AdminReport, AdminAuditLog } from '../models/admin';
import { PagedResult } from '../models/paged-result';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private readonly apiUrl = `${environment.apiUrl}/admin`;

  constructor(private http: HttpClient) {}

  getDashboardStats(): Observable<AdminDashboardStats> {
    return this.http.get<AdminDashboardStats>(`${this.apiUrl}/dashboard`);
  }

  getUsers(filters: { search?: string; role?: string; page?: number; pageSize?: number }): Observable<PagedResult<AdminUser>> {
    let params = new HttpParams();
    if (filters.search) params = params.set('search', filters.search);
    if (filters.role) params = params.set('role', filters.role);
    if (filters.page) params = params.set('page', filters.page.toString());
    if (filters.pageSize) params = params.set('pageSize', filters.pageSize.toString());
    return this.http.get<PagedResult<AdminUser>>(`${this.apiUrl}/users`, { params });
  }

  toggleUserActive(userId: string, isActive: boolean): Observable<AdminUser> {
    return this.http.post<AdminUser>(`${this.apiUrl}/users/${userId}/toggle-active`, { isActive });
  }

  verifyDonor(userId: string, status: string): Observable<AdminUser> {
    return this.http.post<AdminUser>(`${this.apiUrl}/users/${userId}/verify-donor`, { status });
  }

  getReports(filters: { status?: string; page?: number; pageSize?: number }): Observable<PagedResult<AdminReport>> {
    let params = new HttpParams();
    if (filters.status) params = params.set('status', filters.status);
    if (filters.page) params = params.set('page', filters.page.toString());
    if (filters.pageSize) params = params.set('pageSize', filters.pageSize.toString());
    return this.http.get<PagedResult<AdminReport>>(`${this.apiUrl}/reports`, { params });
  }

  resolveReport(reportId: string, status: string, resolution?: string): Observable<AdminReport> {
    return this.http.post<AdminReport>(`${this.apiUrl}/reports/${reportId}/resolve`, { status, resolution });
  }

  getAuditLogs(filters: { entityType?: string; page?: number; pageSize?: number }): Observable<PagedResult<AdminAuditLog>> {
    let params = new HttpParams();
    if (filters.entityType) params = params.set('entityType', filters.entityType);
    if (filters.page) params = params.set('page', filters.page.toString());
    if (filters.pageSize) params = params.set('pageSize', filters.pageSize.toString());
    return this.http.get<PagedResult<AdminAuditLog>>(`${this.apiUrl}/audit-logs`, { params });
  }
}
