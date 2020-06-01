import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { Response, ResponseSearchModel } from '../models/response';
import { QueryOptions } from '../serializer/queryoptions.serializer';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ResponseSerializer } from '../serializer/response.serializer';


@Injectable()
export class Service {
    public config: string = 'https://localhost:44381/api';
    public endpoint: string = 'product';
    public item : any;
    public listOfItems : any;
    constructor(private http: HttpClient,private serializer: ResponseSerializer,) { }

    getResponse(): Observable<Response> {
        this.item = this.http.get<Response>(`${this.config}/${this.endpoint}`, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          observe: 'response'
        }).
          pipe(
            map(data => this.serializer.fromJson(data))
          );
        return this.item;
      }
      getResponseList(): Observable<Response> {
        this.listOfItems = this.http.get<Response[]>(`${this.config}/${this.endpoint}`, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          observe: 'response'
        }).
          pipe(
          map(data => this.serializer.getFullResponsefromJson(data))
          );
        return this.listOfItems;
      }
    getAll() {
        return this.http.get<User[]>(`${this.config}/users`);
    }

    getById(id: number) {
        return this.http.get(`${this.config}/users/` + id);
    }

    register(user: User) {
        return this.http.post(`${this.config}/users/register`, user);
    }

    update(user: User) {
        return this.http.put(`${this.config}/users/` + user.id, user);
    }

    delete(id: number) {
        return this.http.delete(`${this.config}/users/` + id);
    }
}