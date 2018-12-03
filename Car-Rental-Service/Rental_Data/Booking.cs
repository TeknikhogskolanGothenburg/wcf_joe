using System;
using System.Runtime.Serialization;

namespace Rental_Data
{
    [DataContract(Namespace = "http://localhost:8080/")]
    public class Booking
    {
        [DataMember(Order = 1, Name = "ID")]
        public string Id { get; set; }

        [DataMember(Order = 2)]
        public Car RentalCar { get; set; }

        [DataMember(Order = 3)]
        public Customer Renter { get; set; }

        [DataMember(Order = 4)]
        public DateTime StartTime { get; set; }

        [DataMember(Order = 5)]
        public DateTime EndTime { get; set; }

        [DataMember(Order = 6)]
        public bool IsReturned { get; set; }
    }
}
