# Blood Network Bangladesh
## Product Requirements Document (PRD)

**Document version:** 1.0  
**Status:** MVP specification  
**Primary goal:** Build a mobile-friendly web platform that helps people in Bangladesh find eligible, available blood donors quickly during normal and emergency situations.

---

# 1. Product Overview

## 1.1 Product name

Working name: **Blood Network Bangladesh**

The name can be changed later. The system should be designed so branding and application name are configurable.

## 1.2 Product vision

Create a reliable blood donor network where a person who needs blood can quickly submit a request and find suitable nearby donors.

The platform should focus on **real-time donor availability and practical matching**, rather than being only a static donor directory.

## 1.3 Core problem

Existing blood donor directories can contain outdated donor information. A donor may have:

- Changed phone number
- Moved to another area
- Recently donated
- Become temporarily unavailable
- Registered a long time ago and never returned

Therefore, simply showing a list of registered donors is not enough.

The product should answer:

> "Which suitable donors are likely to be available and reachable right now?"

## 1.4 MVP objective

The MVP must support this complete flow:

```text
Person needs blood
        ↓
Creates blood request
        ↓
System validates request
        ↓
System finds suitable donors
        ↓
Donors are ranked by eligibility, availability and proximity
        ↓
Donors receive/see request
        ↓
Donor accepts or declines
        ↓
Requester can coordinate with donor
        ↓
Request is updated and eventually completed
```

---

# 2. Product Principles

1. **Emergency first:** The most important workflow is finding a donor quickly.
2. **Availability over registration count:** An active donor is more valuable than an old profile.
3. **Privacy by default:** Do not publicly expose sensitive donor information.
4. **Trust matters:** Verification and profile freshness should be visible.
5. **Mobile-first:** Most users will access the system from phones.
6. **Simple emergency UX:** A person under stress should complete a request quickly.
7. **API-first architecture:** The backend must support a future mobile application without redesigning the core system.
8. **No blood trading:** The platform is for voluntary blood donation and coordination, not buying or selling blood.
9. **Medical safety:** The platform must not claim that a donor is medically fit. Final donor eligibility must be determined by the appropriate medical professional or blood collection service.
10. **Bangladesh-focused:** Location hierarchy, phone numbers, language and workflows should support Bangladesh.

---

# 3. Target Users

## 3.1 Donor

A person willing to donate blood.

Main needs:

- Register easily
- Maintain blood group and location
- Set availability
- Receive relevant requests
- Accept/decline requests
- Track donation history
- Know when they may be contacted again

## 3.2 Blood requester

A patient, family member, friend or volunteer requesting blood.

Main needs:

- Create emergency request quickly
- Find suitable nearby donors
- Contact/coordinate with donors
- Track request status

## 3.3 Volunteer

A person or organization helping coordinate blood donations.

Main needs:

- Create/manage requests
- Contact donors
- Track successful matches
- Support local communities

For MVP, volunteers can use the requester workflow. A dedicated volunteer role can be expanded later.

## 3.4 Administrator

System operator.

Main needs:

- Manage users
- Verify donors
- Review reports
- Manage blood requests
- Monitor platform activity
- Block abusive/fake accounts
- View statistics

## 3.5 Future hospital/organization user

Not required for MVP, but architecture should allow a separate hospital/organization role later.

---

# 4. MVP Scope

## 4.1 In scope

- Public landing page
- Donor registration
- Login/logout
- Donor profile
- Phone verification
- Blood group
- Bangladesh location information
- Last donation date
- Availability status
- Donor search
- Emergency blood request
- Donor matching
- Request status management
- Donor accept/decline
- Contact/coordination
- Donation history
- Basic verification
- Admin dashboard
- Admin user management
- Admin request management
- Basic reporting
- Responsive UI
- REST API
- Audit logging for important actions

## 4.2 Out of scope for MVP

Do not implement these unless explicitly requested later:

- Native Android application
- Native iOS application
- AI/ML matching
- Online payment
- Blood buying/selling
- Hospital ERP
- Blood bank inventory management
- Medical diagnosis
- Medical eligibility certification
- Public exact donor addresses
- Public donor phone-number directory
- Advanced social networking
- Complex gamification
- Real-time chat
- Video calling
- Automated medical advice
- Government/NID integration
- National-level identity verification
- Complex analytics
- Multi-country support

---

# 5. Recommended Technology Stack

The project should use a clean, maintainable architecture.

## Frontend

- Angular
- TypeScript
- Angular Router
- Angular Reactive Forms
- Angular HttpClient
- Angular Material or another consistent component library
- Responsive CSS
- Mobile-first layouts

The frontend must not contain critical business rules that should be enforced by the backend.

## Backend

- ASP.NET Core
- C#
- RESTful APIs
- Clean Architecture
- Entity Framework Core
- FluentValidation or equivalent validation approach
- JWT-based authentication
- Role-based authorization

## Database

Primary recommendation:

- PostgreSQL

The database layer should be designed so SQL Server could be supported later if required.

## Notifications

MVP can start with:

- In-app notifications

Architecture should allow later:

- SMS
- Email
- Firebase Cloud Messaging push notifications

Do not hard-code the system around a single notification provider.

## Mapping/location

Use a provider abstraction.

Possible providers:

- OpenStreetMap
- Google Maps

Do not expose exact donor coordinates publicly.

---

# 6. Architecture

Use Clean Architecture.

Recommended project structure:

```text
src/
  BloodNetwork.Api/
  BloodNetwork.Application/
  BloodNetwork.Domain/
  BloodNetwork.Infrastructure/

tests/
  BloodNetwork.UnitTests/
  BloodNetwork.IntegrationTests/

frontend/
  blood-network-web/
```

## 6.1 Domain layer

Contains:

- Entities
- Value objects
- Enums
- Domain rules
- Domain exceptions
- Interfaces where appropriate

The Domain layer must not depend on infrastructure or Angular.

## 6.2 Application layer

Contains:

- Commands
- Queries
- DTOs
- Validators
- Use cases
- Application services
- Authorization rules
- Interfaces for external services

## 6.3 Infrastructure layer

Contains:

- EF Core
- PostgreSQL
- Authentication implementation
- Notification providers
- SMS provider integration
- Email provider integration
- Geolocation provider integration
- File storage if later required

## 6.4 API layer

Contains:

- Controllers/endpoints
- Authentication
- Middleware
- Exception handling
- API documentation
- Dependency injection configuration

---

# 7. Core Domain Model

The following entities are recommended for MVP.

## 7.1 User

Fields:

- Id
- FirstName
- LastName
- PhoneNumber
- Email
- PasswordHash
- Role
- IsActive
- IsPhoneVerified
- CreatedAt
- UpdatedAt
- LastLoginAt

Roles:

```text
Donor
Requester
Volunteer
Admin
```

A user can later have multiple roles if the architecture supports it.

## 7.2 DonorProfile

Fields:

- Id
- UserId
- BloodGroup
- Gender (optional)
- DateOfBirth (optional; avoid collecting unless required)
- DistrictId
- UpazilaId
- Area
- LastDonationDate
- AvailabilityStatus
- VerificationStatus
- LastProfileConfirmedAt
- TotalDonationCount
- CreatedAt
- UpdatedAt

Availability statuses:

```text
Available
Unavailable
RecentlyDonated
Unknown
```

Verification statuses:

```text
Unverified
Pending
Verified
Rejected
```

Important:

`Available` means the donor is willing to be contacted. It must not be interpreted as a medical certification that the person is currently fit to donate.

## 7.3 Location

Use normalized Bangladesh administrative data.

Recommended hierarchy:

```text
Division
  ↓
District
  ↓
Upazila
  ↓
Area
```

Do not store only free-text district values.

## 7.4 BloodRequest

Fields:

- Id
- RequesterId
- BloodGroup
- UnitsRequired
- UnitsFulfilled
- HospitalName
- HospitalAddress
- DistrictId
- UpazilaId
- Area
- Latitude (optional/private)
- Longitude (optional/private)
- RequiredBy
- Urgency
- PatientName (optional)
- PatientRelation (optional)
- ContactPhone
- AdditionalInformation
- Status
- CreatedAt
- UpdatedAt
- CompletedAt
- CancelledAt

Urgency:

```text
Critical
Urgent
Normal
```

Status:

```text
Open
PartiallyFulfilled
Fulfilled
Cancelled
Expired
```

## 7.5 BloodRequestMatch

Represents a donor matched to a blood request.

Fields:

- Id
- BloodRequestId
- DonorId
- MatchScore
- DistanceKm
- EligibilityStatus
- DonorResponse
- ContactedAt
- RespondedAt
- AcceptedAt
- DeclinedAt
- CreatedAt
- UpdatedAt

Donor response:

```text
Pending
Accepted
Declined
NoResponse
```

## 7.6 DonationRecord

Fields:

- Id
- DonorId
- BloodRequestId (nullable)
- DonationDate
- DonationLocation (optional)
- Units (optional)
- Notes (optional)
- CreatedBy
- CreatedAt

For MVP, donation records can be entered by the donor or admin. The platform must not present them as medically verified unless verified by an authorized source.

## 7.7 Notification

Fields:

- Id
- UserId
- Type
- Title
- Message
- RelatedEntityId
- IsRead
- CreatedAt
- ReadAt

Types:

```text
BloodRequestMatch
RequestUpdate
DonorAccepted
DonorDeclined
ProfileReminder
System
```

## 7.8 VerificationRecord

Fields:

- Id
- UserId
- Type
- Status
- VerifiedBy
- Notes
- CreatedAt
- UpdatedAt

Types may include:

```text
Phone
Profile
BloodGroup
```

Do not implement government identity verification in MVP.

## 7.9 Report

Fields:

- Id
- ReporterUserId
- ReportedUserId
- BloodRequestId (nullable)
- Reason
- Description
- Status
- ReviewedBy
- Resolution
- CreatedAt
- ResolvedAt

## 7.10 AuditLog

Fields:

- Id
- UserId
- Action
- EntityType
- EntityId
- Timestamp
- IpAddress (if appropriate)
- Metadata

Record important actions such as:

- Login
- Donor verification
- Request creation
- Request cancellation
- Donor acceptance
- Donor blocking
- Admin changes

---

# 8. Blood Groups

MVP should support:

```text
A+
A-
B+
B-
AB+
AB-
O+
O-
```

Store blood groups as an enum or controlled reference value.

Do not allow arbitrary free-text blood groups.

---

# 9. Blood Compatibility

The platform may use standard ABO/Rh red-blood-cell compatibility rules for donor matching.

Recommended donor-to-recipient compatibility:

```text
O-  → A-, A+, B-, B+, AB-, AB+, O-, O+
O+  → A+, B+, AB+, O+
A-  → A-, A+, AB-, AB+
A+  → A+, AB+
B-  → B-, B+, AB-, AB+
B+  → B+, AB+
AB- → AB-, AB+
AB+ → AB+
```

However:

**This is a logistical matching aid, not medical advice.**

The final decision about compatibility, donor eligibility and transfusion must be made by qualified medical professionals.

If the product scope later changes to platelet/plasma donation, compatibility logic must be redesigned separately.

---

# 10. Donor Eligibility Logic

The system should distinguish:

### Registered

The person has a donor account.

### Available

The donor has indicated willingness to be contacted.

### Potentially eligible

Based on the recorded last donation date and configurable system rules, the donor may be due for another donation.

### Medically eligible

The platform must NOT determine this conclusively.

Final medical eligibility is determined by the donation center/medical professional.

## 10.1 Donation interval

Do not hard-code a medical donation interval into application code.

Create a configurable setting:

```text
MinimumDonationIntervalDays
```

The initial value must be confirmed by the project's qualified medical advisor and local blood-donation policy.

The system can use the setting to flag:

```text
RecentlyDonated
PotentiallyEligible
Unknown
```

It must not display:

> "You are medically eligible."

Instead use language such as:

> "Your recorded donation date suggests you may be due to donate again. Final eligibility is determined by the blood collection service."

---

# 11. Donor Availability

A donor should control whether they can currently be contacted.

## Available

The donor is willing to receive relevant blood requests.

## Unavailable

The donor does not want to receive requests.

## Recently Donated

Automatically suggested when a donation record indicates the donor recently donated.

## Unknown

Used when the profile has not been confirmed for a configured period.

## Profile freshness

Create a configurable setting:

```text
DonorProfileConfirmationDays
```

If a donor has not confirmed their profile within that period:

```text
AvailabilityStatus = Unknown
```

Do not delete the donor.

Ask them to confirm:

> "Are your blood group, location and availability still correct?"

---

# 12. Matching Engine

The matching engine is the heart of the system.

## 12.1 Matching process

When a blood request is created:

1. Validate request.
2. Determine compatible donor blood groups.
3. Find active donor profiles.
4. Filter by location where possible.
5. Exclude blocked/deactivated users.
6. Exclude donors marked unavailable.
7. Identify potentially eligible donors based on configurable rules.
8. Calculate approximate distance.
9. Calculate match score.
10. Rank donors.
11. Create matches.
12. Notify the highest-priority donors.

## 12.2 Match score

MVP scoring can be deterministic.

Example:

```text
Blood compatibility:
  Compatible = required
  Exact blood group = +30

Availability:
  Available = +30
  Unknown = 0
  Unavailable = excluded

Verification:
  Verified = +15
  Pending = +5
  Unverified = 0

Profile freshness:
  Confirmed recently = +10

Distance:
  0-3 km = +15
  3-10 km = +10
  10-25 km = +5
  >25 km = 0
```

Total:

```text
MatchScore =
  BloodScore
  + AvailabilityScore
  + VerificationScore
  + FreshnessScore
  + DistanceScore
```

The exact weights must be stored in configuration rather than scattered through code.

## 12.3 Important rule

Do not use the score as a medical score.

It is only a logistical ranking:

> "How useful is this donor for this request?"

---

# 13. Emergency Request Workflow

## Step 1: Requester opens

`Need Blood`

## Step 2: Enter information

Required:

- Blood group
- Units required
- Hospital/collection location
- Required date/time
- Contact phone
- Urgency

Optional:

- Patient name
- Relation to patient
- Additional notes

## Step 3: Confirmation

Show a concise summary.

Example:

```text
O+
2 units
Dhaka Medical College Hospital
Required within 3 hours
Urgency: Critical
```

## Step 4: Submit

Create request.

## Step 5: Matching

System searches donors.

## Step 6: Results

Example:

```text
24 potential donors found
8 currently available
3 nearby verified donors
```

## Step 7: Notifications

Notify suitable donors.

## Step 8: Donor response

Donor chooses:

```text
I Can Donate
Can't Donate
```

## Step 9: Request updates

Requester sees:

```text
3 donors contacted
1 accepted
2 pending
```

## Step 10: Fulfillment

Requester/admin marks the required units as fulfilled.

---

# 14. Donor Workflow

## Registration

```text
Create account
↓
Verify phone
↓
Enter blood group
↓
Enter location
↓
Enter last donation date
↓
Set availability
↓
Complete profile
```

## Donor dashboard

Show:

- Blood group
- Current availability
- Last donation date
- Donation count
- Profile verification
- Profile freshness
- Current matched requests
- Donation history

Primary CTA:

> **Update Availability**

---

# 15. Privacy Rules

This is critical.

## Public donor search must NOT expose

- Exact home address
- NID
- Email
- Full personal data
- Exact GPS coordinates
- Private medical information

Public result can show:

```text
Name
Blood group
District/area
Approximate distance
Availability
Verification status
```

Phone number should not be publicly searchable.

## Contact flow

Preferred MVP approach:

Requester selects:

> Contact Donor

The system creates a contact/connection event.

Depending on implementation, the donor's phone number can be revealed only after appropriate consent.

If direct phone display is used in MVP, add clear donor consent during registration.

---

# 16. Authentication

Support:

- Registration
- Login
- Logout
- Password reset
- Phone verification
- JWT access token
- Refresh token if required

Password requirements should be reasonable and configurable.

Never store plaintext passwords.

Use secure password hashing.

---

# 17. Authorization

Roles:

```text
Donor
Requester
Volunteer
Admin
```

Example permissions:

| Feature | Donor | Requester | Volunteer | Admin |
|---|---:|---:|---:|---:|
| Manage own profile | Yes | Yes | Yes | Yes |
| Search donors | Yes | Yes | Yes | Yes |
| Create request | Yes | Yes | Yes | Yes |
| Respond as donor | Yes | Optional | Optional | Yes |
| Manage own requests | Limited | Yes | Yes | Yes |
| Verify donors | No | No | No | Yes |
| Manage users | No | No | No | Yes |
| Manage reports | No | No | No | Yes |
| System settings | No | No | No | Yes |

---

# 18. Frontend Pages

## Public

### `/`

Landing page.

Sections:

- Hero
- Need blood CTA
- Become donor CTA
- Search blood CTA
- How it works
- Emergency impact
- Trust/verification explanation
- Footer

### `/find-blood`

Blood donor search.

Filters:

- Blood group
- Division
- District
- Upazila
- Area
- Availability

### `/request-blood`

Emergency request form.

### `/login`

Login.

### `/register`

Registration.

### `/verify-phone`

Phone verification.

### `/about`

Mission and platform information.

### `/privacy`

Privacy policy.

### `/terms`

Terms.

---

# 19. Donor Dashboard

Route:

`/donor/dashboard`

Show:

- Profile completion
- Blood group
- Availability
- Last donation
- Verification status
- Active matches
- Recent notifications

## Donor profile

`/donor/profile`

Allow:

- Personal information
- Blood group
- Location
- Last donation
- Availability
- Contact preferences

## Donation history

`/donor/donations`

Show:

- Date
- Location
- Related request
- Status

## Matched requests

`/donor/requests`

Show:

- Blood group
- Location
- Urgency
- Required time
- Distance
- Accept/decline actions

---

# 20. Requester Dashboard

Route:

`/requester/dashboard`

Show:

- Active requests
- Fulfilled requests
- Cancelled requests
- Number of donors matched
- Number accepted

## Request details

`/requester/requests/:id`

Show:

- Patient/request information
- Hospital
- Blood group
- Units
- Urgency
- Request status
- Matched donors
- Donor responses

Do not show sensitive donor information unnecessarily.

---

# 21. Admin Dashboard

Route:

`/admin`

Dashboard cards:

- Total donors
- Available donors
- Verified donors
- Open blood requests
- Critical requests
- Requests fulfilled
- Active users

Admin sections:

```text
Users
Donors
Blood Requests
Reports
Verification
Locations
Settings
Audit Logs
```

---

# 22. Admin User Management

Admin can:

- Search users
- Filter by role
- Activate/deactivate account
- Block account
- View profile
- Review reports
- Verify profile
- Reset verification status

Never allow an admin to view sensitive information unless required for their role.

All sensitive administrative access should be logged.

---

# 23. Blood Request Management

Admin can:

- View requests
- Filter by status
- Filter by urgency
- View request details
- Cancel fraudulent requests
- Mark request fulfilled
- Mark request expired
- Review reports
- View matching information

---

# 24. Reporting

Users can report:

- Fake blood request
- Fake donor
- Abuse
- Spam
- Incorrect blood information
- Harassment
- Other safety issue

Admin can:

- Review report
- Add resolution
- Suspend user
- Close report

---

# 25. Notification System

Create an abstraction:

```text
INotificationService
```

MVP implementation:

- In-app notifications

Future implementations:

```text
SMSNotificationService
EmailNotificationService
PushNotificationService
```

Notification examples:

### Donor

> Urgent O+ blood request near your area.

### Requester

> A donor has accepted your request.

### Donor

> Your donor profile needs confirmation.

### Requester

> Your blood request has been fulfilled.

---

# 26. Search and Filtering

Search endpoint should support:

```text
bloodGroup
divisionId
districtId
upazilaId
area
availability
verificationStatus
latitude
longitude
radiusKm
```

Do not require all fields.

Examples:

```text
GET /api/donors?bloodGroup=O%2B&districtId=...
```

Nearby search:

```text
GET /api/donors/nearby?bloodGroup=O%2B&latitude=...&longitude=...&radiusKm=10
```

The backend must enforce privacy and authorization rules.

---

# 27. API Design

Use REST conventions.

## Authentication

```text
POST /api/auth/register
POST /api/auth/login
POST /api/auth/verify-phone
POST /api/auth/refresh
POST /api/auth/forgot-password
POST /api/auth/reset-password
```

## Donors

```text
GET    /api/donors
GET    /api/donors/{id}
GET    /api/donors/me
PUT    /api/donors/me
PATCH  /api/donors/me/availability
GET    /api/donors/nearby
```

## Blood requests

```text
POST   /api/blood-requests
GET    /api/blood-requests
GET    /api/blood-requests/{id}
PUT    /api/blood-requests/{id}
POST   /api/blood-requests/{id}/cancel
POST   /api/blood-requests/{id}/fulfill
```

## Matches

```text
GET    /api/blood-requests/{id}/matches
POST   /api/matches/{id}/accept
POST   /api/matches/{id}/decline
```

## Donations

```text
GET    /api/donations/me
POST   /api/donations
PUT    /api/donations/{id}
```

## Notifications

```text
GET    /api/notifications
POST   /api/notifications/{id}/read
POST   /api/notifications/read-all
```

## Reports

```text
POST   /api/reports
GET    /api/admin/reports
PUT    /api/admin/reports/{id}
```

## Admin

```text
GET    /api/admin/dashboard
GET    /api/admin/users
PUT    /api/admin/users/{id}/status
POST   /api/admin/users/{id}/verify
```

Exact endpoint design can be adjusted to the chosen ASP.NET Core conventions.

---

# 28. Database Requirements

Use:

- Primary keys as UUIDs or another consistent globally unique strategy
- Foreign keys
- Unique constraints
- Indexes
- CreatedAt/UpdatedAt fields
- Soft deletion where appropriate
- Audit records for important actions

Important indexes:

```text
DonorProfile.BloodGroup
DonorProfile.DistrictId
DonorProfile.UpazilaId
DonorProfile.AvailabilityStatus
DonorProfile.VerificationStatus
DonorProfile.LastDonationDate
BloodRequest.Status
BloodRequest.Urgency
BloodRequest.BloodGroup
BloodRequest.DistrictId
BloodRequest.CreatedAt
BloodRequest.RequiredBy
BloodRequestMatch.BloodRequestId
BloodRequestMatch.DonorId
```

If geographic queries are implemented at database level, use an appropriate spatial/geographic strategy rather than calculating all distances in application memory.

---

# 29. Bangladesh Location Data

The platform must support Bangladesh's administrative hierarchy.

Initial data should include:

- Divisions
- Districts
- Upazilas

Do not manually duplicate location names across donor records.

Use reference tables:

```text
Divisions
Districts
Upazilas
```

Relationships:

```text
Division 1 → many Districts
District 1 → many Upazilas
```

Area can remain free text in MVP.

The seed data must be stored in a maintainable migration/seed mechanism.

---

# 30. Validation

## Donor registration

Validate:

- Name required
- Valid phone number
- Phone uniqueness
- Valid blood group
- Valid location
- Last donation date cannot be in the future
- Required consent accepted

## Blood request

Validate:

- Blood group required
- Units > 0
- Contact phone required
- Location required
- Required time valid
- Urgency required

Prevent impossible values.

---

# 31. Anti-Abuse and Safety

MVP must include basic protections.

## Rate limiting

Apply rate limits to:

- Login
- Registration
- OTP verification
- Blood request creation
- Search APIs where necessary
- Report submission

## Request spam

Limit the number of active requests a normal user can create.

Example configuration:

```text
MaxActiveRequestsPerUser
```

## Donor contact abuse

Do not allow unlimited repeated contact attempts.

Add:

```text
ContactCooldown
```

## Blocking

Users can block/report other users.

## Admin moderation

Admins can suspend accounts.

---

# 32. Privacy and Consent

During donor registration, clearly explain:

- Why the data is collected
- How donor data is used
- Who can see which information
- How donor contact works
- How to change availability
- How to deactivate the account

Require explicit consent for:

- Joining the donor network
- Receiving blood-request notifications
- Sharing contact information through the platform

Do not collect unnecessary personal data.

Do not store NID information in MVP.

---

# 33. UX Requirements

The interface should be simple and calm.

## Primary homepage CTAs

Two large actions:

```text
🩸 I NEED BLOOD
❤️ I WANT TO DONATE
```

Optional:

```text
Find a Donor
```

## Emergency request

Keep the form short.

Do not force the user to fill unnecessary fields before submitting.

## Donor search

Show:

```text
Blood Group
Area
Availability
Distance
Verification
```

Use clear badges.

Example:

```text
B+
🟢 Available
✓ Verified
3.2 km away
```

---

# 34. Responsive Design

The website must work on:

- Android phones
- iPhones
- Tablets
- Laptops
- Desktop

Primary design target:

```text
360px+ mobile width
```

Do not design desktop first and simply shrink it.

Design mobile-first.

---

# 35. Accessibility

Support:

- Keyboard navigation
- Proper labels
- Sufficient contrast
- Focus states
- Semantic HTML
- Screen-reader-friendly controls
- Error messages associated with fields
- No color-only status indication

For example:

Do not show only a green dot.

Show:

```text
🟢 Available
```

---

# 36. Bangla and English

MVP can launch with English-first UI if necessary, but the architecture should support localization from the beginning.

Use translation keys rather than hard-coded UI text.

Example:

```text
home.needBlood
home.becomeDonor
donor.available
donor.unavailable
request.urgent
```

Future languages:

```text
English
বাংলা
```

Because the target audience is Bangladesh, Bangla should be added before a broad public launch if resources allow.

User-generated data such as names and addresses should support Unicode.

---

# 37. SEO

Public pages should be SEO-friendly.

Potential pages:

```text
/find-blood
/blood-donors/dhaka
/blood-donors/chattogram
/blood-donors/rajshahi
```

However, do not expose individual donor personal information through search-engine-indexable pages.

Public SEO content should be informational and location/category based, not personal-data based.

---

# 38. Performance

Goals for MVP:

- Fast initial load on mobile networks
- Paginated donor search
- Paginated admin lists
- Server-side filtering
- Database indexes
- Avoid N+1 database queries
- Lazy-load heavy frontend modules
- Cache static/reference data where appropriate

Do not load thousands of donors into the browser at once.

---

# 39. Error Handling

API must return consistent errors.

Recommended structure:

```json
{
  "success": false,
  "message": "Unable to create blood request.",
  "errors": [
    {
      "field": "bloodGroup",
      "message": "Blood group is required."
    }
  ],
  "traceId": "..."
}
```

Frontend must show human-readable messages.

Never expose stack traces or database errors to users.

---

# 40. Logging

Use structured logging.

Log:

- Application errors
- Authentication events
- Important domain events
- Admin actions
- Integration failures

Never log:

- Passwords
- OTP values
- Sensitive personal information unnecessarily
- Authentication tokens

---

# 41. Configuration

Use environment/configuration values for:

```text
Database connection
JWT settings
OTP provider
SMS provider
Email provider
Map provider
Donation interval
Profile confirmation interval
Match score weights
Rate limits
Notification settings
```

Never commit secrets to source control.

Use environment variables or secure secret storage.

---

# 42. Testing Requirements

## Unit tests

Test:

- Blood compatibility
- Donation-date rules
- Match scoring
- Request validation
- Availability logic
- Authorization rules

## Integration tests

Test:

- Registration
- Login
- Donor creation
- Blood request creation
- Matching
- Donor acceptance
- Request fulfillment

## Frontend tests

Test:

- Registration form
- Blood search
- Emergency request
- Donor availability
- Request response

## End-to-end test

At minimum:

```text
Register donor
→ verify
→ create blood request
→ match donor
→ donor accepts
→ requester sees acceptance
→ request fulfilled
```

This flow must work before MVP launch.

---

# 43. Seed Data

Development environment should include:

- Bangladesh divisions
- Districts
- Upazilas
- Sample donor accounts
- Sample requester
- Sample blood requests
- Admin account

Development sample data must be clearly marked as fake.

Do not use real people's phone numbers.

---

# 44. Admin Seed Account

Development environment may have:

```text
admin@example.local
```

with a development-only password configured through environment variables.

Do not hard-code production credentials.

Production admin accounts must be created through a secure deployment process.

---

# 45. Deployment

Recommended initial architecture:

```text
                    Internet
                       │
                       ↓
                 Reverse Proxy
                       │
             ┌─────────┴─────────┐
             ↓                   ↓
        Angular App         ASP.NET API
                                  │
                                  ↓
                             PostgreSQL
```

Optional later:

```text
                    Redis
                      │
                      ↓
              Caching / Rate Limit
```

Deployment should support:

- HTTPS
- Database backups
- Environment-specific configuration
- Error monitoring
- Application logging
- Health checks

---

# 46. API Documentation

Use OpenAPI/Swagger.

Every endpoint should document:

- Purpose
- Authentication
- Parameters
- Request body
- Response
- Validation errors
- Authorization requirements

---

# 47. Health Checks

Provide:

```text
GET /health
GET /health/ready
```

Health checks should verify:

- API is running
- Database connection
- Required dependencies where appropriate

Do not expose sensitive infrastructure details.

---

# 48. Core User Stories

## US-001: Register as donor

As a person willing to donate blood, I want to register my blood group and location so that people can find me when blood is needed.

Acceptance criteria:

- User can register.
- Phone verification is required.
- Blood group is required.
- Location is required.
- Last donation date is captured.
- Consent is captured.
- Donor profile is created.

## US-002: Update availability

As a donor, I want to mark myself available or unavailable so that requests reach me only when appropriate.

Acceptance criteria:

- Donor can change availability.
- Current status is visible.
- Change is persisted.
- Relevant notifications respect the status.

## US-003: Search donors

As a requester, I want to search donors by blood group and location.

Acceptance criteria:

- Blood group can be selected.
- Location can be filtered.
- Results are paginated.
- Exact donor address is hidden.
- Availability is shown.
- Verification status is shown.

## US-004: Create blood request

As a requester, I want to create an emergency blood request.

Acceptance criteria:

- Required fields are validated.
- Request is stored.
- Request receives a unique ID.
- Matching process starts after creation.

## US-005: Match donors

As a requester, I want the system to find suitable nearby donors.

Acceptance criteria:

- Compatible blood groups are considered.
- Unavailable donors are excluded.
- Blocked users are excluded.
- Match score is calculated.
- Distance is calculated when location data is available.
- Results are ranked.

## US-006: Respond to request

As a donor, I want to accept or decline a blood request.

Acceptance criteria:

- Donor sees request information.
- Donor can accept.
- Donor can decline.
- Requester sees the response.
- Duplicate responses are prevented.

## US-007: Fulfill request

As a requester/admin, I want to mark a blood request fulfilled.

Acceptance criteria:

- Units fulfilled can be recorded.
- Request changes to PartiallyFulfilled or Fulfilled.
- Relevant users are notified.

## US-008: Verify donor

As an admin, I want to verify donor profiles.

Acceptance criteria:

- Admin can review donor.
- Admin can mark verified/rejected.
- Action is logged.
- Verification status is visible.

## US-009: Report abuse

As a user, I want to report suspicious behavior.

Acceptance criteria:

- User can submit report.
- Admin can review it.
- Admin can resolve it.
- Resolution is stored.

---

# 49. MVP Success Metrics

Track:

## Acquisition

- Registered donors
- Verified donors
- Active donors

## Availability

- Percentage of donors currently marked Available
- Percentage of donor profiles recently confirmed

## Emergency effectiveness

- Blood requests created
- Requests receiving at least one response
- Requests fulfilled
- Average time to first donor acceptance
- Average number of suitable matches per request

## Quality

- Fake/spam request rate
- Report rate
- Donor response rate

The most important MVP metric should be:

> **Median time from blood request creation to first suitable donor acceptance.**

The goal should be defined after collecting baseline data.

---

# 50. Future Roadmap

## Phase 2

- Android app
- Push notifications
- SMS notifications
- Better location matching
- Donor availability reminders
- Donation reminders
- Improved verification
- Volunteer accounts

## Phase 3

- Hospital accounts
- Blood bank integration
- Organization/community pages
- University blood communities
- Emergency broadcast
- Advanced analytics
- Public impact dashboard

## Phase 4

- Native or cross-platform mobile app expansion
- Real-time communication
- Better geographic matching
- Automated donor reactivation
- National organization partnerships

---

# 51. Future Mobile App Strategy

The mobile app should use the same backend APIs.

Architecture:

```text
                    ASP.NET Core API
                           │
             ┌─────────────┴─────────────┐
             ↓                           ↓
       Angular Website             Mobile App
                                      │
                                  Push alerts
```

Do not duplicate business logic between web and mobile.

The mobile app should focus on:

- Donor availability
- Emergency notifications
- Nearby requests
- Accept/decline
- Donation history
- Profile management

---

# 52. Future Differentiation

The long-term product should differentiate itself from static donor directories through:

1. **Real-time availability**
2. **Profile freshness**
3. **Nearby donor matching**
4. **Emergency notifications**
5. **Verification**
6. **Response tracking**
7. **Hospital/organization integration**
8. **Local community blood networks**
9. **Reliable request lifecycle**
10. **Privacy-first donor contact**

The product should measure success by how quickly it connects a real request with a suitable willing donor, not by the number of registered accounts alone.

---

# 53. Important Product Restrictions

The application must never:

- Sell blood
- Encourage unsafe donation
- Diagnose users
- Guarantee donor medical eligibility
- Guarantee transfusion compatibility
- Replace medical professionals
- Publish exact donor addresses
- Publish donor NID information
- Publish private donor information without consent
- Claim a blood request is medically valid without appropriate verification

Emergency pages should include a concise disclaimer:

> "This platform helps connect blood donors and recipients. Donor eligibility, blood compatibility, testing and transfusion decisions must be confirmed by qualified medical professionals or the relevant blood collection service."

---

# 54. Development Order

AI coding agents should implement in this order.

## Phase A: Foundation

1. Create repository structure.
2. Create ASP.NET Core solution.
3. Create Clean Architecture projects.
4. Configure PostgreSQL.
5. Configure EF Core.
6. Add migrations.
7. Configure Angular project.
8. Configure environment settings.
9. Add Swagger.
10. Add global error handling.
11. Add logging.
12. Add health checks.

## Phase B: Identity

1. User entity.
2. Authentication.
3. JWT.
4. Roles.
5. Registration.
6. Login.
7. Phone verification abstraction.
8. Authorization.

## Phase C: Donors

1. DonorProfile.
2. Blood groups.
3. Location entities.
4. Bangladesh seed data.
5. Donor profile API.
6. Availability.
7. Donation records.
8. Verification status.

## Phase D: Blood Requests

1. BloodRequest entity.
2. Request API.
3. Requester UI.
4. Request status.
5. Validation.

## Phase E: Matching

1. Compatibility service.
2. Donor eligibility calculation.
3. Distance service.
4. Match score service.
5. Match creation.
6. Ranking.
7. Match API.

## Phase F: Notifications

1. Notification entity.
2. In-app notifications.
3. Notification UI.
4. Notification service abstraction.

## Phase G: Admin

1. Admin dashboard.
2. User management.
3. Donor verification.
4. Request management.
5. Reports.
6. Audit logs.

## Phase H: Security and quality

1. Rate limiting.
2. Privacy checks.
3. Authorization review.
4. Validation review.
5. Unit tests.
6. Integration tests.
7. End-to-end tests.
8. Performance review.

## Phase I: Deployment

1. Production configuration.
2. Database migration.
3. HTTPS.
4. Backup strategy.
5. Health checks.
6. Monitoring.
7. Error tracking.
8. Production smoke tests.

---

# 55. AI Coding Agent Instructions

The coding agent must follow these rules.

## Rule 1: Do not build everything at once

Implement one phase at a time.

After each phase:

- Compile
- Run tests
- Fix errors
- Review architecture
- Commit changes if Git is being used

## Rule 2: Do not invent requirements

If a requirement is ambiguous:

- Prefer the simplest safe interpretation.
- Do not introduce unnecessary features.
- Record assumptions in documentation.

## Rule 3: Keep business logic in backend

Angular should handle:

- Presentation
- Forms
- Client-side UX validation
- API communication
- State needed for UI

ASP.NET Core should handle:

- Authorization
- Blood compatibility
- Eligibility calculations
- Match scoring
- Request state transitions
- Privacy rules
- Security rules

## Rule 4: Never trust client input

Every important validation must happen server-side.

## Rule 5: Protect private data

Never return sensitive donor fields in public DTOs.

Use separate DTOs for:

```text
PublicDonorDto
DonorSelfDto
AdminDonorDto
```

Do not simply return database entities from API endpoints.

## Rule 6: Use migrations

All database schema changes must use EF Core migrations.

## Rule 7: Avoid hard-coded business rules

Use configuration for:

- Donation interval
- Profile freshness
- Match weights
- Radius
- Request limits

## Rule 8: Keep providers replaceable

SMS, email, maps and push notifications should be behind interfaces.

## Rule 9: Write tests for critical logic

Especially:

- Blood compatibility
- Match scoring
- Authorization
- Request state transitions
- Privacy

## Rule 10: Maintain documentation

Keep:

```text
README.md
docs/architecture.md
docs/api.md
docs/decisions/
```

Update documentation when architecture changes.

---

# 56. Definition of Done for MVP

MVP is considered complete only when all of the following work:

- [ ] User can register.
- [ ] User can verify phone.
- [ ] User can create donor profile.
- [ ] Donor can set blood group.
- [ ] Donor can set location.
- [ ] Donor can record last donation date.
- [ ] Donor can set availability.
- [ ] Donor can search for blood requests.
- [ ] Requester can create blood request.
- [ ] System validates request.
- [ ] System finds compatible donors.
- [ ] System ranks donors.
- [ ] Donor can accept/decline.
- [ ] Requester sees donor response.
- [ ] Request can be fulfilled.
- [ ] Admin can manage users.
- [ ] Admin can verify donors.
- [ ] Users can report abuse.
- [ ] Sensitive donor data is protected.
- [ ] Authentication is secure.
- [ ] Authorization is enforced server-side.
- [ ] Critical business logic has tests.
- [ ] End-to-end emergency flow passes.
- [ ] Application is responsive on mobile.
- [ ] Production deployment is possible.
- [ ] Database backup strategy exists.
- [ ] Privacy and terms pages exist.

---

# 57. Primary MVP User Journey

The most important journey in the entire product is:

```text
                     EMERGENCY
                         │
                         ↓
                 "I NEED BLOOD"
                         │
                         ↓
              Select blood group
                         │
                         ↓
             Enter hospital/location
                         │
                         ↓
               Enter required units
                         │
                         ↓
                   Set urgency
                         │
                         ↓
                  Submit request
                         │
                         ↓
                 Matching Engine
                         │
          ┌──────────────┼──────────────┐
          ↓              ↓              ↓
       Donor A         Donor B        Donor C
       1.5 km          2.8 km         5.2 km
       Available       Available      Unknown
          │              │
          ↓              ↓
       Notify         Notify
          │              │
          ↓              ↓
       Accept         Decline
          │
          ↓
    Requester notified
          │
          ↓
      Blood donated
          │
          ↓
      Request fulfilled
```

This flow should be treated as the highest-priority product requirement.

---

# 58. Final Product Goal

The MVP should not attempt to solve every blood-related problem in Bangladesh.

It should solve one problem exceptionally well:

> **When someone needs blood, help them find a suitable, currently available donor nearby as quickly and safely as possible.**

Everything else should support that goal.

The architecture must be ready for a future mobile app, hospital integration, SMS/push notifications, community networks and a larger national donor ecosystem without requiring a complete rewrite.
