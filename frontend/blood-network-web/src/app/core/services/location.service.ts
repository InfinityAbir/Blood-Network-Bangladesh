import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, shareReplay } from 'rxjs';
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

  private divisionsCache$: Observable<Division[]> | null = null;
  private districtsCache = new Map<string, Observable<District[]>>();
  private upazilasCache = new Map<string, Observable<Upazila[]>>();

  constructor(private http: HttpClient) {}

  getDivisions(): Observable<Division[]> {
    if (!this.divisionsCache$) {
      this.divisionsCache$ = this.http.get<Division[]>(`${this.apiUrl}/divisions`).pipe(
        shareReplay({ bufferSize: 1, refCount: false })
      );
    }
    return this.divisionsCache$;
  }

  getDistricts(divisionId?: string): Observable<District[]> {
    const key = divisionId ?? 'all';
    if (!this.districtsCache.has(key)) {
      let params = new HttpParams();
      if (divisionId) params = params.set('divisionId', divisionId);
      const obs = this.http.get<District[]>(`${this.apiUrl}/districts`, { params }).pipe(
        shareReplay({ bufferSize: 1, refCount: false })
      );
      this.districtsCache.set(key, obs);
    }
    return this.districtsCache.get(key)!;
  }

  getUpazilas(districtId?: string): Observable<Upazila[]> {
    const key = districtId ?? 'all';
    if (!this.upazilasCache.has(key)) {
      let params = new HttpParams();
      if (districtId) params = params.set('districtId', districtId);
      const obs = this.http.get<Upazila[]>(`${this.apiUrl}/upazilas`, { params }).pipe(
        shareReplay({ bufferSize: 1, refCount: false })
      );
      this.upazilasCache.set(key, obs);
    }
    return this.upazilasCache.get(key)!;
  }
}
