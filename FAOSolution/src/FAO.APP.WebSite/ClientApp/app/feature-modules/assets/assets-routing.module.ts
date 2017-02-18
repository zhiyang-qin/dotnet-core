import { NgModule }            from '@angular/core';
import { RouterModule }        from '@angular/router';

import { AssetsListComponent }    from './assets-list.component';
import { AssetsUpdateComponent }  from './assets-update.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'assets/list', component: AssetsListComponent },
        { path: 'assets/:id', component: AssetsUpdateComponent }
    ])],
    exports: [RouterModule]
})
export class AssetsRoutingModule { }