# Blood Network Bangladesh - Render Deployment

## Step 1: Create PostgreSQL Database
1. Render Dashboard → **New +** → **PostgreSQL**
2. Name: `blood-network-db`
3. Plan: **Free**
4. Database Name: `bloodnetwork`
5. Note the **Internal Database URL** (copy it)

## Step 2: Create API Web Service
1. Render Dashboard → **New +** → **Web Service**
2. Connect GitHub repo: `InfinityAbir/Blood-Network-Bangladesh`
3. Settings:
   - **Name:** `blood-network-api`
   - **Runtime:** `Docker`
   - **Port:** `8080`
   - **Health Check Path:** `/health`
4. Environment Variables:
   ```
   ASPNETCORE_ENVIRONMENT = Production
   ASPNETCORE_URLS = http://+:8080
   ConnectionStrings__DefaultConnection = (paste Internal Database URL from Step 1)
   Jwt__Secret = (click Generate - any random string 32+ chars)
   Jwt__Issuer = BloodNetworkBangladesh
   Jwt__Audience = BloodNetworkBangladesh
   Jwt__ExpirationInMinutes = 60
   ```
5. Click **Create Web Service**

## Step 3: Create Frontend Static Site
1. Render Dashboard → **New +** → **Static Site**
2. Connect same GitHub repo
3. Settings:
   - **Name:** `blood-network-frontend`
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
After the frontend is deployed, go back to the API service → Environment Variables and add:
```
AllowedOrigins = ["https://blood-network-frontend.onrender.com"]
```
Then manually redeploy the API service.
