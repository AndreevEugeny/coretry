import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />

            <form method="POST" enctype="multipart/form-data" action="weatherforecast/UploadFile" >

                <input name="uFile" type="file" />
                <input type="submit" value="Upload" />
            </form>
      </Layout>
    );
  }
}
