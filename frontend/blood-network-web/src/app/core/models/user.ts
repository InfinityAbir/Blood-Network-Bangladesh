export enum UserRole {
  Donor = 'Donor',
  Requester = 'Requester',
  Admin = 'Admin',
  /** @deprecated Volunteer removed - legacy only */
  Volunteer = 'Volunteer'
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
  mustChangePassword?: boolean;
  createdAt?: string;
  photoUrl?: string;
}

export interface AuthResponse {
  accessToken: string;
  refreshToken: string;
  user: User;
}
