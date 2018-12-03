using System.Runtime.Serialization;

namespace Rental_Data
{
    [DataContract(Namespace = "http://localhost:8080/")]
    public class Car
    {
        [DataMember(Order = 1, Name = "REGNUMBER")]
        public string RegNumber { get; set; }  //ändrar till String, regnumber har bokstäver

        [DataMember(Order = 2)]
        public string Brand { get; set; }

        [DataMember(Order = 3)]
        public int Year { get; set; }

        [DataMember(Order = 4)]
        public string Model { get; set; }

        [DataMember(Order = 5)]
        public bool IsRented { get; set; }
    }
}