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
    public interface ISupportService
    {
        [OperationContract]
        void AddCar(string regNumber, string brand, int year, string model);

        [OperationContract]
        [FaultContract(typeof(DoesNotExistFault))]
        void RemoveCar(string regNumber);

        [OperationContract]
        List<Customer> GetCustomers(string searchString);

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        List<Customer> GetCustomersByName(string name);

        [OperationContract]
        Customer GetCustomerByPhoneNumber(string number);

        [OperationContract]
        Customer GetCustomerByEmail(string email);

        [OperationContract]
        Customer GetCustomerFromBooking(Booking booking);

        [OperationContract]
        Car GetCarByReg(string regNumber);

        [OperationContract]
        Car GetCarFromBooking(Booking booking);

        [OperationContract]
        List<Car> GetCarsByIsRented();

        [OperationContract]
        List<Booking> GetBookingsByCar(Car car);

        [OperationContract]
        List<Booking> GetBookingsByCustomer(Customer customer);

        [OperationContract]
        List<Booking> GetBookingsByCustomerEmail(string email);

        [OperationContract]
        List<Booking> GetBookingsByCustomerPhone(string phone);

        [OperationContract]
        List<Booking> GetBookingsByIsNotReturned();

        [OperationContract]
        List<Booking> GetBookingsByTime(DateTime start, DateTime end);

        [OperationContract]
        CarInfo GetCar(CarRequest request);

        [OperationContract]
        void SaveCar(CarInfo car);
    }
}
