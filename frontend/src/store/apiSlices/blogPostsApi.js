import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const blogPostsApi = createApi({
    reducerPath: 'blogPostsApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7106/api'}),
    endpoints: (builder) => ({
        
        getBlogPosts: builder.query({
            query: () => '/BlogPosts'
        }),

        getBlogPost: builder.query({
            query: (id) => `/BlogPosts/${id}`
        }),

        createBlogPosts: builder.mutation({
            query: (blogPost) => ({
                url: '/BlogPosts',
                method: 'POST',
                body: blogPost
            }),
        }),

        updateBlogPost: builder.mutation({
            query: (blogPost) => ({
                url: `/BlogPosts/${blogPost.id}`,
                method: 'PUT',
                body: blogPost
            }),
        }),

        deleteBlogPosts: builder.mutation({
            query: (id) => ({
                url: `/BlogPosts/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetBlogPostsQuery,
    useGetBlogPostQuery,
    useCreateBlogPostsMutation,
    useUpdateBlogPostMutation,
    useDeleteBlogPostsMutation
} = blogPostsApi;
