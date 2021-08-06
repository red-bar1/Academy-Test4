using AcademyC.Week4.Test.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyC.Week4.Test.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        bool AddClient(Client item);

        [OperationContract]
        bool DeleteClientById(int id);

        [OperationContract]
        List<Client> FetchClients();

        [OperationContract]
        Client GetClientById(int id);

        [OperationContract]
        bool UpdateClient(Client item);
    }

    
    
}
