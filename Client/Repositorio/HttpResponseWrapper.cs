using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Client.Repositorio
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httResponseMessage;
        }

        public HttpResponseWrapper(T response,bool erro)
        {
            Response = response;
            Error = erro;
        }

        public bool Error { get; set; }
        public T Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
