export interface Notification {
  id: string;
  type: 'BloodRequestMatch' | 'RequestUpdate' | 'DonorAccepted' | 'DonorDeclined' | 'ProfileReminder' | 'System';
  title: string;
  message: string;
  relatedEntityId?: string;
  isRead: boolean;
  readAt?: string;
  createdAt: string;
}
