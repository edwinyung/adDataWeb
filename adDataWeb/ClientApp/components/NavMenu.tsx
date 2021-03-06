import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={'/'}>adDataWeb</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink exact to={'/'} activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchadvertiserdata/1'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Full list of Advertiser Data
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchbranddata/1'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Selected Brands Data
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchproductcategoriesdata/1'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Selected Product Categories Data
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchparentcompaniesdata/1'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Selected Parent Companies Data
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
