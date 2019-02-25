import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FetchAdvertiserData from './components/FetchAdvertiserData';

export const routes = <Layout>
    <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/FetchAdvertiserData/:startDateIndex?' component={FetchAdvertiserData} />
        <Route path='/FetchBrandData/:startDateIndex?' component={FetchAdvertiserData} />
        <Route path='/fetchproductcategoriesdata/:startDateIndex?' component={FetchAdvertiserData} />
        <Route path='/fetchparentcompaniesdata/:startDateIndex?' component={FetchAdvertiserData} />
    </Switch>
</Layout>;
