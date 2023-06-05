import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const servicesApi = createApi({
    reducerPath: 'servicesApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7106/api'}),
    endpoints: (builder) => ({
        getServices: builder.query({
            query: () => '/Services'
        }),

        getService: builder.query({
            query: (id) => `/Services/${id}`
        }),

        createService: builder.mutation({
            query: (service) => ({
                url: '/Services',
                method: 'POST',
                body: service
            }),
        }),

        updateService: builder.mutation({
            query: (service) => ({
                url: `/Services/${service.id}`,
                method: 'PUT',
                body: service
            }),
        }),

        deleteService: builder.mutation({
            query: (id) => ({
                url: `/Services/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetServicesQuery,
    useGetServiceQuery,
    useCreateServiceMutation,
    useUpdateServiceMutation,
    useDeleteServiceMutation
} = servicesApi;
