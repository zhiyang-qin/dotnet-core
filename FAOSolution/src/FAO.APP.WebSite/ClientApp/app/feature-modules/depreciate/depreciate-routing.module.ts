import { NgModule }            from '@angular/core';
import { RouterModule }        from '@angular/router';

import { DepreciateProjectionComponent }    from './depreciate-projection.component';
import { DepreciateMonthlyProjectionComponent }  from './depreciate-monthlyprojection.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'depreciate/projection', component: DepreciateProjectionComponent },
        { path: 'depreciate/monthlyprojection', component: DepreciateMonthlyProjectionComponent }
    ])],
    exports: [RouterModule]
})
export class DepreciateRoutingModule { }