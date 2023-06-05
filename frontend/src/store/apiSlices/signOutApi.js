import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const signOutApi = createApi({

  reducerPath: 'signOutApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7106/api'}),

  endpoints: (builder) => ({

    signOutUser: builder.mutation({
      query: () => ({
        url: '/Accounts/signout',
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },   
           
      }),
    }),
    // other endpoints...
  }),
});

export const { useSignOutUserMutation } = signOutApi;
