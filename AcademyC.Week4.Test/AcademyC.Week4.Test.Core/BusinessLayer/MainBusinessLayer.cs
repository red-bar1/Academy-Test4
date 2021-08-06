using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyC.Week4.Test.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private IClientRepository clientRepo;
        private IOrderRepository orderRepo;


        public MainBusinessLayer(IClientRepository clientRepo, IOrderRepository orderRepo)
        {
            this.clientRepo = clientRepo;
            this.orderRepo = orderRepo;
        }


        public bool CreateClient(Client newClient)
        {
            if (newClient == null)
                return false;
            return clientRepo.Add(newClient);
        }

        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;
            return orderRepo.Add(newOrder);
        }

        public bool DeleteClientById(int idClient)
        {
            if (idClient <= 0)
                return false;
            return clientRepo.DeleteById(idClient);
        }

        public bool DeleteOrderById(int idOrder)
        {
            if (idOrder <= 0)
                return false;
            return orderRepo.DeleteById(idOrder);
        }

        public bool EditClient(Client editedClient)
        {
            if (editedClient == null)
                return false;
            return clientRepo.Update(editedClient);
        }

        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                return false;
            return orderRepo.Update(editedOrder);
        }

        public Client FetchClientById(int id)
        {
            if (id <= 0)
                return null;
            return clientRepo.GetById(id);
        }

        public List<Client> FetchClients()
        {
            return clientRepo.Fetch();
        }

        public Order FetchOrderById(int id)
        {
            if (id <= 0)
                return null;
            return orderRepo.GetById(id);
        }

        public List<Order> FetchOrders()
        {
            return orderRepo.Fetch();
        }

    }
}
