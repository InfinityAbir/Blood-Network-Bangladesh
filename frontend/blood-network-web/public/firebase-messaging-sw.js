// Runs in its own worker context — can't import the Angular environment files, so the
// (non-secret) Firebase web config is duplicated here. Keep in sync with
// src/environments/environment.prod.ts if the Firebase web app config ever changes.
importScripts('https://www.gstatic.com/firebasejs/12.18.0/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/12.18.0/firebase-messaging-compat.js');

firebase.initializeApp({
  apiKey: 'AIzaSyCjU6eiqIlUzVWkxZiJRmU37Y51fOn58oA',
  authDomain: 'blood-network-bangladesh.firebaseapp.com',
  projectId: 'blood-network-bangladesh',
  storageBucket: 'blood-network-bangladesh.firebasestorage.app',
  messagingSenderId: '496044679346',
  appId: '1:496044679346:web:c0549e93e3c6d8d9bde9ab'
});

const messaging = firebase.messaging();

// Only fires when the tab isn't focused/open — the foreground case is handled by
// onMessage() in push-notification.service.ts so we don't show it twice.
messaging.onBackgroundMessage((payload) => {
  const title = payload.notification?.title || payload.data?.title || 'Blood Network Bangladesh';
  const body = payload.notification?.body || payload.data?.message || '';

  self.registration.showNotification(title, {
    body,
    icon: '/favicon.ico',
    data: payload.data || {}
  });
});

self.addEventListener('notificationclick', (event) => {
  event.notification.close();
  event.waitUntil(
    self.clients.matchAll({ type: 'window', includeUncontrolled: true }).then((clients) => {
      for (const client of clients) {
        if ('focus' in client) return client.focus();
      }
      if (self.clients.openWindow) return self.clients.openWindow('/');
    })
  );
});
