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

    [DataContract(Namespace = "http://localhost:8080/")]
    public class Customer
    {
        [DataMember(Order = 1, Name = "ID")]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [DataMember(Order = 4)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 5)]
        public string EmailAddress { get; set; }
    }
}
