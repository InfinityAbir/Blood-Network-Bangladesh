import { Routes } from '@angular/router';
import { authGuard, adminGuard, firstLoginGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/shared/landing/landing.component').then(m => m.LandingComponent)
  },
  {
    path: 'find-blood',
    loadComponent: () => import('./features/shared/find-blood/find-blood.component').then(m => m.FindBloodComponent)
  },
  {
    path: 'request-blood',
    loadComponent: () => import('./features/request/request-blood/request-blood.component').then(m => m.RequestBloodComponent),
    canActivate: [authGuard]
  },
  {
    path: 'eligibility',
    loadComponent: () => import('./shared/components/eligibility-check/eligibility-check.component').then(m => m.EligibilityCheckComponent)
  },
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'register',
    loadComponent: () => import('./features/auth/register/register.component').then(m => m.RegisterComponent)
  },
  {
    path: 'donor/dashboard',
    loadComponent: () => import('./features/donor/dashboard/dashboard.component').then(m => m.DonorDashboardComponent),
    canActivate: [authGuard]
  },
  {
    path: 'donor/profile',
    loadComponent: () => import('./features/donor/profile/profile.component').then(m => m.DonorProfileComponent),
    canActivate: [authGuard]
  },
  {
    path: 'requester/dashboard',
    loadComponent: () => import('./features/request/dashboard/dashboard.component').then(m => m.RequesterDashboardComponent),
    canActivate: [authGuard]
  },
  {
    path: 'admin',
    loadComponent: () => import('./features/admin/dashboard/dashboard.component').then(m => m.AdminDashboardComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'admin/users',
    loadComponent: () => import('./features/admin/users/users.component').then(m => m.UserManagementComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'admin/reports',
    loadComponent: () => import('./features/admin/reports/reports.component').then(m => m.ReportManagementComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'admin/audit-logs',
    loadComponent: () => import('./features/admin/audit-logs/audit-logs.component').then(m => m.AuditLogViewerComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'admin/first-login-change',
    loadComponent: () => import('./features/admin/first-login/first-login.component').then(m => m.AdminFirstLoginComponent),
    canActivate: [firstLoginGuard]
  },
  {
    path: 'admin/settings',
    loadComponent: () => import('./features/admin/settings/settings.component').then(m => m.AdminSettingsComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'admin/eligibility-questions',
    loadComponent: () => import('./features/admin/eligibility-questions/eligibility-questions.component').then(m => m.AdminEligibilityQuestionsComponent),
    canActivate: [adminGuard]
  },
  {
    path: 'settings',
    loadComponent: () => import('./features/shared/settings/settings.component').then(m => m.UserSettingsComponent),
    canActivate: [authGuard]
  },
  {
    path: 'about',
    loadComponent: () => import('./features/shared/about/about.component').then(m => m.AboutComponent)
  },
  {
    path: 'notifications',
    loadComponent: () => import('./features/notifications/notifications.component').then(m => m.NotificationsComponent),
    canActivate: [authGuard]
  },
  {
    path: '**',
    loadComponent: () => import('./features/shared/not-found/not-found.component').then(m => m.NotFoundComponent)
  }
];
