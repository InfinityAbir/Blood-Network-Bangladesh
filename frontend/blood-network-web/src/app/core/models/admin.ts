export interface AdminDashboardStats {
  totalUsers: number;
  totalDonors: number;
  totalRequesters: number;
  totalBloodRequests: number;
  openBloodRequests: number;
  fulfilledBloodRequests: number;
  totalMatches: number;
  acceptedMatches: number;
  totalReports: number;
  openReports: number;
  pendingVerifications: number;
}

export interface AdminUser {
  id: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email?: string;
  role: 'Donor' | 'Requester' | 'Volunteer' | 'Admin';
  isActive: boolean;
  isPhoneVerified: boolean;
  lastLoginAt?: string;
  createdAt: string;
  donorVerificationStatus?: string;
}

export interface AdminReport {
  id: string;
  reporterName: string;
  reportedUserName: string;
  bloodRequestId?: string;
  reason: string;
  description?: string;
  status: 'Open' | 'UnderReview' | 'Resolved' | 'Dismissed';
  reviewedByName?: string;
  resolution?: string;
  resolvedAt?: string;
  createdAt: string;
}

export interface AdminAuditLog {
  id: string;
  userName?: string;
  action: string;
  entityType: string;
  entityId?: string;
  ipAddress?: string;
  metadata?: string;
  createdAt: string;
}
