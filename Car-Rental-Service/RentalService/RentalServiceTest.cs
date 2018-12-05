using Rental_Data;
using Rental_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace RentalService
{
    public class RentalServiceTest : IRentalServiceTest
    {
        Rentals rentals = new Rentals();

        public void Initialize()
        {

        }

        public void AddCar(string regNumber, string brand, int year, string model)
        {
            rentals.AddCar(regNumber, brand, year, model);
        }

        public void RemoveCar(string regNumber)
        {
            rentals.RemoveCar(regNumber);
        }

        public void AddCustomer(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            rentals.AddCustomer(firstName, lastName, phoneNumber, emailAddress);
        }

        public void EditCustomer(Customer customer)
        {

        }

        public void RemoveCustomer(string firstName, string lastName, int id)
        {

        }

        public void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime)
        {

        }

        public void RemoveBooking(string bookingId)
        {

        }

        public void ReturnCar(Booking booking)
        {

        }

        public List<Car> CheckDate(DateTime startDate, DateTime endDate)
        {
            return null;
        }

        public List<Customer> GetCustomers(string searchString)
        {
            return null;
        }

        public Customer GetCustomerById(int id)
        {
            return null;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            return null;
        }

        public Customer GetCustomerByPhoneNumber(string number)
        {
            return null;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return null;
        }

        public Customer GetCustomerFromBooking(Booking booking)
        {
            return null;
        }

        public Car GetCarByReg(string regNumber)
        {
            return null;
        }

        public List<Car> GetCarsByBrand(string brand)
        {
            return null;
        }

        public List<Car> GetCarsByYear(int year)
        {
            return null;
        }

        public List<Car> GetCarsByModel(string model)
        {
            return null;
        }

        public List<Car> GetCarsByIsRented()
        {
            return null;
        }

        public Car GetCarFromBooking(Booking booking)
        {
            return null;
        }

        public Booking GetBookingById(string bookingId)
        {
            return null;
        }

        public List<Booking> GetBookingsByCar(Car car)
        {
            return null;
        }

        public List<Booking> GetBookingsByCustomer(Customer customer)
        {
            return null;
        }
        //customer overload, most likely not needed
        public List<Booking> GetBookingsByCustomerEmail(Customer customer)
        {
            return null;
        }

        public List<Booking> GetBookingsByCustomerEmail(string email)
        {
            return null;
        }

        //customer overload, most likely not needed
        public List<Booking> GetBookingsByCustomerPhone(Customer customer)
        {
            return null;
        }

        public List<Booking> GetBookingsByCustomerPhone(string phone)
        {
            return null;
        }

        //have to test this one later
        public List<Booking> GetBookingsByTime(DateTime start, DateTime end)
        {
            return null;
        }

        public List<Booking> GetBookingsByIsNotReturned()
        {
            return null;
        }
        
        //Message Contract Methods
        public CarInfo GetCar(CarRequest request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);
            }
            else
            {
                Car car = null;
                
                string id = request.CarId;

                car = rentals.Cars.Where(c => c.RegNumber == id).FirstOrDefault();
                
                return new CarInfo(car);
            }
        }
        
        public void SaveCar(CarInfo car)
        {
            Car newCar = new Car();
            newCar.RegNumber = car.RegNumber;
            newCar.Brand = car.Brand;
            newCar.Model = car.Model;
            newCar.Year = car.Year;
            newCar.IsRented = car.IsRented;

            rentals.Cars.Add(newCar);               
        }
    }
}
