import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})
export class DataService {
    
    constructor(private http: HttpClient) { }

    getCustomers() {
        return this.http.get('http://localhost:5000/api/async/customers')
            .pipe(
                   catchError((err) => {
                       const msg = 'Error getting customers';
                       console.log(msg);
                       return Observable.throw(msg);
                   })
                );
    }

}