import { NgModule }      from '@angular/core';
import { CommonModule }  from '@angular/common';
import { FormsModule }        from '@angular/forms';

import { ToolsDepreciateComponent }    from './tools-depreciate.component';
import { ToolsProjectionComponent }  from './tools-projection.component';
import { ToolsService }          from './tools.service';
import { ToolsRoutingModule }   from './tools-routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, ToolsRoutingModule],
    declarations: [ToolsDepreciateComponent, ToolsProjectionComponent],
    providers: [ToolsService]
})
export class ToolsModule { }