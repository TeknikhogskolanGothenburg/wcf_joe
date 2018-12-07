using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Rental_Data
{
    [MessageContract(IsWrapped = true,
        WrapperName = "BookingRequestObject",
        WrapperNamespace = "http://localhost:8080/Booking")]
    public class BookingRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Booking")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Booking")]
        public string BookingId { get; set; }
    }

    [MessageContract(IsWrapped = true,
        WrapperName = "BookingInfoObject",
        WrapperNamespace = "http://localhost:8080/Booking")]
    public class BookingInfo
    {
        public BookingInfo() { }

        public BookingInfo(Booking booking)
        {
            this.Id = booking.Id;
            this.RentalCar = booking.RentalCar;
            this.Renter = booking.Renter;
            this.StartTime = booking.StartTime;
            this.EndTime = booking.EndTime;
            this.IsReturned = booking.IsReturned;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Booking")]
        public string Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Booking")]
        public Car RentalCar { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Booking")]
        public Customer Renter { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Booking")]
        public DateTime StartTime { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Booking")]
        public DateTime EndTime { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://localhost:8080/Booking")]
        public bool IsReturned { get; set; }
    }

    [DataContract(Namespace = "http://localhost:8080/Booking")]
    public class Booking
    {
        private string _id;
        private Car _rentalCar;
        private Customer _renter;
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isReturned;

        [DataMember(Order = 1, Name = "ID")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Order = 2)]
        public Car RentalCar
        {
            get { return _rentalCar; }
            set { _rentalCar = value; }
        }

        [DataMember(Order = 3)]
        public Customer Renter
        {
            get { return _renter; }
            set { _renter = value; }
        }

        [DataMember(Order = 4)]
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        [DataMember(Order = 5)]
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        [DataMember(Order = 6)]
        public bool IsReturned
        {
            get { return _isReturned; }
            set { _isReturned = value; }
        }
    }
}
