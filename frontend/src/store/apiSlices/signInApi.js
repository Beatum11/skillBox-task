import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const signInApi = createApi({

  reducerPath: 'signInApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7106/api'}),

  endpoints: (builder) => ({

    signInUser: builder.mutation({
      query: (newUser) => ({
        url: '/Accounts/signin',
        method: 'POST',
        body: newUser,
        headers: {
          'Content-Type': 'application/json'
        },   
           
      }),
    }),
  }),
});

export const { useSignInUserMutation } = signInApi;
