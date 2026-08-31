namespace BloodNetwork.Domain.Enums;

public enum UserRole
{
    Donor = 0,
    Requester = 1,
    [Obsolete("Volunteer role removed - use Requester. Kept for DB compatibility with legacy rows.")]
    Volunteer = 2,
    Admin = 3
}
