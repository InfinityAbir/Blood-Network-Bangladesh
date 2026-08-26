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
  bloodGroup: BloodGroup;
  unitsRequired: number;
  unitsFulfilled: number;
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
  status: RequestStatus;
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
