import { NgModule }            from '@angular/core';
import { RouterModule }        from '@angular/router';

import { ToolsDepreciateComponent }    from './tools-depreciate.component';
import { ToolsProjectionComponent }  from './tools-projection.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'tools/depreciate', component: ToolsDepreciateComponent },
        { path: 'tools/projection', component: ToolsProjectionComponent }
    ])],
    exports: [RouterModule]
})
export class ToolsRoutingModule { }