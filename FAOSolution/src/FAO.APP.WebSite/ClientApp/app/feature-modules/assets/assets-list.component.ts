import { Component, OnInit } from '@angular/core';
import { AssetsService }     from './assets.service';
import {Asset} from '../../models/asset';

@Component({
    template: require('./assets-list.component.html')

})
export class AssetsListComponent implements OnInit {

    assets: Asset[] = [];

    constructor(private assetsService: AssetsService) { }

    ngOnInit() {
        this.getAssetList();
    }

    getAssetList() {
        this.assetsService.getAssetList()
            .subscribe(
            items => {
                this.assets = items;
            },
            error => { console.log(error); });
    }

}
