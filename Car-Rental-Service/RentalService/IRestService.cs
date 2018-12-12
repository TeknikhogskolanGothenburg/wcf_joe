using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Rental_Data;

namespace RentalService
{
    //API Methods
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "AddCar",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AddCarByRest(List<string> car);

        [OperationContract]
        [WebGet(UriTemplate = "GetCar?carId={carId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<string> GetCarByRest(string carId);
    }
}
