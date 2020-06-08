import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';


@Injectable()
export class UserService {
    public config: string = 'https://localhost:44381/api';
    constructor(private http: HttpClient) { }

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