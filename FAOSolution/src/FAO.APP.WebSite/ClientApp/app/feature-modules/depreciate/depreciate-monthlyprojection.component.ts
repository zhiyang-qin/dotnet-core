import { Component, OnInit } from '@angular/core';

import { Crisis, DepreciateService }     from './depreciate.service';

@Component({
    template: `
    <h3 highlight>Depreciate Monthly Projection</h3>
    `
})
export class DepreciateMonthlyProjectionComponent implements OnInit {

    constructor() { }

    ngOnInit() {
    }
}
