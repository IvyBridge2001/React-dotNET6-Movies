import React, { useEffect, useState } from 'react';
import './App.css';
import Menu from './Menu';
import { landingPageDTO, movieDTO } from './movies/movies.model';
import MoviesList from './movies/MoviesList';
import Button from './utils/Button';
import { BrowserRouter, Switch, Route, Link } from 'react-router-dom';
import IndexGenres from './Genres/IndexGenres';

function App() {
  const [movies, setMovies] = useState<landingPageDTO>({});

  useEffect(() => {
    const timerId = setTimeout(()=>{
      setMovies({
        inTheaters: [
          {
            id: 1,
            title: 'Spider-Man: Far From Home',
            poster: 'https://upload.wikimedia.org/wikipedia/en/b/bd/Spider-Man_Far_From_Home_poster.jpg'
          },
          {
            id: 2,
            title: 'Luca',
            poster: 'https://upload.wikimedia.org/wikipedia/en/3/33/Luca_%282021_film%29.png'
          }
          ],
          upcomingReleases: [
            {
              id: 3,
              title: 'Soul',
              poster: 'https://upload.wikimedia.org/wikipedia/en/9/95/Soul_Poster.jpeg'
            }
            ]
      })
    }, 1000);

    return () => clearTimeout(timerId)
  })


  return (
    <BrowserRouter>
    <Menu />
    <div className="container"> 
      <Switch>
        <Route exact path="/">
          <Button>Whatever Text</Button>
          <h3>In Theaters</h3>
          <MoviesList movies={movies.inTheaters}/>

          <h3>In Theaters</h3>
          <MoviesList movies={movies.upcomingReleases}/>
        </Route>

        <Route path="/genres">
          <IndexGenres />
        </Route>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
