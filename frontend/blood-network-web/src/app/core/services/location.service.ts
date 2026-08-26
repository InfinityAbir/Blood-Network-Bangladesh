import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Division {
  id: string;
  name: string;
  nameBn: string;
}

export interface District {
  id: string;
  divisionId: string;
  name: string;
  nameBn: string;
}

export interface Upazila {
  id: string;
  districtId: string;
  name: string;
  nameBn: string;
}

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  private readonly apiUrl = `${environment.apiUrl}/locations`;

  constructor(private http: HttpClient) {}

  getDivisions(): Observable<Division[]> {
    return this.http.get<Division[]>(`${this.apiUrl}/divisions`);
  }

  getDistricts(divisionId?: string): Observable<District[]> {
    let params = new HttpParams();
    if (divisionId) params = params.set('divisionId', divisionId);
    return this.http.get<District[]>(`${this.apiUrl}/districts`, { params });
  }

  getUpazilas(districtId?: string): Observable<Upazila[]> {
    let params = new HttpParams();
    if (districtId) params = params.set('districtId', districtId);
    return this.http.get<Upazila[]>(`${this.apiUrl}/upazilas`, { params });
  }
}
