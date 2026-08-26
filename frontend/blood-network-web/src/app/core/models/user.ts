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
  mustChangePassword?: boolean;
  createdAt?: string;
}

export interface AuthResponse {
  accessToken: string;
  refreshToken: string;
  user: User;
}
