using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RegistroAcademicoApp.Client.Repositorio
{
    public class ApiErrors
    {
       
            public int StatusCode { get; private set; }

            public string StatusDescription { get; private set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Message { get; private set; }

            public ApiErrors(int statusCode, string statusDescription)
            {
                this.StatusCode = statusCode;
                this.StatusDescription = statusDescription;
            }

            public ApiErrors(int statusCode, string statusDescription, string message)
                : this(statusCode, statusDescription)
            {
                this.Message = message;
            }
       

       
    }
     public  class InternalServerError : ApiErrors
        {
            public InternalServerError()
                : base(500, HttpStatusCode.InternalServerError.ToString())
            {
            }


            public InternalServerError(string message)
                : base(500, HttpStatusCode.InternalServerError.ToString(), message)
            {
            }
        }
}
