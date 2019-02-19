import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as AdvertisersState from '../store/Advertisers';
import index from 'redux-thunk';

// At runtime, Redux will merge together...
type AdvertisersProps =
    AdvertisersState.AdvertisersState        // ... state we've requested from the Redux store
    & typeof AdvertisersState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{
        startDateIndex: string
    }>; // ... plus incoming routing parameters

class FetchAdvertiserData extends React.Component<AdvertisersProps, {}> {

    // This method runs when the component is first added to the page
    constructor(props: AdvertisersProps) {
        super(props)
        let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        this.props.requestAdvertisers(startDateIndex);
    }

    componentDidUpdate(prevProps: AdvertisersProps) {
        // This method runs when incoming props (e.g., route params) change
        if (prevProps.match.params !== this.props.match.params) {
            let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
            this.props.requestAdvertisers(startDateIndex);
        }
    }

    public render() {
        return <div>
            <h1>Full List Advertisers</h1>
            <p>Displays everything.</p>
            {this.renderAdvertisersTable()}
            {this.renderPagination()}
        </div>;
    }

    private renderAdvertisersTable() {
        return <table className='table'>
            <thead>
                <tr>
                    <th>AdPages</th>
                    <th>Brand Id</th>
                    <th>Brand Name</th>
                    <th>Est Print Spend</th>
                    <th>Month</th>
                    <th>Parent Company</th>
                    <th>Parent Company Id</th>
                    <th>Product Category</th>
                    <th>Publication Id</th>
                    <th>Publication Name</th>
                </tr>
            </thead>
            <tbody>
                {this.props.advertisers.map((el, index) =>
                    <tr key={index}>
                        <td>{el.adPages}</td>
                        <td>{el.brandId}</td>
                        <td>{el.brandName}</td>
                        <td>{el.estPrintSpend}</td>
                        <td>{el.month}</td>
                        <td>{el.parentCompany}</td>
                        <td>{el.parentCompanyId}</td>
                        <td>{el.productCategory}</td>
                        <td>{el.publicationId}</td>
                        <td>{el.publicationName}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }

    private renderPagination() {
        let prevStartDateIndex = (this.props.startDateIndex || 0) - 50;
        let nextStartDateIndex = (this.props.startDateIndex || 0) + 50;

        return <p className='clearfix text-center'>
            <Link className='btn btn-default pull-left' to={`/fetchadvertiserdata/${prevStartDateIndex}`}>Previous</Link>
            <Link className='btn btn-default pull-right' to={`/fetchadvertiserdata/${nextStartDateIndex}`}>Next</Link>
            {this.props.isLoading ? <span>Loading...</span> : []}
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.advertisers, // Selects which state properties are merged into the component's props
    AdvertisersState.actionCreators                 // Selects which action creators are merged into the component's props
)(FetchAdvertiserData) as typeof FetchAdvertiserData;
