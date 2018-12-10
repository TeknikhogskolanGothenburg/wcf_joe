using Rental_Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rental_Logic
{
    //Would not use static if using database or textfile. Hard coding collections just for project.
    public static class Rentals
    {
        public static List<Car> Cars = new List<Car>();
        public static List<Customer> Customers = new List<Customer>();
        public static List<Booking> Bookings = new List<Booking>();
        
        public static void AddCar(string regNumber, string brand, int year, string model)
        {
            Car newCar = new Car()
            {
                RegNumber = regNumber,
                Brand = brand,
                Year = year,
                Model = model,
                IsRented = false
            };
            Cars.Add(newCar);
        }

        public static void RemoveCar(string regNumber)
        {
            Cars.RemoveAll(b => b.RegNumber == regNumber);
        }

        public static void AddCustomer(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Customer newCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress

            };
            Customers.Add(newCustomer);
        }

        public static void EditCustomer(Customer customer)
        {
            foreach (var cust in Customers.Where(c => c.Id == customer.Id))
            {
                cust.FirstName = customer.FirstName;
                cust.LastName = customer.LastName;
                cust.PhoneNumber = customer.PhoneNumber;
                cust.EmailAddress = customer.EmailAddress;
            }
        }

        public static void RemoveCustomer(string firstName, string lastName, int id)
        {
            Customers.RemoveAll(c => c.FirstName == firstName && c.LastName == lastName && c.Id == id);
        }

        public static void AddBooking(Car rentalCar, Customer renter, DateTime startTime, DateTime endTime)
        {
            Booking newBooking = new Booking()
            {
                Id = renter.Id + rentalCar.RegNumber + startTime,    // för lite med bara namn och id. kunden kan återkomma med flera bokningar.
                RentalCar = rentalCar,
                Renter = renter,
                StartTime = startTime,
                EndTime = endTime,
                IsReturned = false

            };
            Bookings.Add(newBooking);
        }

        public static void RemoveBooking(string bookingId)
        {
            Bookings.RemoveAll(b => b.Id == bookingId);
        }

        public static void ReturnCar(Booking booking)
        {
            if (booking.IsReturned == false && booking.RentalCar.IsRented == true)// IsRented sätts aldrig till True i koden. Behövs den alls? lägger till på rad 84
            {
                booking.IsReturned = true;
                booking.RentalCar.IsRented = false;
            }

            if (DateTime.Now < booking.EndTime)
            {
                booking.EndTime = DateTime.Now;
            }
        }

        public static List<Car> CheckDate(DateTime startDate, DateTime endDate)
        {
            List<Car> availableCars = Cars.ToList();
            foreach (var booking in Bookings)
            {
                if (startDate < booking.StartTime && endDate > booking.StartTime)
                {
                    availableCars.RemoveAll(b => b.RegNumber == booking.RentalCar.RegNumber);
                }
            }
            return availableCars;
        }

        //All get methods
        public static List<Customer> GetCustomers(string searchString)
        {
            return Customers.FindAll(c => c.FirstName.StartsWith(searchString) || c.LastName.StartsWith(searchString) || c.PhoneNumber.StartsWith(searchString) || c.EmailAddress.StartsWith(searchString));
        }

        public static Customer GetCustomerById(int id)
        {
            return Customers.Find(c => c.Id == id);
        }

        public static List<Customer> GetCustomersByName(string name)
        {
            return Customers.FindAll(c => c.FirstName == name || c.LastName == name);
        }

        public static Customer GetCustomerByPhoneNumber(string number)
        {
            return Customers.Find(c => c.PhoneNumber == number);
        }

        public static Customer GetCustomerByEmail(string email)
        {
            return Customers.Find(c => c.EmailAddress == email);
        }

        public static Customer GetCustomerFromBooking(Booking booking)
        {
            return Customers.Find(c => c.Id == booking.Renter.Id);
        }

        public static Car GetCarByReg(string regNumber)
        {
            return Cars.Find(c => c.RegNumber == regNumber);
        }

        public static List<Car> GetCarsByBrand(string brand)
        {
            return Cars.FindAll(c => c.Brand == brand);
        }

        public static List<Car> GetCarsByYear(int year)
        {
            return Cars.FindAll(c => c.Year == year);
        }

        public static List<Car> GetCarsByModel(string model)
        {
            return Cars.FindAll(c => c.Model == model);
        }

        public static List<Car> GetCarsByIsRented()
        {
            return Cars.FindAll(c => c.IsRented == true);
        }

        public static Car GetCarFromBooking(Booking booking)
        {
            return Cars.Find(c => c.IsRented == true && booking.Id == booking.Id);
        }

        public static Booking GetBookingById(string bookingId)
        {
            return Bookings.Find(b => b.Id == bookingId);
        }

        public static List<Booking> GetBookingsByCar(Car car)
        {
            return Bookings.FindAll(b => b.RentalCar.RegNumber == car.RegNumber);
        }

        public static List<Booking> GetBookingsByCustomer(Customer customer)
        {
            return Bookings.FindAll(b => b.Renter.Id == customer.Id);
        }

        //customer overload, most likely not needed
        public static List<Booking> GetBookingsByCustomerEmail(Customer customer)
        {
            return Bookings.FindAll(b => b.Renter.EmailAddress == customer.EmailAddress);
        }

        public static List<Booking> GetBookingsByCustomerEmail(string email)
        {
            return Bookings.FindAll(b => b.Renter.EmailAddress == email);
        }

        //customer overload, most likely not needed
        public static List<Booking> GetBookingsByCustomerPhone(Customer customer)
        {
            return Bookings.FindAll(b => b.Renter.PhoneNumber == customer.EmailAddress);
        }

        public static List<Booking> GetBookingsByCustomerPhone(string phone)
        {
            return Bookings.FindAll(b => b.Renter.PhoneNumber == phone);
        }

        //have to test this one later
        public static List<Booking> GetBookingsByTime(DateTime start, DateTime end)
        {
            var bookings = Bookings.ToList();
            foreach (var booking in bookings)
            {
                {
                    if (start < booking.StartTime && end > booking.StartTime)
                    {
                        bookings.Remove(booking);
                    }
                }
            }
            return bookings;
        }

        public static List<Booking> GetBookingsByIsNotReturned()
        {
            return Bookings.FindAll(b => b.IsReturned == false);
        }

        // När kunden kvitterar ut sin hyrbil.
        public static void GetCar(Booking booking)
        {
            booking.RentalCar.IsRented = true;
        }

    }
}