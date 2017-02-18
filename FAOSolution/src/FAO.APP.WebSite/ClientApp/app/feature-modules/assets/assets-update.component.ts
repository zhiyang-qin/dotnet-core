import { Component, OnInit } from '@angular/core';

import { AssetsService }     from './assets.service';
//import { Asset, AssetsService }     from './assets.service';

@Component({
    template: require('./assets-update.component.html')
})
export class AssetsUpdateComponent implements OnInit {

    constructor() { }

    ngOnInit() {
    }
}
