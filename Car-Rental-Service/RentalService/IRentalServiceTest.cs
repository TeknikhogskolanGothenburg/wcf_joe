using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        void RemoveCar(string regNumber);

        [OperationContract]
        void AddCustomer(string firstName, string lastName, string phoneNumber, string emailAddress);

        [OperationContract]
        void EditCustomer(Customer customer);

        [OperationContract]
        void RemoveCustomer(string firstName, string lastName, int id);

        [OperationContract]
        void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime);

        [OperationContract]
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

        //customer overload, most likely not needed
        [OperationContract]
        List<Booking> GetBookingsByCustomerEmail(Customer customer);

        [OperationContract]
        List<Booking> GetBookingsByCustomerEmail(string email);


        //customer overload, most likely not needed
        [OperationContract]
        List<Booking> GetBookingsByCustomerPhone(Customer customer);

        [OperationContract]
        List<Booking> GetBookingsByCustomerPhone(string phone);

        //have to test this one later
        [OperationContract]
        List<Booking> GetBookingsByTime(DateTime start, DateTime end);

        [OperationContract]
        List<Booking> GetBookingsByIsNotReturned();

        // När kunden kvitterar ut sin hyrbil.
        [OperationContract]
        void GetCar(Booking booking);
        
    }
}
