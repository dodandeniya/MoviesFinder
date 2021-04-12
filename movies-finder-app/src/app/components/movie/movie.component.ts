import { Component, OnInit, Input } from '@angular/core';
import { IMovie } from 'src/app/shared/interfaces/movie';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss'],
})
export class MovieComponent implements OnInit {
  @Input() movie?: IMovie;

  constructor() {}

  ngOnInit(): void {}
}
