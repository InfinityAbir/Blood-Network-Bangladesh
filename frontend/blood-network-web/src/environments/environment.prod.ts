declare global {
  interface Window {
    __env?: { apiUrl: string };
  }
}

export const environment = {
  production: true,
  apiUrl: (typeof window !== 'undefined' && window.__env?.apiUrl) || 'https://blood-network-api.onrender.com/api'
};
