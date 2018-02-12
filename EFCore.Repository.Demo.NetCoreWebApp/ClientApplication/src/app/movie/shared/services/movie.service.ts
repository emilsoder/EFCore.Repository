import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MovieService {

  constructor(private httpClient: HttpClient) { }

  getMovies(): Observable<any> {
    return this.httpClient.get("/api/movie/list");
  }

}
