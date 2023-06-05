import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const projectsApi = createApi({
    reducerPath: 'projectsApi',
    baseQuery: fetchBaseQuery({baseUrl: 'https://localhost:7106/api'}),
    endpoints: (builder) => ({
        
        getProjects: builder.query({
            query: () => '/Projects'
        }),

        getProject: builder.query({
            query: (id) => `/Projects/${id}`
        }),

        createProject: builder.mutation({
            query: (project) => ({
                url: '/Projects',
                method: 'POST',
                body: project
            }),
        }),

        updateProject: builder.mutation({
            query: (project) => ({
                url: `/Projects/${project.id}`,
                method: 'PUT',
                body: project
            }),
        }),

        deleteProject: builder.mutation({
            query: (id) => ({
                url: `/Projects/${id}`,
                method: 'DELETE'
            }),
        })
    }),
});

export const {
    useGetProjectsQuery,
    useGetProjectQuery,
    useCreateProjectMutation,
    useUpdateProjectMutation,
    useDeleteProjectMutation
} = projectsApi;
