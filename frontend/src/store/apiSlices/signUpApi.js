import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const signUpApi = createApi({

  reducerPath: 'signUpApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7106/api'}),

  endpoints: (builder) => ({

    signUpUser: builder.mutation({
      query: (newUser) => ({
        url: '/Accounts/signup',
        method: 'POST',
        body: newUser,
        headers: {
          'Content-Type': 'application/json'
        },   
           
      }),
    }),
    // other endpoints...
  }),
});

export const { useSignUpUserMutation } = signUpApi;
