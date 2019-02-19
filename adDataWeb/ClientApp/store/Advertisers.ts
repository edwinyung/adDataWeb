import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface AdvertisersState {
    isLoading: boolean;
    startDateIndex?: number;
    advertisers: Advertiser[];
}

export interface Advertiser {
    month: string;
    publicationId: number;
    publicationName: string;
    parentCompany: string;
    parentCompanyId: number;
    brandName: string;
    brandId: number;
    productCategory: string;
    adPages: number;
    estPrintSpend: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestFullListAdvertisersAction {
    type: 'REQUEST_FULL_LIST_ADVERTISERS';
    startDateIndex: number;
}

interface ReceiveFullListAdvertisersAction {
    type: 'RECEIVE_FULL_LIST_ADVERTISERS';
    startDateIndex: number;
    advertisers: Advertiser[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestFullListAdvertisersAction | ReceiveFullListAdvertisersAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestAdvertisers: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (startDateIndex !== getState().advertisers.startDateIndex) {
            let fetchTask = fetch(`api/AdData/FullListAdvertisers?page=${startDateIndex}&take=${50}&sort='ddf'`)
                .then(response => response.json() as Promise<Advertiser[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_FULL_LIST_ADVERTISERS', startDateIndex: startDateIndex, advertisers: data });
                }).catch(response => console.log(response))

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_FULL_LIST_ADVERTISERS', startDateIndex: startDateIndex });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: AdvertisersState = { advertisers: [], isLoading: false };

export const reducer: Reducer<AdvertisersState> = (state: AdvertisersState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_FULL_LIST_ADVERTISERS':
            return {
                startDateIndex: action.startDateIndex,
                advertisers: state.advertisers,
                isLoading: false
            };
        case 'RECEIVE_FULL_LIST_ADVERTISERS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    advertisers: action.advertisers,
                    isLoading: false
                };
            }
            break;
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
