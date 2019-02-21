import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FetchAdvertiserData from './components/FetchAdvertiserData';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/FetchAdvertiserData/:startDateIndex?' component={FetchAdvertiserData} />
    <Route path='/FetchBrandData/:startDateIndex?' component={FetchAdvertiserData} />
</Layout>;
