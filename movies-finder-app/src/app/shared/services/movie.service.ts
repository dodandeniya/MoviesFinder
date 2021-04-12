import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IMovie } from '../interfaces/movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private movieUrl = environment.movieApiUrl;

  constructor(private http: HttpClient) {}

  searchMovieList(search: string): Observable<IMovie[]> {
    const params = new HttpParams().set('Name', search);

    return this.http
      .get<IMovie[]>(this.movieUrl, { params })
      .pipe(catchError(this.handleError<IMovie[]>('getMovies', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
