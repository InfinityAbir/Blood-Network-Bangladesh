declare global {
  interface Window {
    __env?: { apiUrl: string };
  }
}

export const environment = {
  production: true,
  apiUrl: (typeof window !== 'undefined' && window.__env?.apiUrl) || 'https://blood-network-api.onrender.com/api',
  firebase: {
    apiKey: 'AIzaSyCjU6eiqI1UzVWkxZiJRmU37Y51fOn58oA',
    authDomain: 'blood-network-bangladesh.firebaseapp.com',
    projectId: 'blood-network-bangladesh',
    storageBucket: 'blood-network-bangladesh.firebasestorage.app',
    messagingSenderId: '496044679346',
    appId: '1:496044679346:web:c8549e93e3c6d8d9bde9ab'
  },
  firebaseVapidKey: 'BL2Lh6J4mY-PdbQbGgDklaon60FBJI12ZRkj0N6qAQfrKI3Z9lXq98vh8TeJOQ40TDJpRNmVI0n6H5uWvHXzCaI'
};
