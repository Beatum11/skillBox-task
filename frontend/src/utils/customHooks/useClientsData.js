import { useGetClientsQuery } from "../../store/apiSlices/clientsApi";

const useClientsData = () => {

    const { data: clients, isLoading, isError, error } = useGetClientsQuery();
  
    //If we're still loading data or if there was an error, return null. 
    //Otherwise, map over the clients data and return the resulting array.
    const finalClients = isLoading || isError ? null : clients.map((client) => (
      <tr key={client.id}>                                          
        <td>{client.id}</td>
        <td>{client.created}</td>
        <td>{client.name}</td>
        <td>{client.message}</td>
        <td>{client.email}</td>
        <td>
        <form>
              <select name="status">
                <option value="inWork" color="black">In work</option>
                <option value="completed">Completed</option>
                <option value="rejected">Rejected</option>
                <option value="canceled">Canceled</option>
              </select>
            </form>
        </td>
      </tr>
    ));
  
    return { finalClients, isLoading, isError, error };
  };
  
  export default useClientsData;