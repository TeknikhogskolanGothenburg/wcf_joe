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
            rentals.EditCustomer(customer);
        }

        public void RemoveCustomer(string firstName, string lastName, int id)
        {
            rentals.RemoveCustomer(firstName, lastName, id);
        }

        public void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime)
        {
            rentals.AddBooking(rentalCar, renter, startTime, endTime);
        }

        public void RemoveBooking(string bookingId)
        {
            rentals.RemoveBooking(bookingId);
        }

        public void ReturnCar(Booking booking)
        {
            rentals.ReturnCar(booking);
        }

        public List<Car> CheckDate(DateTime startDate, DateTime endDate)
        {
            List<Car> cars = rentals.CheckDate(startDate, endDate);
            return cars;
        }

        public List<Customer> GetCustomers(string searchString)
        {
            List<Customer> customers = rentals.GetCustomers(searchString);
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = rentals.GetCustomerById(id);
            return customer;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            List<Customer> customers = rentals.GetCustomersByName(name);
            return customers;
        }

        public Customer GetCustomerByPhoneNumber(string number)
        {
            Customer customer = rentals.GetCustomerByPhoneNumber(number);
            return customer; 
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = rentals.GetCustomerByEmail(email);
            return customer;
        }

        public Customer GetCustomerFromBooking(Booking booking)
        {
            Customer customer = rentals.GetCustomerFromBooking(booking);
            return customer;
        }

        public Car GetCarByReg(string regNumber)
        {
            Car car = GetCarByReg(regNumber);
            return car;
        }

        public List<Car> GetCarsByBrand(string brand)
        {
            List<Car> cars = rentals.GetCarsByBrand(brand);
            return cars;
        }

        public List<Car> GetCarsByYear(int year)
        {
            List<Car> cars = rentals.GetCarsByYear(year);
            return cars;
        }

        public List<Car> GetCarsByModel(string model)
        {
            List<Car> cars = rentals.GetCarsByModel(model);
            return cars;
        }

        public List<Car> GetCarsByIsRented()
        {
            List<Car> cars = rentals.GetCarsByIsRented();
            return cars;
        }

        public Car GetCarFromBooking(Booking booking)
        {
            Car car = rentals.GetCarFromBooking(booking);
            return car;
        }

        public Booking GetBookingById(string bookingId)
        {
            Booking booking = rentals.GetBookingById(bookingId);
            return booking;
        }

        public List<Booking> GetBookingsByCar(Car car)
        {
            List<Booking> bookings = rentals.GetBookingsByCar(car);
            return bookings;
        }

        public List<Booking> GetBookingsByCustomer(Customer customer)
        {
            List<Booking> bookings = rentals.GetBookingsByCustomer(customer);
            return bookings;
        }
        //customer overload, most likely not needed
        public List<Booking> GetBookingsByCustomerEmail(Customer customer)
        {
            List<Booking> bookings = rentals.GetBookingsByCustomerEmail(customer);
            return bookings;
        }

        public List<Booking> GetBookingsByCustomerEmail(string email)
        {
            List<Booking> bookings = rentals.GetBookingsByCustomerEmail(email);
            return bookings;
        }

        //customer overload, most likely not needed
        public List<Booking> GetBookingsByCustomerPhone(Customer customer)
        {
            List<Booking> bookings = rentals.GetBookingsByCustomerPhone(customer);
            return bookings;
        }

        public List<Booking> GetBookingsByCustomerPhone(string phone)
        {
            List<Booking> bookings = rentals.GetBookingsByCustomerPhone(phone);
            return bookings;
        }
        
        public List<Booking> GetBookingsByTime(DateTime start, DateTime end)
        {
            List<Booking> bookings = rentals.GetBookingsByTime(start, end);
            return bookings;
        }

        public List<Booking> GetBookingsByIsNotReturned()
        {
            List<Booking> bookings = rentals.GetBookingsByIsNotReturned();
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

                customer = rentals.Customers.Where(c => c.Id == id).FirstOrDefault();

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

            rentals.Customers.Add(newCustomer);
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

                booking = rentals.Bookings.Where(b => b.Id == id).FirstOrDefault();

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

            rentals.Bookings.Add(newBooking);
        }
    }
}
