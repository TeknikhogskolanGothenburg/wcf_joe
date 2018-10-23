﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rental_Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        //public string FullName                    //används inte
        //{
        //    get
        //    {
        //        return FirstName + " " + LastName;
        //    }
        //}
    }
}
