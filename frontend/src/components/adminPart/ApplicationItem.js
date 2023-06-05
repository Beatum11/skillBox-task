import React from "react";

import "../../css-files/css-admin/application-item.css";

const ApplicationItem = ({ id = '1', name='Test name', date ='29.04.23',
                           message='here is my message', email='aaaa@gmail.com'}) => {
  return (
    <div className="application-container">
      <ul>
        <li>{id}</li>
        <li>{name}</li>
        <li>{date}</li>
        <li>{message}</li>
        <li>{email}</li>
        <li>
          <form>
            <select name="status">
              <option value="inWork" color="black">In work</option>
              <option value="completed">Completed</option>
              <option value="rejected">Rejected</option>
              <option value="canceled">Canceled</option>
            </select>
          </form>
        </li>
      </ul>
    </div>
  );
};

export default ApplicationItem;
