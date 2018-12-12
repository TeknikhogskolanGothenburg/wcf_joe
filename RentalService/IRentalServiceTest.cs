using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Rental_Data;

namespace RentalService
{
    [ServiceContract]
    public interface IRentalServiceTest
    {
        [OperationContract]
        void AddCustomer(string firstName, string lastName, string phoneNumber, string emailAddress);

        [OperationContract]
        [FaultContract(typeof(DoesNotExistFault))]
        void EditCustomer(Customer customer);

        [OperationContract]
        [FaultContract(typeof(DoesNotExistFault))]
        void RemoveCustomer(string firstName, string lastName, int id);

        [OperationContract]
        void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime);

        [OperationContract]
        [FaultContract(typeof(DoesNotExistFault))]
        void RemoveBooking(string bookingId);

        [OperationContract]
        void ReturnCar(Booking booking);

        [OperationContract]
        List<Car> CheckDate(DateTime startDate, DateTime endDate);
        
        [OperationContract]
        List<Car> GetCarsByBrand(string brand);

        [OperationContract]
        List<Car> GetCarsByYear(int year);

        [OperationContract]
        List<Car> GetCarsByModel(string model);

        [OperationContract]
        Booking GetBookingById(string bookingId);
    }
}

