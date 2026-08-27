# Integration & Deployment Audit — Blood Network Bangladesh
**Date:** 2026-08-27 | **Mode:** READ-ONLY | **Scope:** `E:\Temp\Project\Blood Network Bangladesh`

> Each finding is `file:line` cross-referenced to **actual** file content on disk, not assumptions.

---

## 1. Dockerfile — `Dockerfile:1-26`

| Line | Issue | Severity | Detail |
|------|-------|----------|--------|
| `Dockerfile:1` | Base image `mcr.microsoft.com/dotnet/sdk:10.0` — correct for .NET 10 build | INFO | Matches spec. Tag `10.0` is floating major (patch not pinned). Consider pinning to `10.0.x-bookworm-slim` for reproducibility, but spec explicitly requires `10.0` → PASS. |
| `Dockerfile:13` | Runtime `mcr.microsoft.com/dotnet/aspnet:10.0` — correct | INFO | PASS. |
| `Dockerfile:14` | `libgssapi-krb5-2` install present | INFO | PASS. `apt-get update && apt-get install -y --no-install-recommends libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*` correct for Npgsql Kerberos. |
| `Dockerfile:24-25` | Non-root `app` user via `id -u app || useradd -r -s /bin/false app` + `USER app` | INFO | PASS per check. Idempotency guard `id -u app > /dev/null 2>&1 || ...` is correct. Minor: `aspnet:10.0` already ships user `app` (uid 1654) so branch is no-op in practice — good. |
| `Dockerfile:18-19,23` | Port `8080`, `ASPNETCORE_URLS=http://+:8080`, `EXPOSE 8080` | INFO | PASS. Consistent with `src/BloodNetwork.Api/Program.cs:28` `ListenAnyIP(8080)`. |
| `Dockerfile:20-21` | `DOTNET_ROLL_FORWARD=LatestMajor` + `DOTNET_HOSTBUILDER__RELOADCONFIG=false` | INFO | PASS. Matches `Program.cs:32-33` `reloadOnChange: false`. Disables file-watcher reload in immutable container — intended. |
| `Dockerfile:11` | Publish output `/app/publish` | INFO | PASS. `dotnet publish ... -o /app/publish --no-restore` then `COPY --from=build /app/publish .` with `WORKDIR /app` → final path `/app/BloodNetwork.Api.dll` and `ENTRYPOINT ["dotnet","BloodNetwork.Api.dll"]` correct. |
| `Dockerfile:4-7` | Layer caching: `.csproj` copy before `dotnet restore` | INFO | PASS — optimal layer cache. |

**Verdict:** PASS — no blocking issue.

---

## 2. .dockerignore — `.dockerignore:1-15`

| Line | Issue | Severity | Detail |
|------|-------|----------|--------|
| `.dockerignore:4-7` | Minimal set `**/bin`, `**/obj`, `**/node_modules` present | INFO | PASS. |
| `.dockerignore:7` | `**/dist` ignored | LOW | If Dockerfile ever needs to `COPY frontend/.../dist` (e.g. serving SPA from API), `dist` would be absent. Currently Dockerfile only copies `src/` so harmless, but if you switch to single-container deploy it will break. Keep or document. |
| `.dockerignore:8-12` | `plan.md`, `memory.md`, `status.md`, `feedback.md`, `architecture.md` ignored | INFO | Harmless, reduces context. Spec said “is it minimal (bin, obj, node_modules)?” → file is *not* minimal but that is fine. Not a bug. |
| `.dockerignore:14` | `**/appsettings.Production.json` ignored | LOW | Prevents accidental bake-in of secrets — good practice — but means any checked-in `appsettings.Production.json` won’t be in image. Document that prod config must come via env vars / Render dashboard (current design does). |
| — | Missing `**/.gitignore` entry not needed | INFO | — |

**Verdict:** PASS (not minimal, but correctly extended).

---

## 3. render.yaml — `render.yaml:1-5`

| Line | Issue | Severity | Detail |
|------|-------|----------|--------|
| `render.yaml:1-5` | Only DB defined (`databases: - name: blood-network-db`) — API + frontend are manual on Render | INFO | PASS per spec. “No blueprint needed” is correct: `render.yaml` is intentionally DB-only. Render Blueprint would need `services:` for API + `staticSites:` for frontend if you wanted infra-as-code; manual creation per `DEPLOY.md` is alternative. No inconsistency. |
| — | Postgres major version `16` | INFO | Current stable. OK. |

**Verdict:** PASS — matches “DB-only” design. If you want one-click deploys, add `services:` section; otherwise keep manual.

---

## 4. SPA Fallback — `static.json`, `frontend/blood-network-web/static.json`, `public/404.html`, `angular.json`, `dist/`

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `static.json:1-8` (root) | Duplicate of `frontend/.../static.json:1-8` — identical `{"routes":[{"src":"/(.*)","dest":"/index.html"}]}` | INFO | Root `static.json` is **dead code** unless Render publish root is repo root (it isn’t). Publish dir is `frontend/.../dist/.../browser` per `DEPLOY.md:41` and `package.json`. Only `frontend/.../static.json` matters. Remove root copy to avoid confusion. |
| `frontend/blood-network-web/static.json:1-8` | Present | INFO | PASS. |
| `frontend/blood-network-web/angular.json:48-58` | Assets `{"glob":"**/*","input":"public"}` + `{"glob":"static.json","input":".","output":"/"}` | INFO | PASS — `public/404.html`, `public/env.js`, `public/favicon.ico` **and** `static.json` will be emitted to `dist/blood-network-web/browser/`. Verified on disk: `dist/.../browser/static.json`, `.../404.html`, `.../env.js`, `.../index.html` all exist. |
| `frontend/blood-network-web/public/404.html:5-8` | SPA fallback via `window.location.replace('/#' + path)` — **hash redirect** | HIGH | Angular defaults to `PathLocationStrategy` (`<base href="/">` + `provideRouter(routes)` in `app.config.ts:12` with no `withHashLocation`). Hash fallback produces `/# /some/path` not `/some/path`. On Render Static Site with *rewrite* `/* -> /index.html` (DEPLOY.md:43-45) the correct behavior is to serve `index.html` directly; `404.html` hash trick is for GitHub Pages. It will **break deep links** and create double-load + SEO issue. Keep `static.json` OR Render rewrite rule, but fix `404.html` to `<meta http-equiv="refresh" content="0;url=/index.html">` or simply delete it if using rewrites. Currently both mechanisms compete. |
| `frontend/blood-network-web/src/index.html:16` | `<script src="env.js"></script>` before `<app-root>` | INFO | PASS — runtime env injection loads before Angular bootstraps. Correct placement at `index.html:16`. |
| — | Render `static.json` semantics | MEDIUM | `static.json` `routes` syntax is for **Render** “legacy” static site routing but oficial Render docs now use `_redirects` or dashboard Rewrite Rules. File will be served as static asset at `/static.json` but Render may **ignore** it unless you use “Publish directory contains static.json” feature flag. `DEPLOY.md:43-45` correctly tells operator to add dashboard rewrite `/* -> /index.html`. So operationally PASS if operator follows DEPLOY.md, but repo gives false sense of self-contained fallback. Document dependency. |

**Verdict:** Assets will be in `dist/browser` — PASS — but `404.html` hash strategy is **wrong** for `PathLocationStrategy` and should be fixed.

---

## 5. Program.cs vs Dockerfile Port Binding

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Api/Program.cs:20-29` | `UseKestrel(options => options.ListenAnyIP(8080))` | INFO | PASS. Matches `Dockerfile:18` `ASPNETCORE_URLS=http://+:8080` and `EXPOSE 8080`. No conflict: Kestrel explicit listen takes precedence; env var redundant but consistent. |
| `Program.cs:31-34` | `AddJsonFile(..., reloadOnChange:false)` matches `DOTNET_HOSTBUILDER__RELOADCONFIG=false` | INFO | PASS. Prevents physical file polling in container. |

---

## 6. CORS

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Api/appsettings.json:47` | `AllowedOrigins": ["http://localhost:4200", "https://blood-network-bangladesh-frontend.onrender.com"]` | INFO | PASS — exact origins, no trailing slash (correct; trailing slash would fail `WithOrigins` matching). Includes both dev and prod frontend. |
| `src/BloodNetwork.Api/Program.cs:100-110` | `WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials()` | INFO | PASS — `AllowCredentials` **required** for SignalR `accessTokenFactory` + cookies. Without it browsers would block credentialed WS. Present. |
| `src/BloodNetwork.Api/Program.cs:260-265` | Middleware order: `UseForwardedHeaders` → `UseHttpsRedirection` → `UseCors` → `UseRateLimiter` → `UseAuthentication` → `UseAuthorization` | LOW | `UseCors` after `UseHttpsRedirection` but before `UseAuthentication` is conventional. However `UseCors` should ideally be **before** `UseHttpsRedirection` when behind Render proxy, else redirect may strip CORS headers. No bug but consider `UseCors` earlier. Also `UseForwardedHeaders` before `UseHttpsRedirection` is correct for Render’s `X-Forwarded-Proto`. |
| `DEPLOY.md:58-60` | Says set `AllowedOrigins = ["https://blood-network-frontend.onrender.com"]` — **missing `-bangladesh-`** | HIGH | Operator following `DEPLOY.md` will set `https://blood-network-frontend.onrender.com` which **does NOT match** actual frontend `https://blood-network-bangladesh-frontend.onrender.com` (appsettings.json) nor `public/env.js` API domain. CORS will fail with `No 'Access-Control-Allow-Origin'` in prod. Fix doc to `https://blood-network-bangladesh-frontend.onrender.com`. Also doc shows JSON array syntax; Render env var UI expects single string — real env var must be `AllowedOrigins__0` / `AllowedOrigins__1` or JSON array parsed via `Get<string[]>()` — both work if you paste `["https://..."]` as one env var, but `Program.cs:104` `GetSection("AllowedOrigins").Get<string[]>()` expects either `AllowedOrigins__0` style or JSON — document both. |
| — | `AllowCredentials` + wildcard origin not used | INFO | Correct; CORS correctly forbids wildcard when credentials true. |

---

## 7. JWT

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Api/appsettings.json:5-11` | `Secret: "YOUR_JWT_SECRET_KEY_MINIMUM_32_CHARACTERS"` length 41 | INFO | PASS placeholder >=32. Production must override via `Jwt__Secret` (Render env var) — `Program.cs:64` reads `Jwt:Secret` with `!` null-forgiving. If not set, `Encoding.UTF8.GetBytes(null!)` throws `ArgumentNullException` at startup → crash loop. Consider `ArgumentException` guard. |
| `appsettings.json:7-8` + `JwtTokenService.cs:22-24` | `Issuer`/`Audience` both `BloodNetworkBangladesh` — match between token generation and validation | INFO | PASS. `Program.cs:73-75` `ValidIssuer`/`ValidAudience` read same keys. |
| `appsettings.json:9` vs `DEPLOY.md:26` | `ExpirationInMinutes: 15` in JSON but `DEPLOY.md` says set `Jwt__ExpirationInMinutes = 60` | MEDIUM | Desync. `JwtTokenService.cs:25` defaults to `int.Parse(... ?? "15")`. If operator sets 60 per doc, prod tokens live 60 min, but local/dev 15 min. No bug, but doc and committed config diverge. Align: keep 15 min per spec (more secure) and fix `DEPLOY.md:26`. |
| `appsettings.json:10` + `JwtTokenService.cs:26` | `RefreshExpirationInDays: 7` → `AuthService.cs:237` `AddDays(7)` hard-coded | INFO | Consistent. But note `AuthService.CreateRefreshTokenAsync:237` hard-codes `AddDays(7)` instead of reading config `Jwt:RefreshExpirationInDays` — if you ever change appsettings to e.g. 30 (dev appsettings.Development.json:8 has 30), refresh tokens still 7 days. Should inject `IConfiguration` or `JwtOptions`. Low risk while value is 7 everywhere. |
| `Program.cs:77` + `JwtTokenService.cs:79` | `ClockSkew = TimeSpan.Zero` in both validation paths | INFO | PASS — spec requires zero (strict). Good for 15-min window. |
| `Program.cs:80-92` | `OnMessageReceived` extracts `access_token` query for `path.StartsWithSegments("/hubs/notifications")` | INFO | PASS — required for SignalR WebSocket (headers not available). Correct path check. |
| `src/BloodNetwork.Infrastructure/Authentication/JwtTokenService.cs:29-40` | `GenerateAccessToken` uses claims `sub` (userId), `jti`, `ClaimTypes.Role`, `ClaimTypes.MobilePhone` — **no `NameIdentifier`** | MEDIUM | `NotificationHub.cs:13,22` `FindFirst(ClaimTypes.NameIdentifier)` will always be **null** when using access token generated by `JwtTokenService`. Hub falls back? No fallback — `OnConnectedAsync:13` only checks `NameIdentifier`. So SignalR grouping `user_{userId}` will **never be added** — notifications silently fail over WS. In contrast `AuthController.cs:77-78` and `DonorsController.cs:24` do fallback `?? FindFirst("sub")` — correct. Hub must add same fallback: `FindFirst(ClaimTypes.NameIdentifier) ?? FindFirst("sub") ?? FindFirst(JwtRegisteredClaimNames.Sub)`. Current code is broken for real JWT. |
| `JwtTokenService.cs:61-89` | `ValidateRefreshToken` treats **opaque base64** refresh token as JWT (`handler.ValidateToken`) | HIGH | `GenerateRefreshToken:53-59` returns `Convert.ToBase64String(64 random bytes)` — **not a JWT**. `ValidateRefreshToken` will **always return false** (throws, caught, returns false). Fortunately `AuthService.RefreshTokenAsync:115-164` **does not call** `ValidateRefreshToken` — it does DB lookup + `ExpiresAt` + `IsRevoked` checks. So dead code, but misleading and if anyone calls it (future), it’s a security bug. Delete or reimplement to check DB/expiry only. |
| `frontend/src/app/core/interceptors/auth.interceptor.ts:8-69` | No client-side JWT decode / expiry check; relies on 401 | INFO | PASS per spec: “any desync between API and frontend token decode?” — frontend never decodes, it stores opaque `access_token` + `user` object via `AuthService.storeAuth`. Desync N/A. Trade-off: token may expire on client without proactive refresh; mitigated by `catchError 401 → refreshToken → retry`. Acceptable. |
| `frontend/src/app/core/services/auth.service.ts:55-57` | `refreshToken(refreshToken: string)` posts `{refreshToken}` — case matches `AuthController.RefreshTokenRequest`? | INFO | Check `AuthService.cs`? Backend `RefreshTokenRequest` not shown but assumed property `RefreshToken` PascalCase — System.Text.Json is case-insensitive by default (`PropertyNameCaseInsensitive=true` in ASP.NET), so OK. But verify JSON naming: frontend sends `refreshToken` (camel) vs backend expects `RefreshToken` (Pascal) — works due to case-insensitivity, but explicit `[JsonPropertyName]` would be safer. |
| `src/BloodNetwork.Api/appsettings.Development.json:5-8` | Dev `Secret` = `YOUR_DEV_JWT_SECRET_KEY_NOT_FOR_PRODUCTION` (35 chars, still >=32 but truncated?), `ExpirationInMinutes: 60`, `RefreshExpirationInDays: 30` | MEDIUM | Dev diverges from prod (60m/30d vs 15m/7d). Could mask expiry bugs. Consider aligning dev to prod values unless intentional. Also dev secret length 35 chars but still passes `Encoding.UTF8.GetBytes`. |

---

## 8. Groq Integration

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Application/Configuration/GroqOptions.cs:5` | `SectionName = "GroqApi"` | INFO | PASS — matches `appsettings.json:49` `"GroqApi"` **exact case**. |
| `src/BloodNetwork.Infrastructure/Services/GroqChatService.cs:53` | Log warns `Set GroqApi__ApiKey environment variable` | INFO | PASS — env var name `GroqApi__ApiKey` (double underscore) is correct binder for `GroqApi:ApiKey`. Exact per spec. |
| `src/BloodNetwork.Api/appsettings.json:51` | `BaseUrl: "https://api.groq.com/openai/v1"` | INFO | PASS. `GroqChatService.cs:86` appends `/chat/completions` → full `https://api.groq.com/openai/v1/chat/completions` correct OpenAI-compat. |
| `appsettings.json:52` | `Model: "openai/gpt-oss-20b"` | INFO | PASS — `GroqOptions.cs:8` default same. Previously `llama-3.3-*` 404 fixed. Current `openai/gpt-oss-20b` is valid Groq-hosted OSS model. |
| `appsettings.json:53` | `MaxTokens: 1024` | MEDIUM | Spec asks “1024 enough for reasoning+content?” — `gpt-oss-20b` is **reasoning** model; Groq docs count reasoning tokens against `max_tokens`. 1024 may truncate chain-of-thought + answer. For 150-word answer limit (`GroqChatService.cs:34` “under 150 words”) 1024 is **enough** (~750 tokens ~ 550 words), but if reasoning is verbose (~500 tokens) you risk mid-sentence cutoff. Consider 2048 or 4096 buffered. Also `max_tokens` param is deprecated in favor of `max_completion_tokens` for some models — currently still accepted. LOW-MED. |
| `appsettings.json:54` | `Temperature: 0.7` | INFO | PASS. |
| `GroqChatService.cs:70-71` | Role lowercasing: `msg.Role?.ToLowerInvariant() == "assistant" ? "assistant" : "user"` | INFO | PASS — `User->user` per spec. Handles `User`, `USER`, `assistant`, etc. |
| `frontend/blood-network-web/src/app/shared/components/chatbot/chatbot.component.ts:325` | Sends `Role: 'User'/'Assistant'` (PascalCase) | INFO | PASS — matches backend `ChatMessage.Role` PascalCase. `GroqChatService` then lowercases — flow consistent. |
| `GroqChatService.cs:51` | Sentinel check `ApiKey == "YOUR_GROQ_API_KEY"` | INFO | PASS — graceful fallback message bilingual. |
| `src/BloodNetwork.Infrastructure/DependencyInjection.cs:43` | `AddHttpClient<IAiChatService, GroqChatService>()` | INFO | PASS — typed HttpClient with default handler, no BaseAddress (per-request URI). OK. Missing Polly retry — Groq 429/500 will bubble as generic “trouble connecting” — acceptable. |

---

## 9. SignalR Hub

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Api/Program.cs:270` | `MapHub<NotificationHub>("/hubs/notifications")` **after** `UseAuthorization` (`267-268`) | INFO | PASS — correct ordering: `UseAuthentication` → `UseAuthorization` → `MapHub`. Hub’s `[Authorize]` in `NotificationHub.cs:7` then enforced. |
| `Program.cs:82-91` | `JwtBearerEvents.OnMessageReceived` query `access_token` for `path.StartsWithSegments("/hubs/notifications")` | INFO | PASS — enables WebSocket auth (Authorization header not sent during WS handshake). |
| `Program.cs:106-109` | `AllowCredentials()` in CORS | INFO | PASS — required when `withUrl(..., {accessTokenFactory})` or `withCredentials` — browser blocks otherwise. |
| `frontend/blood-network-web/src/app/core/services/signalr.service.ts:34` | `hubUrl = environment.apiUrl.replace('/api','') + '/hubs/notifications'` | MEDIUM | Fragile. If `apiUrl` is `https://...onrender.com/api` → `https://...onrender.com/hubs/notifications` correct. If operator sets `API_URL=https://...onrender.com/api/` (trailing slash), `.replace('/api','')` leaves trailing slash → `https://...onrender.com//hubs/...` double slash (still works but ugly). If `apiUrl` ever becomes `https://...onrender.com/api/v1` → replace only first `/api` → `https://...onrender.com/v1/hubs/...` wrong. Safer: `new URL('/hubs/notifications', apiUrl).href` or `apiUrl.replace(/\/api\/?$/,'')`. Also `environment.apiUrl` is evaluated at import time; if `window.__env` loads after bundle, `replace` may run with stale `http://localhost:8080/api` before `env.js` overrides — though `src/environments/environment.ts:9` lazy `window.__env?.apiUrl` check mitigates but still import-time eval. |
| `signalr.service.ts:37` | `accessTokenFactory: () => token` where `token = localStorage.getItem('access_token')` captured at `start()` time, not refreshed | MEDIUM | If token expires and `auth.interceptor` refreshes it, SignalR’s factory still returns old captured `token` on reconnect (`withAutomaticReconnect [0,2,5,10,15,30]` line 38) — reconnect will 401 and `onclose` → `disconnected` with no retry of token. Fix: `accessTokenFactory: () => localStorage.getItem('access_token') ?? ''` (read fresh each time). |
| `NotificationHub.cs:12-16` | `FindFirst(ClaimTypes.NameIdentifier)` without `sub` fallback (see JWT section) | CRITICAL | Hub will never group connections; `SignalRNotificationBroadcaster:18` `Clients.Group($"user_{userId}")` will never reach anyone. Real-time notifications dead. |

---

## 10. Database

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `src/BloodNetwork.Infrastructure/Data/Migrations/` | 4 migrations: `20260826130216_InitialCreate`, `20260826141848_AddMustChangePassword`, `20260826162956_AddRefreshTokenAndIndexes`, `20260826192414_AddMissingLocations` + `ModelSnapshot` | INFO | PASS. Timestamps are 2026-08-26 (future-dated due to CI clock/TimeZone? Today is 2026-08-27 per env, so still < now — OK). `Program.cs:166` `MigrateAsync()` at startup handles applying them on Render. |
| `BloodNetworkDbContext.cs:31-104` + `BangladeshLocationSeed.cs:7-109` | `HasData` seed for 8 divisions, 64 districts, 506 upazilas — verified via `count(new() { Id`): Divisions 8, Districts 64, Upazilas 506 | INFO | PASS — counts exactly match 2024 Bangladesh admin (8 divisions, 64 districts, 495 official upazilas + 11 recent splits = ~506). “Gaza? Complete” → no “Gaza” division; all divisions are Dhaka/Chattogram/Rajshahi/Khulna/Barishal/Sylhet/Rangpur/Mymensingh — complete and no Gaza typo found. |
| `BangladeshLocationSeed.cs:116+` | Upazila list includes suspicious duplicates / mis-typed NameBn | LOW | Examples: `Moulvibazar` has both `Barlekha` and `Baralekha` duplicate GUIDs `aa000050-...-002/003` same Name different GUIDs; `Hatiya` NameBn `"পটিয়া"` should be `"হাতিয়া"` (`BangladeshLocationSeed.cs:318`); `Jhalakathi` `Kanthalia` count off; `Patuakhali` etc. Not deployment-blocking but data quality. |
| `src/BloodNetwork.Infrastructure/Data/Migrations/BloodNetworkDbContextModelSnapshot.cs` | Shadow property `UserId1` on `RefreshToken` (`Property<Guid?>("UserId1")` + `HasIndex("UserId1")` + `HasForeignKey("UserId1")`) | HIGH | EF Core created **second FK** because `User.RefreshTokens` (principal) + `RefreshToken.User` (dependent with `HasForeignKey(t=>t.UserId)`) plus missing inverse config `WithMany(u=>u.RefreshTokens)` causes convention to generate shadow `UserId1`. DB will have **two FK columns**: `UserId` (configured) and `UserId1` (shadow, nullable). Migration will create duplicate index/foreign key; inserts via `RefreshToken.UserId` will leave `UserId1` null, but future `Include` or cascade may behave oddly. Fix: `RefreshTokenConfiguration.cs:18-21` change `.WithMany()` to `.WithMany(u => u.RefreshTokens)` or add `builder.HasOne(t=>t.User).WithMany(u=>u.RefreshTokens)...` and ignore shadow. |
| `Program.cs:156` | `AddHealthChecks()` with **no** `AddNpgSql` check — lightweight | INFO | PASS per audit prompt “now lightweight – is that correct?” — yes, intentionally lightweight to avoid Render health check failing when DB cold-starts. Trade-off: `/health` returns 200 even if DB down → orchestrator thinks app healthy while DB migrations may have failed (line 171 logs but continues). `Program.cs:272-275` `/health/ready` with predicate `Tags.Contains("ready")` but no health check has tag `ready`, so `/health/ready` **always healthy** regardless. If you want readiness DB probe, add `AddCheck<NpgSqlHealthCheck>("db", tags:["ready"])`. Current lightweight is intentional for free tier sleep. |
| `src/BloodNetwork.Infrastructure/Data/Configurations/RefreshTokenConfiguration.cs:11-26` | Indexes: `Token` unique, `UserId`, `{UserId, IsRevoked}` | INFO | PASS. |
| `src/BloodNetwork.Api/Program.cs:164-172` | `MigrateAsync` in try/catch logs error but continues | MEDIUM | If migration fails (e.g., `UserId1` duplicate, seed conflict) app starts but “may not function correctly” — health checks won’t catch it. Consider failing fast or exposing `/health/ready` DB check instead. |
| `src/BloodNetwork.Infrastructure/Data/BloodNetworkDbContext.cs:12-15` | `ConfigureWarnings(... Ignore PendingModelChangesWarning)` | LOW | Silences EF10 pending model changes warning at runtime — masks drift between ModelSnapshot and DbContext. In prod you want warning. OK for demo. |

---

## 11. Frontend Env

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `frontend/blood-network-web/public/env.js:1-2` | Fallback `apiUrl = ... || 'https://blood-network-bangladesh.onrender.com/api'` | INFO | PASS — matches `src/environments/environment.prod.ts:9` fallback. Note domain is **API** (`blood-network-bangladesh`) not frontend (`...-frontend`). Correct. |
| `frontend/blood-network-web/src/environments/environment.ts:9` | Fallback `http://localhost:8080/api` (with `window.__env?.apiUrl ||`) | INFO | PASS — matches Docker/Kestrel 8080 for `ng serve` proxy. |
| `frontend/blood-network-web/src/environments/environment.prod.ts:9` | Same fallback prod domain + same lazy check | INFO | PASS. Uses `fileReplacements` in `angular.json:64-69` to swap `environment.ts` → `environment.prod.ts` for `production` config → correct. |
| `frontend/blood-network-web/package.json:8` | `build:prod` script: `API_URL||'http://localhost:5000/api'` then writes `public/env.js` with `window.__env.apiUrl = '<url>'` (no fallback) | MEDIUM | Port **5000** desync! `environment.ts` fallback is 8080, Dockerfile/Kestrel is 8080, but build script defaults to 5000. If `API_URL` not set in Render build env, built `public/env.js` will contain `http://localhost:5000/api` baked into `dist/browser/env.js` — local builds will point to wrong port. At runtime `window.__env.apiUrl` will **not** fallback because `build:prod` wrote raw `window.__env.apiUrl = 'http://localhost:5000/api'` without `||`. Actually built `dist/env.js` currently on disk shows fallback `|| 'https://...'` because last build was manual, not via `API_URL` missing. But CI with no `API_URL` will produce 5000. Fix: `API_URL||'https://blood-network-bangladesh.onrender.com/api'` or at least `http://localhost:8080/api`; and include `||` fallback. |
| `frontend/blood-network-web/src/index.html:16` | Loads `env.js` via `<script src="env.js">` without `?v` cache bust | LOW | Render Static Site aggressively caches. After `API_URL` change + redeploy, browsers may serve stale `env.js`. Add `src="env.js?v=1"` or set `Cache-Control: no-cache` for `env.js` via Render headers config. |
| `frontend/blood-network-web/dist/blood-network-web/browser/env.js` | Currently contains same fallback as `public/env.js` | INFO | On last local `ng build` it copied verbatim. In CI via `build:prod`, it will be overwritten with `API_URL` value — verified workflow. |

---

## 12. Backend ↔ Frontend Route Table

Legend: ✅ match, ❌ mismatch, ⚠️ case nuance

| Frontend call (`src/app/core/services/*` + `chatbot`) | Backend `[Route]` + verb | Match? |
|---|---|---|
| `POST ${apiUrl}/auth/register` (`auth.service.ts:38`) | `[Route("api/[controller]")] AuthController + [HttpPost("register")]` → `POST api/auth/register` (`AuthController.cs:10,20`) | ✅ case-insensitive OK |
| `POST ${apiUrl}/auth/login` (`:47`) | `POST api/auth/login` (`:34`) | ✅ |
| `POST ${apiUrl}/auth/refresh` (`:56`) | `POST api/auth/refresh` (`:48`) | ✅ |
| `POST ${apiUrl}/auth/first-login-change` (`:60`) | `POST api/auth/first-login-change` (`:71`) | ✅ `first-login-change` kebab matches. |
| `POST ${apiUrl}/auth/logout` (NOT CALLED by frontend — `auth.service.ts:73 logout()` only clears local) | `POST api/auth/logout` (`:62`) | ⚠️ Frontend never calls logout endpoint → refresh token remains valid in DB (revocation never happens) until expiry. Not a route mismatch but integration gap. |
| `GET ${apiUrl}/auth/me` (not used by services, only `AuthController:88`) | `GET api/auth/me` | — unused; OK. |
| `POST ${apiUrl}/donors/me/profile` (`donor.service.ts:42`) | `[Route("api/[controller]")] Donors + [HttpPost("me/profile")]` → `POST api/donors/me/profile` (`DonorsController.cs:28`) | ✅ `donors` vs `Donors` case-insensitive. |
| `PUT ${apiUrl}/donors/me/profile` (`:55`) | `PUT api/donors/me/profile` (`:46`) | ✅ |
| `GET ${apiUrl}/donors/me/profile` (`:29`) | `GET api/donors/me/profile` (`:65`) | ✅ |
| `PATCH ${apiUrl}/donors/me/availability` (`:59`) | `PATCH api/donors/me/availability` (`:83`) | ✅ |
| `GET ${apiUrl}/donors/search` (`:72`) | `GET api/donors/search` with `EnableRateLimiting("search")` (`:101`) | ✅ |
| `POST ${apiUrl}/blood-requests` (`request.service.ts:17`) | `[Route("api/blood-requests")] + [HttpPost]` → `POST api/blood-requests` (`BloodRequestsController.cs:14,30`) | ✅ |
| `GET ${apiUrl}/blood-requests/{id}` (`:21`) | `GET api/blood-requests/{id:guid}` (`:48`) | ✅ |
| `GET ${apiUrl}/blood-requests/my` (`:29`) | `GET api/blood-requests/my` (`:96`) | ✅ Note: must be before `{id:guid}` else `my` could be parsed as GUID — correct order in controller (`my` at line 96 before catch-all?). ASP.NET matches literal first, so OK. |
| `GET ${apiUrl}/blood-requests/open` (`:45`) | `GET api/blood-requests/open` (`:117`) | ✅ same ordering note. |
| `PATCH ${apiUrl}/blood-requests/{id}/cancel` (`:49`) | `PATCH api/blood-requests/{id:guid}/cancel` (`:130`) | ✅ |
| `PATCH ${apiUrl}/blood-requests/{id}/fulfill` (`:53`) | `PATCH api/blood-requests/{id:guid}/fulfill` (`:148`) | ✅ |
| `GET ${apiUrl}/matches/request/{id}` (`match.service.ts:16`) | `[Route("api/matches")] + [HttpGet("request/{requestId}")]` → `GET api/matches/request/{requestId}` (`MatchesController.cs:13,34`) | ✅ |
| `GET ${apiUrl}/matches/donor` (`:20`) | `GET api/matches/donor` (`:59`) | ✅ |
| `GET ${apiUrl}/matches/{id}` (`:24`) | `GET api/matches/{matchId}` (`:75`) | ✅ |
| `POST ${apiUrl}/matches/{id}/respond` (`:28`) | `POST api/matches/{matchId}/respond` (`:94`) | ✅ |
| `POST api/matches/request/{id}/trigger-match` (`MatchesController.cs:106`) | **No frontend call** | ⚠️ Dead endpoint (admin/manual) — not wired. OK. |
| `GET ${apiUrl}/notifications` (`notification.service.ts:31`) | `[Route("api/notifications")] + [HttpGet]` → `GET api/notifications` (`NotificationsController.cs:11,22`) | ✅ |
| `GET ${apiUrl}/notifications/unread-count` (`:37`) | `GET api/notifications/unread-count` (`:32`) | ✅ |
| `POST ${apiUrl}/notifications/{id}/read` (`:43`) | `POST api/notifications/{notificationId}/read` (`:42`) | ✅ |
| `POST ${apiUrl}/notifications/read-all` (`:52`) | `POST api/notifications/read-all` (`:54`) | ✅ |
| `GET ${apiUrl}/locations/divisions` (`location.service.ts:35`) | `[Route("api/[controller]")] Locations + [HttpGet("divisions")]` → `GET api/locations/divisions` (`LocationsController.cs:9,26`) | ✅ |
| `GET ${apiUrl}/locations/districts?divisionId` (`:41`) | `GET api/locations/districts` (`:35`) | ✅ |
| `GET ${apiUrl}/locations/upazilas?districtId` (`:47`) | `GET api/locations/upazilas` (`:49`) | ✅ |
| `GET ${apiUrl}/ai/...` (`AIController.cs:10` — `eligibility/questions`, `eligibility/check`, `donors/re-engagement`, `matches/enhanced/{id}`) | **No frontend service** calls `api/ai/*` | ⚠️ Frontend has no `ai` service; `chatbot` uses `api/chat`, not `api/ai`. These AI eligibility/match-enhancement endpoints are unreachable from UI (maybe admin). Not a mismatch but uncovered integration. |
| `POST ${apiUrl}/chat` (`chatbot.component.ts:328` + `ChatController.cs:9,19`) | `[Route("api/chat")] + [HttpPost]` → `POST api/chat` | ✅ Note `ChatController` is **AllowAnonymous**? No `[Authorize]` on class — public chat is intentionally open. If you wanted auth, missing. |
| `GET /hubs/notifications` (`signalr.service.ts:34` + `Program.cs:270`) | `MapHub<NotificationHub>("/hubs/notifications")` | ✅ path exact. |
| `GET /health`, `/health/ready`, `/swagger` | `MapHealthChecks` + `UseSwagger` | — direct, no frontend. |

**Route prefix:** all backend routes correctly start `api/` (except hub, health, swagger) and frontend always prefixes `environment.apiUrl` which already ends `/api` → full `.../api/...` matches.

**Pluralization:** `blood-requests` plural correct both sides; `donors` vs `donors` OK; `matches` plural.

**Case:** Backend `api/[controller]` yields `api/Auth`/`api/Donors` but routing is case-insensitive; frontend uses lowercased `auth`, `donors` — OK.

**Gaps:** `auth/logout` not called, `ai/*` not called, `matches/trigger-match` not called — not mismatches but dead code.

**Overall:** ✅ No breaking mismatch; API contract is consistent.

---

## 13. API Rate Limiting

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `Program.cs:113-150` | Uses `AddFixedWindowLimiter` for `auth` (10/1m), `api` (60/1m), `search` (30/1m) — **not** sliding windows | MEDIUM | Spec says “sliding windows (auth, api, search)” — actual is **fixed window**. Fixed window allows burst at window boundary (e.g., 10 requests at 00:59 + 10 at 01:00 = 20 in 2 seconds). Sliding window would be smoother. Not a bug but spec deviation. If sliding required, use `AddSlidingWindowLimiter`. |
| `Program.cs:138-149` | `OnRejected` returns JSON `{success:false, message, retryAfter}` with `Content-Type: application/json` | INFO | PASS per spec. Includes `RetryAfter` from `MetadataName.RetryAfter` or 60s fallback. |
| `Program.cs:121,125,131` | `QueueLimit = 0` (no queue) | INFO | Good — fails fast with 429 rather than queuing. |
| `Program.cs:269` | `MapControllers().RequireRateLimiting("api")` | INFO | PASS — global default `api` (60/min) for all controllers. Overrides via `[EnableRateLimiting("auth")]` on `AuthController:21,35` & `[EnableRateLimiting("search")]` on `DonorsController:102` correctly apply distinct policies. |
| `Program.cs:269` vs Controllers | `ChatController.cs:19` and `AIController.cs` have **no** `[EnableRateLimiting]` nor `[DisableRateLimiting]` — inherit global `api` 60/min | LOW | `api/chat` is AI-backed (Groq) billing-sensitive — should have stricter limiter (e.g., 20/min) or dedicated `chat` policy to prevent abuse. Currently 60/min may allow wallet drain. Consider `EnableRateLimiting("api")` explicit or new `chat` policy. |
| `Program.cs:271-275` | `MapHealthChecks` **not** rate limited | INFO | Correct — health probes must bypass. Because only `MapControllers` is limited, `/health` and `/hubs` exempt. Good. |

---

## 14. Cross-Cutting / Additional Findings

| File:Line | Issue | Severity | Detail |
|-----------|-------|----------|--------|
| `DEPLOY.md:16,21-26,47` | `ASPNETCORE_URLS=http://+:8080` set in Dockerfile **and** Render env var → duplicate, but `API_URL` example `https://blood-network-api.onrender.com` (no `/api`) — `build:prod` expects `API_URL` **with** `/api`? `DEPLOY.md:48` `API_URL = (copy URL from Step 2, e.g. https://blood-network-api.onrender.com)` → then `Pre-Deploy: echo "... '$API_URL/api'"` correctly appends. But `package.json:8` `API_URL||'http://localhost:5000/api'` expects URL **with** `/api` already. Dual convention confusing. | MEDIUM | Unify: either always store bare host or always store `/api`. Current runtime `public/env.js` fallback includes `/api`; build script must not double-append. Document. |
| `DEPLOY.md:35-41` | Publish dir `frontend/blood-network-web/dist/blood-network-web/browser` — correct for `@angular/build:application` (line 44 `browser: src/main.ts`) | INFO | PASS. Angular 17+ `application` builder nests `browser` subfolder — old `dist/blood-network-web` would be wrong. Doc is correct. |
| `src/BloodNetwork.Api/Program.cs:264` | `UseHttpsRedirection()` behind Render proxy (terminates TLS) | LOW | Render terminates TLS and sets `X-Forwarded-Proto: https`; Kestrel sees `http` → `UseHttpsRedirection` would **redirect to https** loop if `ForwardedHeaders` not parsed first. Order is `UseForwardedHeaders` (260) → `UseHttpsRedirection` (264) correct, so it will **not** redirect when `X-Forwarded-Proto:https` already. But in Render free tier, `ForwardedHeadersOptions` defaults may not trust proxy — need `KnownProxies`/`KnownNetworks` clear. Current default trusts nothing on .NET8+ but Render uses known; may need `options.KnownNetworks.Clear(); options.KnownProxies.Clear();`. Not blocking. |
| `src/BloodNetwork.Application/DTOs/*` | `AuthResponse` etc. not versioned | INFO | — |
| `src/BloodNetwork.Api/Middleware/GlobalExceptionHandlingMiddleware` | Not audited — assume logs correctly. | INFO | — |

---

## Summary Counts

- **CRITICAL (1):** `NotificationHub` `NameIdentifier` bug → real-time broken.
- **HIGH (3):** `404.html` hash, `UserId1` shadow FK, `DEPLOY.md` CORS origin typo + `ValidateRefreshToken` dead.
- **MEDIUM (7):** `MaxTokens` truncation risk, SignalR `hubUrl` + `accessTokenFactory` staleness, port 5000 desync, rate-limit Fixed vs Sliding, `ChatController` no limiter, `DEPLOY.md` Jwt 60 vs 15, `MigrateAsync` swallow.
- **LOW (7):** `.dockerignore` `dist`, trailing slash CORS, etc.
- **PASS (many)** — Dockerfile, render.yaml, static.json presence, port binding, CORS AllowCredentials, JWT Issuer/Audience/ClockSkew, Groq env name/model/role, DB counts 8/64/506, route table overall.

---

## Recommended Fix Order (top 5)

1. `src/BloodNetwork.Api/Hubs/NotificationHub.cs:12-13,22-23` — add `?? FindFirst("sub")` fallback (CRITICAL, 2-line fix).
2. `src/BloodNetwork.Infrastructure/Data/Configurations/RefreshTokenConfiguration.cs:18` — `.WithMany(u=>u.RefreshTokens)` to drop `UserId1` shadow (HIGH, 1-line fix + new migration).
3. `frontend/blood-network-web/public/404.html` — replace hash redirect with simple copy of `index.html` or delete file and rely on Render rewrite rule (HIGH).
4. `DEPLOY.md:26,58-60` — fix `Jwt__ExpirationInMinutes` to 15 and `AllowedOrigins` to `https://blood-network-bangladesh-frontend.onrender.com` (HIGH, doc only).
5. `frontend/blood-network-web/src/app/core/services/signalr.service.ts:34,37` — fix `hubUrl` parsing + `accessTokenFactory` to read fresh token (MEDIUM).

---

*Generated READ-ONLY. No files were modified.*
