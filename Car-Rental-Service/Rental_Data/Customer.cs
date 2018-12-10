using System.Runtime.Serialization;
using System.ServiceModel;

namespace Rental_Data
{
    [MessageContract(IsWrapped = true,
        WrapperName = "CustomerRequestObject",
        WrapperNamespace = "http://localhost:8080/Customer")]
    public class CustomerRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Customer")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://localhost:8080/Customer")]
        public int CustomerId { get; set; }
    }
    
    [MessageContract(IsWrapped = true,
        WrapperName = "CustomerInfoObject",
        WrapperNamespace = "http://localhost:8080/Customer")]
    public class CustomerInfo
    {
        public CustomerInfo() { }

        public CustomerInfo(Customer customer)
        {
            this.Id = customer.Id;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.PhoneNumber = customer.PhoneNumber;
            this.EmailAddress = customer.EmailAddress;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Customer")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://localhost:8080/Customer")]
        public string FirstName { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Customer")]
        public string LastName { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Customer")]
        public string PhoneNumber { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://localhost:8080/Customer")]
        public string EmailAddress { get; set; }
    }

    [DataContract(Namespace = "http://localhost:8080/Customer")]
    public class Customer
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _emailAddress;


        [DataMember(Order = 1, Name = "ID")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        [DataMember(Order = 2)]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        [DataMember(Order = 3)]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        [DataMember(Order = 4)]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }


        [DataMember(Order = 5)]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

    }
}
