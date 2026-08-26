import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { DonorProfile, PublicDonor, AvailabilityStatus } from '../models/donor';
import { BloodGroup } from '../models/blood-group';
import { PagedResult } from '../models/paged-result';

export interface DonorSearchFilters {
  bloodGroup?: BloodGroup;
  districtId?: string;
  upazilaId?: string;
  availabilityStatus?: AvailabilityStatus;
  latitude?: number;
  longitude?: number;
  page?: number;
  pageSize?: number;
}

@Injectable({
  providedIn: 'root'
})
export class DonorService {
  private readonly apiUrl = `${environment.apiUrl}/donors`;

  constructor(private http: HttpClient) {}

  getMyProfile(): Observable<DonorProfile> {
    return this.http.get<DonorProfile>(`${this.apiUrl}/me/profile`);
  }

  createProfile(data: {
    bloodGroup: BloodGroup;
    gender?: string;
    dateOfBirth?: string;
    districtId: string;
    upazilaId: string;
    area?: string;
    latitude?: number;
    longitude?: number;
  }): Observable<DonorProfile> {
    return this.http.post<DonorProfile>(`${this.apiUrl}/me/profile`, data);
  }

  updateProfile(data: {
    bloodGroup: BloodGroup;
    gender?: string;
    dateOfBirth?: string;
    districtId: string;
    upazilaId: string;
    area?: string;
    latitude?: number;
    longitude?: number;
  }): Observable<DonorProfile> {
    return this.http.put<DonorProfile>(`${this.apiUrl}/me/profile`, data);
  }

  toggleAvailability(availabilityStatus: AvailabilityStatus): Observable<DonorProfile> {
    return this.http.patch<DonorProfile>(`${this.apiUrl}/me/availability`, { availabilityStatus });
  }

  searchDonors(filters: DonorSearchFilters): Observable<PagedResult<PublicDonor>> {
    let params = new HttpParams();
    if (filters.bloodGroup) params = params.set('bloodGroup', filters.bloodGroup);
    if (filters.districtId) params = params.set('districtId', filters.districtId);
    if (filters.upazilaId) params = params.set('upazilaId', filters.upazilaId);
    if (filters.availabilityStatus) params = params.set('availabilityStatus', filters.availabilityStatus);
    if (filters.latitude) params = params.set('latitude', filters.latitude.toString());
    if (filters.longitude) params = params.set('longitude', filters.longitude.toString());
    if (filters.page) params = params.set('page', filters.page.toString());
    if (filters.pageSize) params = params.set('pageSize', filters.pageSize.toString());
    return this.http.get<PagedResult<PublicDonor>>(`${this.apiUrl}/search`, { params });
  }
}
