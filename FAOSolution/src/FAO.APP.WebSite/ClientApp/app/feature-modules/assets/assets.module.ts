import { NgModule }      from '@angular/core';
import { CommonModule }  from '@angular/common';
import { FormsModule }        from '@angular/forms';

import { AssetsListComponent }    from './assets-list.component';
import { AssetsUpdateComponent }  from './assets-update.component';
import { AssetsService }          from './assets.service';
import { AssetsRoutingModule }   from './assets-routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, AssetsRoutingModule],
    declarations: [AssetsListComponent, AssetsUpdateComponent],
    providers: [AssetsService]
})
export class AssetsModule { }