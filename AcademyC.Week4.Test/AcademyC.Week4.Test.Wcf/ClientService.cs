using AcademyC.Week4.Test.Core.BusinessLayer;
using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.CoreEF;
using AcademyC.Week4.Test.CoreEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyC.Week4.Test.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ClientService : IClientService
    {
        private MainBusinessLayer mainBL;

        public ClientService()
        {
            this.mainBL = new MainBusinessLayer(new EFClientRepository(new Context()), new EFOrderRepository(new Context()));
        }

        public bool AddClient(Client item)
        {
            if (item == null)
                return false;
            return mainBL.CreateClient(item);
        }

        public bool DeleteClientById(int id)
        {
            if (id <= 0)
                return false;
            return mainBL.DeleteClientById(id);
        }

        public List<Client> FetchClients()
        {
            return mainBL.FetchClients();
        }

        public Client GetClientById(int id)
        {
            if (id <= 0)
                return null;
            return mainBL.FetchClientById(id);
        }

        public bool UpdateClient(Client item)
        {
            if (item == null)
                return false;
            return mainBL.EditClient(item);
        }
    }
}
