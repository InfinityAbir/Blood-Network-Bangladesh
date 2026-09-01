# Blood Network Bangladesh - Render Deployment

## Step 1 + 2: Database + API service — via Blueprint (`render.yaml`)

The database and API web service are now IaC-managed by `render.yaml` at the repo root,
instead of being clicked together by hand. This is what pins the API to a **single
instance** and generates `Jwt__Secret` **exactly once**, which is what was causing
`signature key not found` 401s after scaling (the old manual setup had no instance-count
guardrail and the secret was one dashboard click away from being silently regenerated).

1. Render Dashboard → **New +** → **Blueprint**
2. Connect GitHub repo: `InfinityAbir/Blood-Network-Bangladesh`
3. Render detects `render.yaml`, shows a preview of the `blood-network-db` database and
   `blood-network-api` web service it's about to create — review the diff before
   confirming (this preview is also how you validate the YAML if you ever edit it).
4. Click **Apply** / **Create New Resources**. Render provisions the DB, then the API
   service, wiring `ConnectionStrings__DefaultConnection` from the DB automatically and
   generating `Jwt__Secret` once.
5. After the first sync, set the secrets marked `sync: false` in the dashboard
   (API service → Environment): `GroqApi__ApiKey`, `Firebase__ServiceAccountJson`
   (see **Push notifications (FCM)** below — without it, push silently no-ops).

**Never do these again once the Blueprint is applied:**
- Don't click "Generate" on `Jwt__Secret` in the dashboard — it's now blueprint-managed
  and persists across redeploys on its own. Regenerating it invalidates every live
  session's access token instantly.
- Don't create a second `blood-network-api` web service (e.g. for blue/green) without
  also pointing it at the *same* `Jwt__Secret` value — two services each generating
  their own secret is the other way this bug reappears.
- Don't hand-edit the instance count outside `render.yaml`'s `numInstances: 1` — if this
  API ever needs to scale horizontally, all instances must still share one env-var-backed
  secret (already true for a single Render service), just don't split it into multiple
  services.

## Step 3: Create Frontend Static Site
1. Render Dashboard → **New +** → **Static Site**
2. Connect same GitHub repo
3. Settings:
   - **Name:** `blood-network-bangladesh-frontend`
   - **Build Command:**
     ```
     cd frontend/blood-network-web && npm install && npm run build -- --configuration=production
     ```
   - **Publish Directory:**
     ```
     frontend/blood-network-web/dist/blood-network-web/browser
     ```
4. Add **SPA Rewrite Rule:**
   - Source: `/*`
   - Destination: `/index.html`
5. Environment Variables:
   ```
   API_URL = (copy the URL from Step 2, e.g. https://blood-network-api.onrender.com)
   ```
6. **Pre-Deploy Command:**
   ```
   cd frontend/blood-network-web && echo "window.__env = window.__env || {};" > public/env.js && echo "window.__env.apiUrl = '$API_URL/api';" >> public/env.js
   ```
7. Click **Create Static Site**

## Step 4: Update API CORS
`render.yaml` already sets `AllowedOrigins` to `https://blood-network-frontend.onrender.com`.
Only touch this if your frontend ends up on a different Render URL — update the value in
`render.yaml` (preferred, keeps it version-controlled) or override it directly on the API
service's Environment tab, then redeploy.

## Push notifications (FCM)

Donor-match, verification, and report-resolution pushes are sent through Firebase Cloud
Messaging by `PushNotificationService`. It degrades to a **silent no-op** with no error and
no crash if credentials are missing — in-app/SignalR notifications keep working, but no
OS-level push ever reaches a device. To enable it:

1. Firebase Console → your project → **Project Settings** → **Service Accounts** →
   **Generate new private key**. This downloads a JSON file.
2. Minify it to a single line (e.g. `jq -c . serviceAccount.json` or any JSON minifier —
   the value must be valid single-line JSON, not a file path).
3. Render Dashboard → `blood-network-api` → **Environment** → add `Firebase__ServiceAccountJson`
   with that JSON as the value. Keep it out of git — never commit the key file.
4. Redeploy. Startup logs should show `Firebase Admin initialized (FCM push enabled)`; if
   credentials are missing/invalid you'll instead see `Firebase Admin could not be
   initialized. Push notifications disabled.`

## Database backups

Render's **free** Postgres plan (`blood-network-db`) has no automated backups and the
database itself **expires ~30 days after creation** unless upgraded to a paid plan —
this is separate from the JWT issue above but is the other silent-data-loss risk on this
stack. Two ways to cover it:

- **Upgrade the plan** (Starter or above) once there's real user data — paid plans get
  daily automated backups with point-in-time recovery, no extra scripting needed.
- **Manual/scheduled `pg_dump`** in the meantime — run from anywhere with network access
  to the DB's *External* Database URL (found on the database's Render dashboard page):
  ```bash
  pg_dump "$EXTERNAL_DATABASE_URL" -Fc -f "bloodnetwork-$(date +%F).dump"
  ```
  Restore with `pg_restore -d "$TARGET_DATABASE_URL" bloodnetwork-YYYY-MM-DD.dump`. Store
  the dump somewhere durable (not just the machine that ran the command) and repeat on a
  schedule (a weekly cron/GitHub Actions job, or just a calendar reminder pre-launch)
  until the plan is upgraded.
