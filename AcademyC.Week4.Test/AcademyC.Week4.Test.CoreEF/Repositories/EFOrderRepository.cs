using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.Core.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyC.Week4.Test.CoreEF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private Context ctx;

        public EFOrderRepository(Context context)
        {
            ctx = context;
        }


        public bool Add(Order item)
        {
            if (item == null)
                return false;
            try
            {
                ctx.Orders.Add(item);
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
                Order order = ctx.Orders.Find(id);
                ctx.Orders.Remove(order);
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

        public List<Order> Fetch()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                return ctx.Orders.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Order item)
        {
            if (item == null)
                return false;
            try
            {
                Order or = ctx.Orders.Find(item.ID);
                if (or == null)
                    return false;

                or.OrderCode = item.OrderCode;
                or.OrderDate = item.OrderDate;
                or.ProductCode = item.ProductCode;
                or.Amount = item.Amount;
                //nota: non aggiungo l'update del Client perché
                //immagino che andrebbe fatto un ClientContract
                //nel client delle API per gestire questa entità,
                //che dobbiamo usare solo per gli ordini
                //or.Client = item.Client; 
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
