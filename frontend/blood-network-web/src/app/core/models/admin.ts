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
  role: 'Donor' | 'Requester' | 'Admin' | 'Volunteer'; // Volunteer legacy only
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

export interface AdminEligibilityQuestion {
  id: string;
  questionEn: string;
  questionBn: string;
  questionBanglish: string;
  questionType: 'number' | 'yesno';
  unit?: string;
  minValue?: number;
  maxValue?: number;
  passOnYes?: boolean;
  isCritical: boolean;
  isActive: boolean;
  displayOrder: number;
  passMessageEn: string;
  passMessageBn: string;
  failMessageEn: string;
  failMessageBn: string;
}

export interface SaveEligibilityQuestionRequest {
  questionEn: string;
  questionBn: string;
  questionBanglish: string;
  questionType: 'number' | 'yesno';
  unit?: string;
  minValue?: number;
  maxValue?: number;
  passOnYes?: boolean;
  isCritical: boolean;
  displayOrder: number;
  passMessageEn: string;
  passMessageBn: string;
  failMessageEn: string;
  failMessageBn: string;
}
