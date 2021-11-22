import React, { useEffect, useState } from 'react';
import './App.css';
import Menu from './Menu';
import { BrowserRouter, Switch, Route, Link } from 'react-router-dom';
import IndexGenres from './Genres/IndexGenres';
import LandingPage from './movies/LandingPage';
import routes from './route-config';

function App() {
  

  return (
    <BrowserRouter>
    <Menu />
    <div className="container"> 
      {routes.map(route =>
        <Route key={route.path} path={route.path} exact={route.exact}>
          <route.component />
          </Route>)}
    </div>
    </BrowserRouter>
  );
}

export default App;
