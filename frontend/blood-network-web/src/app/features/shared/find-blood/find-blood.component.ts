import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { finalize } from 'rxjs';
import { HeaderComponent } from '../../../layout/header/header.component';
import { FooterComponent } from '../../../layout/footer/footer.component';
import { SkeletonComponent } from '../../../shared/components/skeleton/skeleton.component';
import { DonorService, DonorSearchFilters } from '../../../core/services/donor.service';
import { LocationService, Division, District, Upazila } from '../../../core/services/location.service';
import { PublicDonor, AvailabilityStatus, VerificationStatus } from '../../../core/models/donor';
import { BloodGroup, BloodGroupLabels } from '../../../core/models/blood-group';
import { PagedResult } from '../../../core/models/paged-result';

@Component({
  selector: 'app-find-blood',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatChipsModule,
    HeaderComponent,
    FooterComponent,
    SkeletonComponent
  ],
  template: `
    <app-header />
    <main class="search-container">
      <div class="search-header">
        <h1>Find Blood Donors</h1>
        <p>Search for verified blood donors across Bangladesh</p>
      </div>

      <mat-card class="filter-card">
        <form [formGroup]="searchForm" (ngSubmit)="onSearch()">
          <div class="filter-row">
            <mat-form-field appearance="outline">
              <mat-label>Blood Group</mat-label>
              <mat-select formControlName="bloodGroup">
                <mat-option value="">All Blood Groups</mat-option>
                @for (group of bloodGroups; track group.value) {
                  <mat-option [value]="group.value">{{ group.label }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline">
              <mat-label>Division</mat-label>
              <mat-select formControlName="divisionId" (selectionChange)="onDivisionChange()">
                <mat-option value="">All Divisions</mat-option>
                @for (division of divisions; track division.id) {
                  <mat-option [value]="division.id">{{ division.name }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline">
              <mat-label>District</mat-label>
              <mat-select formControlName="districtId" [disabled]="!searchForm.get('divisionId')?.value" (selectionChange)="onDistrictChange()">
                <mat-option value="">All Districts</mat-option>
                @for (district of districts; track district.id) {
                  <mat-option [value]="district.id">{{ district.name }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline">
              <mat-label>Upazila / Thana</mat-label>
              <mat-select formControlName="upazilaId" [disabled]="!searchForm.get('districtId')?.value">
                <mat-option value="">All Upazilas / Thanas</mat-option>
                @for (upazila of upazilas; track upazila.id) {
                  <mat-option [value]="upazila.id">{{ upazila.name }}</mat-option>
                }
              </mat-select>
            </mat-form-field>

            <mat-form-field appearance="outline">
              <mat-label>Availability</mat-label>
              <mat-select formControlName="availabilityStatus">
                <mat-option value="">All</mat-option>
                <mat-option value="Available">Available Now</mat-option>
                <mat-option value="Unavailable">Unavailable</mat-option>
              </mat-select>
            </mat-form-field>

            <div class="filter-actions">
              <button mat-stroked-button type="button" (click)="resetFilters()" aria-label="Reset filters">
                <mat-icon>clear</mat-icon> Reset
              </button>
              <button mat-raised-button color="primary" type="submit">
                <mat-icon>search</mat-icon> Search
              </button>
            </div>
          </div>
        </form>
      </mat-card>

      @if (errorMessage) {
        <div class="error-banner" role="alert">
          <mat-icon>error_outline</mat-icon>
          <span>{{ errorMessage }}</span>
          <button mat-stroked-button (click)="onSearch()">Retry</button>
        </div>
      }

      @if (isLoading) {
        <div class="results-grid">
          @for (i of [1,2,3,4,5,6]; track i) {
            <mat-card class="sk-donor-card">
              <mat-card-header>
                <mat-card-title><app-skeleton type="line" width="120px" height="16px" /></mat-card-title>
                <mat-card-subtitle><app-skeleton type="line" width="160px" height="12px" /></mat-card-subtitle>
              </mat-card-header>
              <mat-card-content>
                <div class="sk-donor-info">
                  <app-skeleton type="rect" width="50px" height="28px" />
                  <app-skeleton type="rect" width="80px" height="22px" />
                </div>
                <div style="margin-top:8px"><app-skeleton type="line" width="100px" height="12px" /></div>
              </mat-card-content>
            </mat-card>
          }
        </div>
      } @else if (results) {
        <div class="results-header" role="status" aria-live="polite">
          <span>{{ results.totalCount }} {{ results.totalCount === 1 ? 'donor' : 'donors' }} found</span>
        </div>

        <div class="results-grid">
          @for (donor of results.items; track donor.id) {
            <mat-card class="donor-card">
              <mat-card-header>
                <mat-card-title>{{ donor.firstName }}</mat-card-title>
                <mat-card-subtitle>{{ donor.districtName }}, {{ donor.upazilaName }}</mat-card-subtitle>
              </mat-card-header>
              <mat-card-content>
                <div class="donor-info">
                  <span class="blood-badge">{{ getBloodGroupLabel(donor.bloodGroup) }}</span>
                  <div class="status-chip" [class]="'status-' + donor.availabilityStatus.toLowerCase()">
                    {{ donor.availabilityStatus }}
                  </div>
                </div>
                @if (donor.area) {
                  <p class="area">{{ donor.area }}</p>
                }
                @if (donor.distanceKm !== null && donor.distanceKm !== undefined) {
                  <p class="distance">
                    <mat-icon>location_on</mat-icon>
                    {{ donor.distanceKm | number:'1.1-1' }} km away
                  </p>
                }
              </mat-card-content>
              <mat-card-actions align="end">
                <a mat-raised-button color="primary" routerLink="/request-blood" [queryParams]="{bloodGroup: donor.bloodGroup}">
                  <mat-icon>send</mat-icon> Request Blood
                </a>
              </mat-card-actions>
            </mat-card>
           } @empty {
             <div class="no-results">
               <mat-icon>search_off</mat-icon>
               <p>No donors found matching your criteria</p>
               <p class="hint">Try adjusting filters or create a request to notify donors.</p>
               <a mat-raised-button color="primary" routerLink="/request-blood"><mat-icon>volunteer_activism</mat-icon> Create Blood Request</a>
             </div>
           }
         </div>
         <div class="cta-banner">
           <p>Can't find the right donor? Create a blood request and we'll match you automatically.</p>
           <a mat-raised-button color="primary" routerLink="/request-blood"><mat-icon>send</mat-icon> Request Blood Now</a>
         </div>

        @if (results.totalPages > 1) {
          <div class="pagination" role="navigation" aria-label="Search results pagination">
            <button mat-button [disabled]="!results.hasPrevious" (click)="goToPage(results.page - 1)" aria-label="Previous page">Previous</button>
            <span aria-current="page">Page {{ results.page }} of {{ results.totalPages }}</span>
            <button mat-button [disabled]="!results.hasNext" (click)="goToPage(results.page + 1)" aria-label="Next page">Next</button>
          </div>
        }
      }
    </main>
    <app-footer />
  `,
  styles: [`
    .search-container { flex: 1; padding: 24px; max-width: 1200px; margin: 0 auto; width: 100%; box-sizing: border-box; }
    .search-header { margin-bottom: 20px; }
    .search-header h1 { margin: 0 0 4px; font-size: 24px; color: var(--bgn-text); }
    .search-header p { margin: 0; color: var(--bgn-text-muted); }
    .filter-card { margin-bottom: 24px; padding: 20px 20px 16px !important; border: 1px solid var(--bgn-border) !important; box-shadow: var(--bgn-shadow-sm) !important; }
    .filter-row { display: grid; grid-template-columns: repeat(5, minmax(0, 1fr)) auto; gap: 12px; align-items: end; }
    .filter-row mat-form-field { width: 100%; }
    .filter-actions { display: flex; gap: 8px; align-items: center; margin-bottom: 22px; }
    .filter-actions button { height: 56px; white-space: nowrap; border-radius: var(--bgn-radius-pill) !important; min-width: 96px; }
    @media (max-width: 1100px) { .filter-row { grid-template-columns: repeat(3, 1fr); } .filter-actions { grid-column: 1 / -1; justify-content: flex-end; margin-bottom: 0; } }
    @media (max-width: 700px) { .filter-row { grid-template-columns: 1fr; } .filter-actions { justify-content: stretch; } .filter-actions button { flex: 1; } }
    .results-header { margin-bottom: 16px; color: #666; }
    .results-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(280px, 1fr)); gap: 16px; margin-bottom: 24px; }
    .sk-donor-card { min-height: 130px; }
    .sk-donor-info { display: flex; align-items: center; gap: 12px; margin-top: 8px; }
    .donor-card { cursor: default; }
    .donor-info { display: flex; align-items: center; gap: 12px; margin: 8px 0; }
    .blood-badge { background: var(--bgn-primary, #c62828); color: white; padding: 3px 10px; border-radius: 6px; font-weight: 600; font-size: 13px; white-space: nowrap; letter-spacing: 0.5px; }
    .status-chip { display: inline-block; padding: 2px 10px; border-radius: 12px; font-size: 12px; }
    .status-available { background: #e8f5e9; color: #2e7d32; }
    .status-unavailable { background: #ffebee; color: #c62828; }
    .status-recentlydonated { background: #fff3e0; color: #e65100; }
    .status-unknown { background: #f5f5f5; color: #666; }
    .area { color: #666; font-size: 14px; margin: 4px 0; }
    .distance { color: #1565c0; font-size: 13px; display: flex; align-items: center; gap: 4px; }
    .distance mat-icon { font-size: 16px; width: 16px; height: 16px; }
    .error-banner { display:flex; align-items:center; gap:12px; padding:12px 16px; background: color-mix(in srgb, var(--bgn-danger) 10%, transparent); border:1px solid color-mix(in srgb, var(--bgn-danger) 30%, transparent); color: var(--bgn-danger); border-radius: var(--bgn-radius-md); margin-bottom:16px; }
    .no-results { grid-column: 1 / -1; text-align: center; padding: 40px 16px; color: var(--bgn-text-muted); border:1px dashed var(--bgn-border); border-radius: var(--bgn-radius-md); }
    .no-results mat-icon { font-size: 48px; width: 48px; height: 48px; color: var(--bgn-text-faint); }
    .no-results .hint { font-size: 13px; margin: 4px 0 12px; }
    .cta-banner { text-align: center; padding: 20px; background: var(--bgn-surface-2); border: 1px solid var(--bgn-border); border-radius: var(--bgn-radius-md); margin-bottom: 24px; }
    .cta-banner p { margin: 0 0 12px; color: var(--bgn-text-muted); }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 16px; flex-wrap: wrap; }
  `]
})
export class FindBloodComponent implements OnInit {
  searchForm: FormGroup;
  isLoading = false;
  errorMessage: string | null = null;
  results: PagedResult<PublicDonor> | null = null;

  divisions: Division[] = [];
  districts: District[] = [];
  upazilas: Upazila[] = [];

  bloodGroups = Object.entries(BloodGroupLabels).map(([value, label]) => ({ value, label }));

  constructor(
    private fb: FormBuilder,
    private donorService: DonorService,
    private locationService: LocationService,
    private cdr: ChangeDetectorRef
  ) {
    this.searchForm = this.fb.group({
      bloodGroup: [''],
      divisionId: [''],
      districtId: [''],
      upazilaId: [''],
      availabilityStatus: ['']
    });
  }

  ngOnInit(): void {
    this.locationService.getDivisions().subscribe({ next: divs => this.divisions = divs, error: (e) => console.debug(e) });
    this.onSearch();
  }

  onDivisionChange(): void {
    const divisionId = this.searchForm.get('divisionId')?.value;
    this.searchForm.patchValue({ districtId: '', upazilaId: '' });
    this.upazilas = [];
    if (divisionId) {
      this.locationService.getDistricts(divisionId).subscribe({ next: d => this.districts = d, error: (e) => console.debug(e) });
    } else {
      this.districts = [];
    }
  }

  onDistrictChange(): void {
    const districtId = this.searchForm.get('districtId')?.value;
    this.searchForm.patchValue({ upazilaId: '' });
    if (districtId) {
      this.locationService.getUpazilas(districtId).subscribe({ next: u => this.upazilas = u, error: (e) => console.debug(e) });
    } else {
      this.upazilas = [];
    }
  }

  resetFilters(): void {
    this.searchForm.reset({ bloodGroup: '', divisionId: '', districtId: '', upazilaId: '', availabilityStatus: '' });
    this.districts = [];
    this.upazilas = [];
    this.onSearch();
  }

  onSearch(): void {
    this.isLoading = true;
    this.errorMessage = null;
    const formValue = this.searchForm.value;

    const filters: DonorSearchFilters = {
      bloodGroup: formValue.bloodGroup || undefined,
      districtId: formValue.districtId || undefined,
      upazilaId: formValue.upazilaId || undefined,
      availabilityStatus: formValue.availabilityStatus || undefined,
      page: 1,
      pageSize: 20
    };

    this.donorService.searchDonors(filters).pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (results) => { this.results = results; this.errorMessage = null; },
      error: (e) => { this.errorMessage = e.error?.message || 'Failed to search donors. Please try again.'; }
    });
  }

  goToPage(page: number): void {
    this.isLoading = true;
    this.errorMessage = null;
    const formValue = this.searchForm.value;

    const filters: DonorSearchFilters = {
      bloodGroup: formValue.bloodGroup || undefined,
      districtId: formValue.districtId || undefined,
      upazilaId: formValue.upazilaId || undefined,
      availabilityStatus: formValue.availabilityStatus || undefined,
      page,
      pageSize: 20
    };

    this.donorService.searchDonors(filters).pipe(
      finalize(() => { this.isLoading = false; this.cdr.detectChanges(); })
    ).subscribe({
      next: (results) => { this.results = results; },
      error: (e) => { this.errorMessage = e.error?.message || 'Failed to load page.'; }
    });
  }

  getBloodGroupLabel(group: string): string {
    return (BloodGroupLabels as any)[group] || group;
  }
}
