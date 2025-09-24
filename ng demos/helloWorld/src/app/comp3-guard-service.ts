import { Injectable } from '@angular/core';
import {  CanActivate } from '@angular/router';

@Injectable({
  providedIn: 'root'
}) 
export class Comp3GuardService implements CanActivate {
  canActivate(): boolean {
      //Check whether user is authenticated & authorized or either and hence, the route can be activated
      return false;
      //return false; if you want to block the route activation
  }
}
