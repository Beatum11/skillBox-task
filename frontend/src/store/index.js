import { configureStore} from "@reduxjs/toolkit";
import { projectsApi } from "./apiSlices/projectsApi";
import { servicesApi } from "./apiSlices/servicesApi";
import { blogPostsApi } from "./apiSlices/blogPostsApi";
import { clientsApi } from "./apiSlices/clientsApi";
import { signUpApi } from './apiSlices/signUpApi';
import { signOutApi } from "./apiSlices/signOutApi";
import { signInApi } from './apiSlices/signInApi';
import { todaysFilterApi } from "./apiSlices/todaysFilterApi";

const store = configureStore({
    reducer : {
        [projectsApi.reducerPath] : projectsApi.reducer,
        [servicesApi.reducerPath] : servicesApi.reducer,
        [blogPostsApi.reducerPath] : blogPostsApi.reducer,
        [clientsApi.reducerPath] : clientsApi.reducer,
        [signUpApi.reducerPath] : signUpApi.reducer,
        [signOutApi.reducerPath] : signOutApi.reducer,
        [signInApi.reducerPath] : signInApi.reducer,
        [todaysFilterApi.reducerPath] : todaysFilterApi.reducer
    }, 
    middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware({thunk: true}).concat(projectsApi.middleware, 
                                                   servicesApi.middleware,
                                                   blogPostsApi.middleware,
                                                   clientsApi.middleware,
                                                   signUpApi.middleware,
                                                   signOutApi.middleware,
                                                   signInApi.middleware,
                                                   todaysFilterApi.middleware),
});

export default store;