import { Routes } from '@angular/router';

import { Comp1 } from './comp1/comp1';
import { Comp2 } from './comp2/comp2';
import { Comp3 } from './comp3/comp3';
import { ErrorComp } from './error-comp/error-comp';
import { Comp3GuardService } from './comp3-guard-service';

export const routes: Routes = [
    { path: 'comp1', component: Comp1 },
    { path: 'comp2', component: Comp2 },
    { path: 'comp3/:id', component: Comp3, canActivate: [Comp3GuardService] }, //Path produced is: /comp3/2
    { path: '', redirectTo: 'comp1', pathMatch: 'full'},
    { path : '**', redirectTo: 'ErrorComp' }
];
