using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentalService
{
    [DataContract(Namespace = "http://localhost:8080/Fault/DoesNotExist")]
    public class DoesNotExistFault
    {
        private string operation;
        private string description;

        [DataMember]
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
