import { Injectable, Output, EventEmitter, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { User } from '../models/user';
import { Response, ResponseSearchModel, ResponseEditModel } from '../models/response';
import { QueryOptions } from '../serializer/queryoptions.serializer';
import { Observable, BehaviorSubject, Subject, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ResponseSerializer } from '../serializer/response.serializer';


@Injectable()
export class Service<T extends Response, K extends ResponseEditModel , L extends ResponseSearchModel> {
    public config: string = 'https://localhost:44381/api';
    public item : any;
    public listOfItems : any;
    public countdown: number = 0;
    
    private countdownEndSource = new Subject<void>();
    private init: number = 0;
    private countdownSource = new BehaviorSubject<number>(0);
    private countdownTimerRef: any = null;
    public countdownEnd$ = this.countdownEndSource.asObservable();

  @Output() onServiceComplete: EventEmitter<string> = new EventEmitter<string>();
  
    constructor(private http: HttpClient,private serializer: ResponseSerializer,@Inject(String)private endpoint: string) { }

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
      handleError(error: HttpErrorResponse) {
        let errorMessage = 'Unknown error!';
        if (error.error instanceof ErrorEvent) {
          // Client-side errors
          errorMessage = `Error: ${error.error.message}`;
        } else {
          // Server-side errors
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        window.alert(errorMessage);
        return throwError(errorMessage);
      }
      getResponseList(): Observable<Response> {
        this.listOfItems = this.http.get<Response[]>(`${this.config}/${this.endpoint}`, {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          observe: 'response'
        }).
          pipe(
          map(data => this.serializer.getFullResponsefromJson(data)),catchError(this.handleError)
          );
        return this.listOfItems;
      }
      public destroy() {
        //clean timeout reference
      }
      restartCountdown(init?) {
        if (init) {
          this.init = init;
        }
        if (this.init && this.init > 0) {
          this.clearTimeout();
          this.countdownSource.next(this.init);
          this.doCountdown();
        }
      }
      private doCountdown() {
        if (this.countdownSource.getValue() > 0) {
          this.countdownTimerRef = setTimeout(() => {
            this.countdownSource.next(this.countdownSource.getValue() - 1);
            this.processCountdown();
          }, 1000);
        }
      }
      private processCountdown() {
        if (this.countdown == 0) {
          this.countdownEndSource.next();
        }
        else {
          this.doCountdown();
        }
      }
      private clearTimeout() {
        //remove countdown reference
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