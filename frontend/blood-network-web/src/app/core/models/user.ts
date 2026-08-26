export enum UserRole {
  Donor = 'Donor',
  Requester = 'Requester',
  Volunteer = 'Volunteer',
  Admin = 'Admin'
}

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email?: string;
  role: UserRole;
  isActive: boolean;
  isPhoneVerified: boolean;
}

export interface AuthResponse {
  token: string;
  refreshToken?: string;
  user: User;
  expiresAt: string;
}
