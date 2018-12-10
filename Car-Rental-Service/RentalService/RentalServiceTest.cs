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
        public void AddCar(string regNumber, string brand, int year, string model)
        {
            Rentals.AddCar(regNumber, brand, year, model);
        }

        public void RemoveCar(string regNumber)
        {
            Rentals.RemoveCar(regNumber);
        }

        public void AddCustomer(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Rentals.AddCustomer(firstName, lastName, phoneNumber, emailAddress);
        }

        public void EditCustomer(Customer customer)
        {
            Rentals.EditCustomer(customer);
        }

        public void RemoveCustomer(string firstName, string lastName, int id)
        {
            Rentals.RemoveCustomer(firstName, lastName, id);
        }

        public void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime)
        {
            Rentals.AddBooking(rentalCar, renter, startTime, endTime);
        }

        public void RemoveBooking(string bookingId)
        {
            Rentals.RemoveBooking(bookingId);
        }

        public void ReturnCar(Booking booking)
        {
            Rentals.ReturnCar(booking);
        }

        public List<Car> CheckDate(DateTime startDate, DateTime endDate)
        {
            List<Car> cars = Rentals.CheckDate(startDate, endDate);
            return cars;
        }

        public List<Customer> GetCustomers(string searchString)
        {
            List<Customer> customers = Rentals.GetCustomers(searchString);
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = Rentals.GetCustomerById(id);
            return customer;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            List<Customer> customers = Rentals.GetCustomersByName(name);
            return customers;
        }

        public Customer GetCustomerByPhoneNumber(string number)
        {
            Customer customer = Rentals.GetCustomerByPhoneNumber(number);
            return customer; 
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = Rentals.GetCustomerByEmail(email);
            return customer;
        }

        public Customer GetCustomerFromBooking(Booking booking)
        {
            Customer customer = Rentals.GetCustomerFromBooking(booking);
            return customer;
        }

        public Car GetCarByReg(string regNumber)
        {
            Car car = GetCarByReg(regNumber);
            return car;
        }

        public List<Car> GetCarsByBrand(string brand)
        {
            List<Car> cars = Rentals.GetCarsByBrand(brand);
            return cars;
        }

        public List<Car> GetCarsByYear(int year)
        {
            List<Car> cars = Rentals.GetCarsByYear(year);
            return cars;
        }

        public List<Car> GetCarsByModel(string model)
        {
            List<Car> cars = Rentals.GetCarsByModel(model);
            return cars;
        }

        public List<Car> GetCarsByIsRented()
        {
            List<Car> cars = Rentals.GetCarsByIsRented();
            return cars;
        }

        public Car GetCarFromBooking(Booking booking)
        {
            Car car = Rentals.GetCarFromBooking(booking);
            return car;
        }

        public Booking GetBookingById(string bookingId)
        {
            Booking booking = Rentals.GetBookingById(bookingId);
            return booking;
        }

        public List<Booking> GetBookingsByCar(Car car)
        {
            List<Booking> bookings = Rentals.GetBookingsByCar(car);
            return bookings;
        }

        public List<Booking> GetBookingsByCustomer(Customer customer)
        {
            List<Booking> bookings = Rentals.GetBookingsByCustomer(customer);
            return bookings;
        }

        public List<Booking> GetBookingsByCustomerEmail(string email)
        {
            List<Booking> bookings = Rentals.GetBookingsByCustomerEmail(email);
            return bookings;
        }
        
        public List<Booking> GetBookingsByCustomerPhone(string phone)
        {
            List<Booking> bookings = Rentals.GetBookingsByCustomerPhone(phone);
            return bookings;
        }
        
        public List<Booking> GetBookingsByTime(DateTime start, DateTime end)
        {
            List<Booking> bookings = Rentals.GetBookingsByTime(start, end);
            return bookings;
        }

        public List<Booking> GetBookingsByIsNotReturned()
        {
            List<Booking> bookings = Rentals.GetBookingsByIsNotReturned();
            return bookings;
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

                car = Rentals.Cars.Where(c => c.RegNumber == id).FirstOrDefault();
                
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

            Rentals.Cars.Add(newCar);               
        }

        public CustomerInfo GetCustomer(CustomerRequest request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);
            }
            else
            {
                Customer customer = null;

                int id = request.CustomerId;

                customer = Rentals.Customers.Where(c => c.Id == id).FirstOrDefault();

                return new CustomerInfo(customer);
            }
        }

        public void SaveCustomer(CustomerInfo customer)
        {
            Customer newCustomer = new Customer();
            newCustomer.Id = customer.Id;
            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.EmailAddress = customer.EmailAddress;

            Rentals.Customers.Add(newCustomer);
        }

        public BookingInfo GetBooking(BookingRequest request)
        {
            if (request.LicenseKey != "SuperSecret123")
            {
                throw new WebFaultException<string>(
                    "Wrong license key",
                HttpStatusCode.Forbidden);
            }
            else
            {
                Booking booking = null;
                
                string id = request.BookingId;

                booking = Rentals.Bookings.Where(b => b.Id == id).FirstOrDefault();

                return new BookingInfo(booking);
            }
        }

        public void SaveBooking(BookingInfo booking)
        {
            Booking newBooking = new Booking();
            newBooking.Id = booking.Id;
            newBooking.Renter = booking.Renter;
            newBooking.RentalCar = booking.RentalCar;
            newBooking.StartTime = booking.StartTime;
            newBooking.EndTime = booking.EndTime;
            newBooking.IsReturned = booking.IsReturned;

            Rentals.Bookings.Add(newBooking);
        }
    }
}
