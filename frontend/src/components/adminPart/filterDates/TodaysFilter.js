import React from 'react';

import { useGetTodaysClientsQuery } from '../../../store/apiSlices/todaysFilterApi';

const TodaysFilter = () => {

  const { data: todaysClients, isLoading, isError, error } = useGetTodaysClientsQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>{error.message}</div>;
  }

  return (
    <div>
        <button>Today</button>
    </div>
  )

}

export default TodaysFilter;