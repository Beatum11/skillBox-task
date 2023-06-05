import React, { useState } from "react";
import useClientsData from "../../utils/customHooks/useClientsData";
import { useGetTodaysClientsQuery } from "../../store/apiSlices/todaysFilterApi";
import "../../css-files/css-admin/admin-panel.css";

const AdminPanel = () => {
  const { finalClients, isLoading, isError, error } = useClientsData();
  const { data: todaysClients } = useGetTodaysClientsQuery();
  console.log(todaysClients);



  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>{error.message}</div>;
  }

  const amount = finalClients ? finalClients.length : 0;

  return (
    <>
    <button>Todays Filter</button>
    <div className="adminPanel-container">
      <p>Total applications received: {amount}</p>
      <table className="adminPanel-table">
        <thead>
          <tr>
            <th>App. ID</th>
            <th>Application Time</th>
            <th>Name</th>
            <th>Message</th>
            <th>Email</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>{todaysClients}</tbody>
      </table>
    </div>
    </>
    
  );
};

export default AdminPanel;
