using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.Core.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyC.Week4.Test.CoreEF.Repositories
{
    public class EFClientRepository : IClientRepository
    {
        private Context ctx;

        public EFClientRepository(Context context)
        {
            ctx = context;
        }


        public bool Add(Client item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Clients.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;
            try
            {
                Client client = ctx.Clients.Find(id);
                ctx.Clients.Remove(client);
                ctx.SaveChanges();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Client> Fetch()
        {
            try
            {
                return ctx.Clients.ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Client GetById(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                return ctx.Clients.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool Update(Client item)
        {
            if (item == null)
                return false;
            try
            {
                Client cl = ctx.Clients.Find(item.ID);
                if (cl == null)
                    return false;

                cl.ClientCode = item.ClientCode;
                cl.FirstName = item.FirstName;
                cl.LastName = item.LastName;
                cl.Orders = item.Orders;
                ctx.Clients.Update(cl);
                ctx.SaveChanges();
                return true;

            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
