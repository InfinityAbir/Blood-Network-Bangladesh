import { BloodGroup } from './blood-group';

export enum AvailabilityStatus {
  Available = 'Available',
  Unavailable = 'Unavailable',
  RecentlyDonated = 'RecentlyDonated',
  Unknown = 'Unknown'
}

export enum VerificationStatus {
  Unverified = 'Unverified',
  Pending = 'Pending',
  Verified = 'Verified',
  Rejected = 'Rejected'
}

export interface DonorProfile {
  id: string;
  userId: string;
  bloodGroup: BloodGroup;
  gender?: string;
  districtId: string;
  upazilaId: string;
  area?: string;
  lastDonationDate?: string;
  availabilityStatus: AvailabilityStatus;
  verificationStatus: VerificationStatus;
  totalDonationCount: number;
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
