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
        void AddCar(string regNumber, string brand, int year, string model);

        [OperationContract]
        [FaultContract(typeof(DoesNotExistFault))]
        void RemoveCar(string regNumber);

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
        List<Car> GetCarsByBrand(string brand);

        [OperationContract]
        List<Car> GetCarsByYear(int year);

        [OperationContract]
        List<Car> GetCarsByModel(string model);

        [OperationContract]
        List<Car> GetCarsByIsRented();

        [OperationContract]
        Car GetCarFromBooking(Booking booking);

        [OperationContract]
        Booking GetBookingById(string bookingId);

        [OperationContract]
        List<Booking> GetBookingsByCar(Car car);

        [OperationContract]
        List<Booking> GetBookingsByCustomer(Customer customer);

        [OperationContract]
        List<Booking> GetBookingsByCustomerEmail(string email);

        [OperationContract]
        List<Booking> GetBookingsByCustomerPhone(string phone);

        [OperationContract]
        List<Booking> GetBookingsByTime(DateTime start, DateTime end);

        [OperationContract]
        List<Booking> GetBookingsByIsNotReturned();

        [OperationContract]
        CarInfo GetCar(CarRequest request);

        [OperationContract]
        void SaveCar(CarInfo car);
    }
}

