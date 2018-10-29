using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Rental_Logic;

namespace RentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RentalService" in both code and config file together.
    public class RentalServiceTest : IRentalServiceTest
    {
        public void AddCar(string regNumber, string brand, int year, string model)
        {
            Rentals.AddCar(regNumber, brand, year, model);
        }
    }
}
