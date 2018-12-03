using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Rental_Data
{
    [DataContract(Namespace = "http://localhost:8080/")]
    public class Customer
    {
        [DataMember(Order = 1, Name = "ID")]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [DataMember(Order = 4)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 5)]
        public string EmailAddress { get; set; }
    }
}
