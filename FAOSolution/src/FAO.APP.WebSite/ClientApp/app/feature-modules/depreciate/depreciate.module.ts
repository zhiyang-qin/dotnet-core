import { NgModule }      from '@angular/core';
import { CommonModule }  from '@angular/common';
import { FormsModule }        from '@angular/forms';

import { DepreciateProjectionComponent }    from './depreciate-projection.component';
import { DepreciateMonthlyProjectionComponent }  from './depreciate-monthlyprojection.component';
import { DepreciateService }          from './depreciate.service';
import { DepreciateRoutingModule }   from './depreciate-routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, DepreciateRoutingModule],
    declarations: [DepreciateProjectionComponent, DepreciateMonthlyProjectionComponent],
    //exports: [DepreciateProjectionComponent, DepreciateMonthlyProjectionComponent],
    providers: [DepreciateService]
})
export class DepreciateModule { }