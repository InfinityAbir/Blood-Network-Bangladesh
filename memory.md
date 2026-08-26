# Memory - Blood Network Bangladesh

This file captures key architectural decisions, conventions, and lessons learned throughout development.

---

## Architecture Decisions

| Decision | Choice | Rationale |
|---|---|---|
| Architecture pattern | Clean Architecture | PRD requirement; separates domain, application, infrastructure, API |
| CQRS | Commands/Queries separated in Application layer | Clarity for complex matching + request workflows |
| Primary keys | UUIDs | Globally unique, future-distributed-safe |
| Auth | JWT access + refresh tokens | Mobile-first, API-first architecture |
| ORM | Entity Framework Core | PRD recommendation, code-first migrations |
| Database | PostgreSQL | PRD primary recommendation |
| Frontend | Angular + Material | PRD recommendation, TypeScript consistency |
| Validation | FluentValidation in Application layer | Server-side enforcement, PRD requirement |
| Privacy DTOs | PublicDonorDto / DonorSelfDto / AdminDonorDto | PRD Rule 5: never expose sensitive data |

---

## Conventions

### Backend (ASP.NET Core)
- Namespace pattern: `BloodNetwork.{Layer}.{Feature}`
- Entity classes in `Domain/Entities/` — no navigation properties to infrastructure
- DTOs in `Application/DTOs/` — separate read/write DTOs where needed
- Validators in `Application/Validators/` — FluentValidation
- Controllers in `Api/Controllers/` — thin, delegate to Application services
- EF configurations in `Infrastructure/Data/` — IEntityTypeConfiguration
- Seed data in `Infrastructure/Data/Seeds/`
- All timestamps stored as UTC

### Frontend (Angular)
- Module structure: feature modules (auth, donor, request, admin)
- Services in `app/core/services/`
- Guards in `app/core/guards/`
- Interceptors in `app/core/interceptors/`
- Translation keys: `section.keyName` format (e.g., `home.needBlood`)
- Mobile-first CSS approach
- Reactive forms over template-driven forms

### Git
- Conventional commits: `feat:`, `fix:`, `chore:`, `docs:`, `refactor:`
- One phase per commit group

---

## Key Domain Rules

1. **Blood compatibility** is a logistical aid, NOT medical advice
2. **Match score** is a ranking tool, NOT a medical score
3. **Available** means willing to be contacted, NOT medically fit
4. **Donation interval** must be configurable, not hard-coded
5. **Profile freshness** drives `Unknown` availability status
6. Phone numbers are NOT publicly searchable
7. Exact donor coordinates are NOT publicly exposed
8. All sensitive admin access is audit-logged

---

## Configurable Settings

| Setting | Purpose | Initial Value |
|---|---|---|
| `MinimumDonationIntervalDays` | Time before donor may donate again | TBD (medical advisor) |
| `DonorProfileConfirmationDays` | Days before profile becomes Unknown | 90 (suggest) |
| `MaxActiveRequestsPerUser` | Anti-spam limit | 3 |
| `ContactCooldown` | Prevent donor contact abuse | 24 hours |
| Match score weights | Blood/Availability/Verification/Freshness/Distance | PRD §12.2 |
| Distance radius tiers | Scoring bands | 0-3, 3-10, 10-25, >25 km |

---

## Lessons Learned

### Phase A (2026-08-26)
1. **Solution format:** .NET 10 uses `.slnx` (XML-based) instead of `.sln`. Always check for `*.slnx` files.
2. **Swashbuckle 10.x:** The `Microsoft.OpenApi.Models` namespace is no longer available. Use `AddSwaggerGen()` without `OpenApiInfo` or use the built-in `AddOpenApi()`.
3. **Pattern matching order:** When using switch expressions with inheritance, put derived types before base types (e.g., `ValidationException` before `DomainException`).
4. **Infrastructure → Application reference:** Infrastructure needs to reference Application for service implementations (`INotificationService`, `IMapService`). This is a one-way dependency from Infrastructure to Application.
5. **Project references:** Clean Architecture requires careful reference management:
   - Application → Domain (only)
   - Infrastructure → Domain + Application (implements interfaces)
   - Api → Application + Infrastructure
6. **Entity configurations:** Using `IEntityTypeConfiguration<T>` with `ApplyConfigurationsFromAssembly` keeps configurations organized and auto-discovered.
7. **Enum storage:** Using `.HasConversion<string>()` for enums allows readable DB values while maintaining type safety in code.

### Angular (Phase A continued)
8. **Angular Material 21 palette names:** Use `mat.$violet-palette` and `mat.$red-palette` (not `$indigo-palette` which was removed in v21).
9. **Import paths:** When components are in `features/shared/landing/`, the path to `layout/` is `../../../layout/` (three levels up).
10. **Standalone components:** Angular 21 uses standalone components by default. No need for NgModules.
11. **Lazy loading:** Use `loadComponent: () => import(...).then(m => m.Component)` for lazy-loaded routes.
12. **Animations:** `@angular/animations` is deprecated in v22+. Use `animate.enter` and `animate.leave` for new projects.
13. **HttpClient:** Use `provideHttpClient(withInterceptors([fn]))` in app.config.ts for functional interceptors.

### Angular Conventions
- **Components:** Standalone, single-file (template + styles inline for small components)
- **Services:** providedIn `'root'` for singletons
- **Models:** In `core/models/` as separate `.ts` files per domain concept
- **Guards:** Functional (`CanActivateFn`) in `core/guards/`
- **Interceptors:** Functional (`HttpInterceptorFn`) in `core/interceptors/`
- **Layout:** Header/Footer in `layout/` (shared across all pages)
- **Features:** Lazy-loaded feature modules in `features/{feature}/`
