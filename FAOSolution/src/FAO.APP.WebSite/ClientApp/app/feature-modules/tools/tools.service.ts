import { Injectable }              from '@angular/core';
import { Http, Response, URLSearchParams }          from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

export class RuleItemDto {
    constructor(public id: number, public name: string, public value: string) { }
}

export class DepreciableBookDto {
    constructor(
        public PropertyType: string,
        public PlaceInServiceDate: string,
        public AcquiredValue: number,
        public DepreciateMethod: string,
        public DepreciatePercent: number,
        public EstimatedLife: number,
        public Section179: number,
        public ITCAmount: number,
        public ITCReduce: number,
        public SalvageDeduction: number,
        public Bonus911Percent: number,
        public Convention: string,
        public RunDate: string,
        public MPStartDate: string,
        public MPEndDate: string)
    { }
}

export class PeriodDeprItemDto {
    constructor(
        public FiscalYearStartDate: string,
        public FiscalYearEndDate: string,

        public FiscalYearBeginAccum: number,
        public FiscalYearEndAccum: number,
        public FiscalYearDeprAmount: number,

        public PeriodStartDate: string,
        public PeriodEndDate: string,
        public PeriodBeginAccum: number,
        public PeriodEndAccum: number,
        public PeriodDeprAmount: number,
        public CalcFlags: string,
        public AdjustmentAmt: number)
    { }
}


@Injectable()
export class ToolsService {
    private propertyTypeListUrl = 'api/rules/proptypes';
    private deprMehodListtUrl = 'api/rules/deprmethods';
    private estLifeListUrl = 'api/rules/estlifes';

    private projectUrl = 'api/calcs/project';


    constructor(private http: Http) { }

    getPropTypeList(): Observable<RuleItemDto[]> {
        return this.http.get(this.propertyTypeListUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getDeprMehodList(propType: string, pisDate: string): Observable<RuleItemDto[]> {
        let params: URLSearchParams = new URLSearchParams();
        params.set('propertyType', propType);
        params.set('pisDate', pisDate);

        return this.http.get(this.deprMehodListtUrl, { search: params })
            .map(this.extractData)
            .catch(this.handleError);
    }

    getEstLifeList(propType: string, pisDate: string, deprMethod:string): Observable<RuleItemDto[]> {
        let params: URLSearchParams = new URLSearchParams();
        params.set('propertyType', propType);
        params.set('pisDate', pisDate);
        params.set('deprMethod', deprMethod);

        return this.http.get(this.estLifeListUrl, { search: params })
            .map(this.extractData)
            .catch(this.handleError);
    }


    postProject(deprBook: DepreciableBookDto): Observable<PeriodDeprItemDto[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.projectUrl, deprBook, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}

