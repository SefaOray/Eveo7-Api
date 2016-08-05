using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Eveo7.Utilities
{
    public static class ExceptionHelper
    {
        public static void Thing()
        {
            var a = new HttpResponseMessage(HttpStatusCode.BadRequest);
            a.ReasonPhrase = "aq";
            throw new HttpResponseException(a);
        }
    }
}
