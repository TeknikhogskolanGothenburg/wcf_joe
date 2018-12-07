using System.Runtime.Serialization;
using System.ServiceModel;

namespace Rental_Data
{
    [MessageContract(IsWrapped = true,
        WrapperName = "CarRequestObject",
        WrapperNamespace = "http://localhost:8080/Car")]
    public class CarRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Car")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Car")]
        public string CarId { get; set; }
    }

    [MessageContract(IsWrapped = true,
        WrapperName = "CarInfoObject",
        WrapperNamespace = "http://localhost:8080/Car")]
    public class CarInfo
    {
        public CarInfo() { }

        public CarInfo(Car car)
        {
            this.RegNumber = car.RegNumber;
            this.Brand = car.Brand;
            this.Year = car.Year;
            this.Model = car.Model;
            this.IsRented = car.IsRented;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Car")]
        public string RegNumber { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Car")]
        public string Brand { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Car")]
        public int Year { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Car")]
        public string Model { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Car")]
        public bool IsRented { get; set; }
    }

    [DataContract(Namespace = "http://localhost:8080/")]
    public class Car
    {
        private string _regNumber;
        private string _brand;
        private int _year;
        private string _model;
        private bool _isRented;

        [DataMember(Order = 1, Name = "REGNUMBER")]
        public string RegNumber
        {
            get { return _regNumber; }
            set { _regNumber = value; }
        } 
        //ändrar till String, regnumber har bokstäver

        [DataMember(Order = 2)]
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }


        [DataMember(Order = 3)]
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }


        [DataMember(Order = 4)]
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }


        [DataMember(Order = 5)]
        public bool IsRented
        {
            get { return _isRented; }
            set { _isRented = value; }
        }

    }
}