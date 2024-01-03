import { Injectable } from '@angular/core';
import { LoginResponseModel } from '../models/login-response.model';
import { jwtDecode } from 'jwt-decode';
import { DecodeModel } from '../models/decode.mode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  hasAuthendticated: boolean = false;
  decode: DecodeModel = new DecodeModel();
  token: string = ""; 

  isAuthenticated() {
    const responseString = localStorage.getItem("response");

    if (responseString) {
      try {
        const response = JSON.parse(responseString) as LoginResponseModel;
        this.token = response.accessToken;
        this.decode = jwtDecode(this.token);

        const now = new Date().getTime() / 1000;

        if (now > this.decode.exp) {
          this.hasAuthendticated = false;
          return false;
        }

        this.hasAuthendticated = true;
        return true;
      } catch (error) {
        alert("Geçersiz token!!");

        this.hasAuthendticated = false;
        return false;
      }

    }

    this.hasAuthendticated = false;
    return false;
  }
}
