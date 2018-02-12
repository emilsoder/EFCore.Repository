import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MovieComponent } from './movie/movie.component';
import { CoreModule } from './core/core.module';
import { MovieService } from './movie/shared/services/movie.service';

const appRoutes: Routes = [
  { path: 'movies', component: MovieComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    MovieComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    MovieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
