import CreateActor from "./Actors/CreateActor";
import EditActor from "./Actors/EditActor";
import IndexActor from "./Actors/IndexActors";
import CreateGenre from "./Genres/CreateGenre";
import EditGenre from "./Genres/EditGenre";
import IndexGenres from "./Genres/IndexGenres";
import CreateMovie from "./movies/CreateMovie";
import EditMovie from "./movies/EditMovie";
import FilterMovies from "./movies/FilterMovies";
import LandingPage from "./movies/LandingPage";
import CreateMovieTheater from "./MovieTheater/CreateMovieTheater";
import EditMovieTheater from "./MovieTheater/EditMovieTheater";
import IndexMovieTheater from "./MovieTheater/IndexMovieTheaters";

const routes = [
    {path: '/movietheaters', component: IndexMovieTheater, exact: true},
    {path: '/movietheaters/create', component: CreateMovieTheater},
    {path: '/movietheaters/edit', component: EditMovieTheater},

    {path: '/movies/filter', component: FilterMovies},
    {path: '/movies/create', component: CreateMovie},
    {path: '/movies/edit', component: EditMovie},

    {path: '/actors', component: IndexActor, exact: true},
    {path: '/actors/create', component: CreateActor},
    {path: '/actors/edit', component: EditActor},

    {path: '/genres', component: IndexGenres, exact: true},
    {path: '/genres/create', component: CreateGenre},
    {path: '/genres/edit', component: EditGenre},

    {path: '/', component: LandingPage, exact: true}
];

export default routes;