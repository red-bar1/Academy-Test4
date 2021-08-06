using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyC.Week4.Test.Core.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ClientCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }

    }
}
