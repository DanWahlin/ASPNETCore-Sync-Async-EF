import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DataService {
    
    constructor(private http: Http) { }

    getCustomers() {
        return this.http.get('http://localhost:5000/api/async/customers')
                   .map((res: Response) => res.json())
                   .catch((err) => {
                       const msg = 'Error getting customers';
                       console.log(msg);
                       return Observable.throw(msg);
                   });
    }

}