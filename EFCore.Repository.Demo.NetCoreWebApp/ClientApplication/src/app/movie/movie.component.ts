import { Component, OnInit } from '@angular/core';
import { MovieService } from './shared/services/movie.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {

  constructor(private movieService: MovieService) {
    this.movies = this.movieService.getMovies();
  }

  movies: Observable<Movie[]>;


  ngOnInit() {
  }

}


export class Movie {
  id: number;
  title: string;
  releaseYear: number;
  summary: string;
}
