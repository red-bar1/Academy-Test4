using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyC.Week4.Test.Core.Models
{
    
    public class Order
    {
        
        public int ID { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public string OrderCode { get; set; }
        
        public string ProductCode { get; set; }
        
        public decimal Amount { get; set; }

        public Client Client { get; set; }

    }
}
