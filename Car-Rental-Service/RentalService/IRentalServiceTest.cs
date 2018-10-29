﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRentalService" in both code and config file together.
    [ServiceContract]
    public interface IRentalServiceTest
    {
        [OperationContract]
        void AddCar(string regNumber, string brand, int year, string model);
    }
}
