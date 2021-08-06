using AcademyC.Week4.Test.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyC.Week4.Test.Core.Repositories
{
    public interface IBusinessLayer
    {
        #region Client

        List<Client> FetchClients();
        Client FetchClientById(int id);
        bool CreateClient(Client newClient);
        bool EditClient(Client editedClient);
        bool DeleteClientById(int idClient);

        #endregion

        #region Order

        List<Order> FetchOrders();
        Order FetchOrderById(int id);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrderById(int idOrder);

        #endregion

    }
}
