import { AuthConfig } from 'angular-oauth2-oidc';

export const googleAuthConfig: AuthConfig = {
  issuer: 'https://accounts.google.com',
  redirectUri: 'https://questionsapp.mustafasamedyeyin.com',
  clientId: '30685658695-tj9r8oer5vi29qk5qag71ag40foncra4.apps.googleusercontent.com',
  responseType: 'code', // This indicates we want an authorization code
  scope: 'openid profile email',
  showDebugInformation: true,
  strictDiscoveryDocumentValidation: false,
  // Add this to enable code flow handling
  useSilentRefresh: false,
  oidc: true
};