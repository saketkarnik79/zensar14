import { configureStore } from "@reduxjs/toolkit";
import { combineReducers } from "redux";

import { type ProjectState } from "./projects/state/projectTypes";
import { projectReducer } from "./projects/state/projectReducer";
import { initialProjectState } from "./projects/state/projectReducer";

//Define reducers
const rootReducer = combineReducers({
    projectState: projectReducer
});

//Define the type for the app state
// export type AppState = ReturnType<typeof rootReducer>;
export type AppState = {projectState: ProjectState};

export const initialAppState: AppState = {
    projectState: initialProjectState
};

//Create the store using Redux toolkit
export const store = configureStore({
    reducer: rootReducer,
    preloadedState: {}
});