export interface BloodRequestMatch {
  id: string;
  bloodRequestId: string;
  donorId: string;
  donorName: string;
  donorPhone: string;
  donorBloodGroup: string;
  hospitalName: string;
  requesterName: string;
  requesterPhone: string;
  matchScore: number;
  distanceKm?: number;
  donorResponse: 'Pending' | 'Accepted' | 'Declined' | 'NoResponse';
  contactedAt?: string;
  respondedAt?: string;
  acceptedAt?: string;
  declinedAt?: string;
  createdAt: string;
}

export interface RespondToMatch {
  response: 'Accepted' | 'Declined';
}
