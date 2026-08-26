import { BloodGroup } from './blood-group';

export enum Urgency {
  Critical = 'Critical',
  Urgent = 'Urgent',
  Normal = 'Normal'
}

export enum RequestStatus {
  Open = 'Open',
  PartiallyFulfilled = 'PartiallyFulfilled',
  Fulfilled = 'Fulfilled',
  Cancelled = 'Cancelled',
  Expired = 'Expired'
}

export interface BloodRequest {
  id: string;
  requesterId: string;
  requesterName: string;
  bloodGroup: BloodGroup;
  unitsRequired: number;
  unitsFulfilled: number;
  hospitalName: string;
  hospitalAddress: string;
  districtId: string;
  districtName?: string;
  upazilaId: string;
  upazilaName?: string;
  area?: string;
  requiredBy: string;
  urgency: Urgency;
  patientName?: string;
  patientRelation?: string;
  contactPhone: string;
  additionalInformation?: string;
  status: RequestStatus;
  completedAt?: string;
  cancelledAt?: string;
  createdAt: string;
}

export interface CreateBloodRequest {
  bloodGroup: BloodGroup;
  unitsRequired: number;
  hospitalName: string;
  hospitalAddress: string;
  districtId: string;
  upazilaId: string;
  area?: string;
  requiredBy: string;
  urgency: Urgency;
  patientName?: string;
  patientRelation?: string;
  contactPhone: string;
  additionalInformation?: string;
}
