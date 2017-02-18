import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import {AppSettings} from '../../app-settings';
import {Asset} from '../../models/asset';

@Injectable()
export class AssetsService {
    private assetListUrl = 'api/' + AppSettings.TENANT_ID + '/companies/' + AppSettings.COMPANY_ID + '/assets';

    constructor(private http: Http) { }

    getAssetList(): Observable<Asset[]> {
        return this.http.get(this.assetListUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    createAsset(asset: Asset): Observable<Asset> {

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post(this.assetListUrl, JSON.stringify(asset), { headers: headers })
            .map(this.extractData)
            .catch(this.handleError);
    }

    updateAsset(asset: Asset): Observable<void> {

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.put(this.assetListUrl + '/' + asset.assetId, JSON.stringify(asset), { headers: headers })
            .map(this.extractData)
            .catch(this.handleError);
    }

    deleteAsset(id: number): Observable<void> {
        return this.http.delete(this.assetListUrl + '/' + id)
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

