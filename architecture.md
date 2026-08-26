# Architecture - Blood Network Bangladesh

## System Overview

```
                         Internet
                            │
                            ▼
                      Reverse Proxy (Nginx)
                            │
                ┌───────────┴───────────┐
                ▼                       ▼
         Angular SPA              ASP.NET Core API
         (Port 4200)              (Port 5000)
                                        │
                                        ▼
                                   PostgreSQL
                                   (Port 5432)
```

---

## Clean Architecture Layers

```
┌─────────────────────────────────────────────────────┐
│                   API Layer                          │
│  Controllers, Middleware, Filters, DI Config         │
│  Depends on: Application, Infrastructure             │
├─────────────────────────────────────────────────────┤
│                Application Layer                     │
│  Commands, Queries, DTOs, Validators, Services       │
│  Depends on: Domain only                            │
├─────────────────────────────────────────────────────┤
│                  Domain Layer                        │
│  Entities, Enums, Exceptions, Interfaces             │
│  Depends on: NOTHING (outermost inner circle)        │
├─────────────────────────────────────────────────────┤
│              Infrastructure Layer                    │
│  EF Core, PostgreSQL, Auth, SMS, Email, Maps         │
│  Depends on: Domain (implements interfaces)          │
└─────────────────────────────────────────────────────┘
```

**Dependency Rule:** Source code dependencies must point inward only. Domain has zero external dependencies.

---

## Project Structure

```
BloodNetworkBangladesh/
├── src/
│   ├── BloodNetwork.Api/                    # Entry point
│   │   ├── Controllers/                     # REST endpoints
│   │   │   ├── AuthController.cs
│   │   │   ├── DonorsController.cs
│   │   │   ├── BloodRequestsController.cs
│   │   │   ├── MatchesController.cs
│   │   │   ├── DonationsController.cs
│   │   │   ├── NotificationsController.cs
│   │   │   └── Admin/
│   │   │       ├── AdminUsersController.cs
│   │   │       ├── AdminReportsController.cs
│   │   │       └── AdminDashboardController.cs
│   │   ├── Middleware/                      # Exception handling, logging
│   │   ├── Filters/                         # Action filters
│   │   ├── Extensions/                      # DI registration
│   │   ├── appsettings.json
│   │   ├── appsettings.Development.json
│   │   └── Program.cs
│   │
│   ├── BloodNetwork.Application/            # Business logic
│   │   ├── Commands/
│   │   │   ├── Auth/
│   │   │   │   ├── RegisterUserCommand.cs
│   │   │   │   ├── LoginCommand.cs
│   │   │   │   └── VerifyPhoneCommand.cs
│   │   │   ├── Donors/
│   │   │   │   ├── CreateDonorProfileCommand.cs
│   │   │   │   ├── UpdateDonorProfileCommand.cs
│   │   │   │   └── UpdateAvailabilityCommand.cs
│   │   │   ├── BloodRequests/
│   │   │   │   ├── CreateBloodRequestCommand.cs
│   │   │   │   ├── UpdateBloodRequestCommand.cs
│   │   │   │   ├── CancelBloodRequestCommand.cs
│   │   │   │   └── FulfillBloodRequestCommand.cs
│   │   │   └── Matches/
│   │   │       ├── AcceptMatchCommand.cs
│   │   │       └── DeclineMatchCommand.cs
│   │   ├── Queries/
│   │   │   ├── Donors/
│   │   │   │   ├── GetDonorQuery.cs
│   │   │   │   ├── SearchDonorsQuery.cs
│   │   │   │   └── GetNearbyDonorsQuery.cs
│   │   │   ├── BloodRequests/
│   │   │   │   ├── GetBloodRequestQuery.cs
│   │   │   │   └── GetMyBloodRequestsQuery.cs
│   │   │   └── Admin/
│   │   │       ├── GetDashboardQuery.cs
│   │   │       ├── GetUsersQuery.cs
│   │   │       └── GetReportsQuery.cs
│   │   ├── DTOs/                            # Data transfer objects
│   │   │   ├── Auth/
│   │   │   ├── Donors/
│   │   │   ├── BloodRequests/
│   │   │   ├── Matches/
│   │   │   └── Admin/
│   │   ├── Validators/                      # FluentValidation
│   │   ├── Services/                        # Application services
│   │   │   ├── MatchingEngine.cs
│   │   │   ├── BloodCompatibilityService.cs
│   │   │   ├── DonorEligibilityService.cs
│   │   │   └── MatchScoreService.cs
│   │   ├── Interfaces/                      # External service contracts
│   │   │   ├── INotificationService.cs
│   │   │   ├── ISmsProvider.cs
│   │   │   ├── IMapService.cs
│   │   │   └── IPhoneVerificationService.cs
│   │   └── Common/
│   │       ├── Result.cs                    # Result<T> pattern
│   │       └── PagedResult.cs               # Pagination wrapper
│   │
│   ├── BloodNetwork.Domain/                 # Core domain
│   │   ├── Entities/
│   │   │   ├── User.cs
│   │   │   ├── DonorProfile.cs
│   │   │   ├── BloodRequest.cs
│   │   │   ├── BloodRequestMatch.cs
│   │   │   ├── DonationRecord.cs
│   │   │   ├── Notification.cs
│   │   │   ├── VerificationRecord.cs
│   │   │   ├── Report.cs
│   │   │   ├── AuditLog.cs
│   │   │   ├── Division.cs
│   │   │   ├── District.cs
│   │   │   └── Upazila.cs
│   │   ├── Enums/
│   │   │   ├── BloodGroup.cs
│   │   │   ├── UserRole.cs
│   │   │   ├── AvailabilityStatus.cs
│   │   │   ├── VerificationStatus.cs
│   │   │   ├── RequestStatus.cs
│   │   │   ├── Urgency.cs
│   │   │   ├── DonorResponse.cs
│   │   │   └── NotificationType.cs
│   │   ├── Exceptions/
│   │   │   ├── DomainException.cs
│   │   │   ├── NotFoundException.cs
│   │   │   └── ValidationException.cs
│   │   ├── Interfaces/
│   │   │   ├── IRepository.cs
│   │   │   └── IUnitOfWork.cs
│   │   └── Common/
│   │       └── BaseEntity.cs                # Id, CreatedAt, UpdatedAt
│   │
│   └── BloodNetwork.Infrastructure/         # External concerns
│       ├── Data/
│       │   ├── BloodNetworkDbContext.cs
│       │   ├── Configurations/              # IEntityTypeConfiguration
│       │   ├── Seeds/                       # Seed data
│       │   │   ├── BangladeshLocationSeed.cs
│       │   │   └── AdminSeed.cs
│       │   └── Interceptors/               # Audit, soft-delete interceptors
│       ├── Migrations/
│       ├── Authentication/
│       │   ├── JwtTokenService.cs
│       │   └── PasswordHasher.cs
│       ├── Services/
│       │   ├── NotificationService.cs       # In-app implementation
│       │   ├── SmsProvider.cs               # Stub/abstraction
│       │   └── MapService.cs                # Stub/abstraction
│       └── DependencyInjection.cs           # Infrastructure DI registration
│
├── frontend/
│   └── blood-network-web/                   # Angular project
│       ├── src/
│       │   ├── app/
│       │   │   ├── core/
│       │   │   │   ├── guards/
│       │   │   │   ├── interceptors/
│       │   │   │   ├── models/
│       │   │   │   └── services/
│       │   │   ├── features/
│       │   │   │   ├── auth/
│       │   │   │   ├── donor/
│       │   │   │   ├── request/
│       │   │   │   ├── admin/
│       │   │   │   └── shared/
│       │   │   ├── layout/
│       │   │   │   ├── header/
│       │   │   │   ├── footer/
│       │   │   │   └── sidebar/
│       │   │   └── shared/
│       │   │       ├── components/
│       │   │       ├── pipes/
│       │   │       └── directives/
│       │   ├── assets/
│       │   │   ├── i18n/                    # Translation files
│       │   │   └── images/
│       │   ├── environments/
│       │   └── styles/
│       ├── angular.json
│       └── package.json
│
├── tests/
│   ├── BloodNetwork.UnitTests/
│   │   ├── Domain/
│   │   ├── Application/
│   │   └── Infrastructure/
│   └── BloodNetwork.IntegrationTests/
│       ├── Auth/
│       ├── Donors/
│       ├── BloodRequests/
│       └── Matching/
│
└── docs/
    ├── architecture.md                      # This file
    ├── api.md                               # API documentation
    └── decisions/                           # ADRs
```

---

## Data Flow: Emergency Blood Request

```
1. Requester submits form
        │
        ▼
2. Angular → POST /api/blood-requests
        │
        ▼
3. BloodRequestsController validates via FluentValidation
        │
        ▼
4. CreateBloodRequestCommandHandler
   ├── Validates request (server-side)
   ├── Saves BloodRequest to DB
   ├── Triggers MatchingEngine
   │     ├── Gets compatible blood groups
   │     ├── Queries DonorProfiles (filtered)
   │     ├── Calculates distances
   │     ├── Calculates match scores
   │     ├── Ranks donors
   │     └── Creates BloodRequestMatch records
   └── Triggers NotificationService
         ├── Creates in-app notifications
         └── (Future: SMS, Push)
        │
        ▼
5. Response → Requester sees match summary
        │
        ▼
6. Donor receives notification → Accepts/Declines
        │
        ▼
7. Requester sees real-time updates → Fulfills request
```

---

## Authentication Flow

```
Register → Phone Verify → Login → JWT issued
                                       │
                    ┌──────────────────┤
                    ▼                  ▼
              Access Token      Refresh Token
              (15 min)          (7 days)
                    │
                    ▼
            Authorization Header
            Bearer {token}
                    │
                    ▼
            JWT Middleware validates
            Extracts roles, userId
                    │
                    ▼
            [Authorize] attributes
            enforce role access
```

---

## Privacy Model

```
Public API Response (anyone):
  ├── Name
  ├── Blood Group
  ├── District/Upazila (not exact address)
  ├── Approximate distance
  ├── Availability status
  └── Verification status

Owner API Response (self):
  ├── All public fields
  ├── Email
  ├── Phone number
  ├── Exact area
  ├── GPS coordinates
  ├── Donation history
  └── Match history

Admin API Response:
  ├── All owner fields
  ├── Account status
  ├── Verification records
  ├── Report history
  └── Audit trail
```

---

## Key Abstractions

| Interface | Purpose | MVP Implementation | Future |
|---|---|---|---|
| `INotificationService` | Send notifications | In-app only | SMS, Email, Push |
| `ISmsProvider` | Send SMS (OTP, alerts) | Stub/mock | Twilio, local provider |
| `IMapService` | Distance, geocoding | Haversine formula | Google Maps, OSM |
| `IPhoneVerificationService` | Phone OTP verify | Stub/mock | SMS gateway |
| `IRepository<T>` | Data access | EF Core | Dapper, Redis cache |
| `IUnitOfWork` | Transaction scope | EF Core DbContext | — |

---

## Matching Engine Architecture

```
MatchingEngine
  ├── BloodCompatibilityService
  │     └── GetCompatibleBloodGroups(BloodGroup) → List<BloodGroup>
  ├── DonorEligibilityService
  │     └── IsPotentiallyEligible(DonorProfile, settings) → bool
  ├── DistanceService (via IMapService)
  │     └── CalculateDistance(lat1, lon1, lat2, lon2) → double
  └── MatchScoreService
        └── CalculateScore(donor, request, distance, settings) → int
```

All weights and thresholds loaded from `IConfiguration`, not hard-coded.

---

## Deployment Architecture

```
Production:
  Nginx (reverse proxy, SSL termination)
    ├── /        → Angular SPA (static files)
    └── /api     → ASP.NET Core Kestrel
                        └── PostgreSQL (RDS or self-hosted)

Development:
  Angular dev server (4200) ←→ ASP.NET Core (5000) ←→ PostgreSQL (5432)
```
