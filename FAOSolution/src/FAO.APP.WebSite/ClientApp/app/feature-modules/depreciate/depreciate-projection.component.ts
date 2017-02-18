import { Component, OnInit } from '@angular/core';

import { Crisis, DepreciateService }     from './depreciate.service';

import { Hero }    from './hero';

@Component({
    //moduleId: module.id,
    //selector: 'home',
    //template: `
    //<h3 highlight>Depreciate Projection</h3>
    //`
    //templateUrl: './depreciate-projection.component.html',
    template: require('./depreciate-projection.component.html')

})
export class DepreciateProjectionComponent implements OnInit {
    powers = ['Really Smart', 'Super Flexible',
        'Super Hot', 'Weather Changer'];
    model = new Hero(18, 'Dr IQ', this.powers[0], 'Chuck Overstreet');
    submitted = false;

    constructor() { }

    ngOnInit() {
    }

    onSubmit() { this.submitted = true; }
    newHero() {
        this.model = new Hero(42, '', '');
    }
}
