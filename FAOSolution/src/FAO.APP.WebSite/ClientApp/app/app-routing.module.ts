import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PageNotFoundComponent } from './components/not-found.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    //{
    //    path: 'depreciate', loadChildren: () => new Promise(resolve => {
    //        (require as any).ensure([], require => {
    //            resolve(require('app/depreciate/depreciate.module').DepreciateModule);
    //        })
    //    })
    //},

    //{ path: 'depreciate01', loadChildren: () => System.import('app/depreciate/depreciate.module').then(mod => mod.ModuleName),

    //{ path: 'depreciate', loadChildren: 'app/depreciate/depreciate.module#DepreciateModule' },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent  }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

export const routedComponents = [HomeComponent, CounterComponent, FetchDataComponent, PageNotFoundComponent];