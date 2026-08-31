import { BloodGroup } from './blood-group';

export enum AvailabilityStatus {
  Available = 'Available',
  Unavailable = 'Unavailable',
  RecentlyDonated = 'RecentlyDonated',
  Unknown = 'Unknown'
}

export enum VerificationStatus {
  Unverified = 'Unverified',
  Verified = 'Verified',
  Rejected = 'Rejected',
  /** @deprecated Pending removed - legacy only */
  Pending = 'Pending'
}

export interface DonorProfile {
  id: string;
  userId: string;
  bloodGroup: BloodGroup;
  gender?: string;
  dateOfBirth?: string;
  districtId: string;
  districtName?: string;
  upazilaId: string;
  upazilaName?: string;
  area?: string;
  customAddress?: string;
  lastDonationDate?: string;
  availabilityStatus: AvailabilityStatus;
  verificationStatus: VerificationStatus;
  totalDonationCount: number;
  latitude?: number;
  longitude?: number;
  createdAt: string;
}

export interface PublicDonor {
  id: string;
  firstName: string;
  bloodGroup: BloodGroup;
  districtName: string;
  upazilaName: string;
  area?: string;
  availabilityStatus: AvailabilityStatus;
  verificationStatus: VerificationStatus;
  distanceKm?: number;
}
