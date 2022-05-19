export class JwtAuthResult {
  accessToken = '';
  userName = '';
  isAdmin = false;
  isAuthenticated = false;
  accessTokenExpiration: Date=new Date();
  refreshTokenExpiration: Date=new Date();;
}

