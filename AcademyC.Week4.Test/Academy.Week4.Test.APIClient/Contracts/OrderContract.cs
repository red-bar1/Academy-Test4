using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Week4.Test.APIClient.Contracts
{
    class OrderContract
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderCode { get; set; }

        public string ProductCode { get; set; }

        public decimal Amount { get; set; }

        
    }
}
