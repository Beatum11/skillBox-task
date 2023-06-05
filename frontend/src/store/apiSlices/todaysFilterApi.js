import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const todaysFilterApi = createApi({
    reducerPath: 'todaysFilterApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7106/api'}),
    endpoints: (builder) => ({
        getTodaysClients: builder.query({
            query: () => '/DatesFilter/today'
        })
        })
});

export const { useGetTodaysClientsQuery } = todaysFilterApi;
