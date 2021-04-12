import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/app/shared/interfaces/movie';
import { MovieService } from 'src/app/shared/services/movie.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  movies: IMovie[] = [];
  search = '';

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {}

  searchMovies(): void {
    this.movieService
      .searchMovieList(this.search)
      .subscribe((movies) => (this.movies = movies));
  }
}
