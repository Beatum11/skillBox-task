import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const clientsApi = createApi({
    reducerPath: 'clientsApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7106/api'}),
    endpoints: (builder) => ({
        
        getClients: builder.query({
            query: () => '/Clients'
        }),

        getClient: builder.query({
            query: (id) => `/Clients/${id}`
        }),

        createClient: builder.mutation({
            query: (client) => ({
                url: '/Clients',
                method: 'POST',
                body: client
            }),
        }),

        updateClient: builder.mutation({
            query: (client) => ({
                url: `/Clients/${client.id}`,
                method: 'PUT',
                body: client
            }),
        }),

        deleteClient: builder.mutation({
            query: (id) => ({
                url: `/Clients/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetClientsQuery,
    useGetClientQuery,
    useCreateClientMutation,
    useUpdateClientMutation,
    useDeleteClientMutation
} = clientsApi;
