import { Component, OnInit } from '@angular/core';

import { RuleItemDto, DepreciableBookDto, PeriodDeprItemDto, ToolsService }     from './tools.service';

import { Book }    from './book';

@Component({
    template: require('./tools-projection.component.html')
})
export class ToolsProjectionComponent implements OnInit {
    propTypeList: RuleItemDto[];
    deprMethodList: RuleItemDto[];
    estLifeList: RuleItemDto[];

    prdDeprItems: PeriodDeprItemDto[];

    errorMessage: string;
    powers = ['Really Smart', 'Super Flexible', 'Super Hot', 'Weather Changer'];
    model = new Book('P', '2000-01-01', 10000.00, 'MF200', '10 yrs 00 mns');

    constructor(private toolsService: ToolsService) { }

    ngOnInit() {
        this.getPropTypeList();
    }

    PostProject() {
        let deprBook = new DepreciableBookDto("P", "2010-01-01", 10000.00, "SL", 0, 10, 0, 0, 0, 0, 0, "", "2015-12-31", "1899-12-31", "1899-12-31");

        this.toolsService.postProject(deprBook)
            .subscribe(
            items => {
                this.prdDeprItems = items;
            },
            error => { console.log(error); });

    }

    getPropTypeList() {
        this.toolsService.getPropTypeList()
            .subscribe(
            ruleItems => {
                this.propTypeList = ruleItems;
            },
            error => { console.log(error); });
    }

    getDeprMethodList(propType:string, pisDate:string) {
        this.toolsService.getDeprMehodList(propType, pisDate)
            .subscribe(
            ruleItems => {
                this.deprMethodList = ruleItems;
            },
            error => { console.log(error); });
    }

    getEstLifeList(propType: string, pisDate: string, deprMethod:string) {
        this.toolsService.getEstLifeList(propType, pisDate, deprMethod)
            .subscribe(
            ruleItems => {
                this.estLifeList = ruleItems;
            },
            error => { console.log(error); });
    }

    onBlur_propType() {

    }

    onBlur_pisDate() {
        this.getDeprMethodList(this.model.propType, this.model.pisDate);
    }

    onBlur_acqValue() {

    }

    onBlur_deprMethod() {
        this.getEstLifeList(this.model.propType, this.model.pisDate, this.model.deprMethod);
    }

    onBlur_estLife() {

    }

    onSubmit() {
        this.PostProject();
    }
}
