using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Responses;

namespace Eveo7.Api
{
    public static class ResponseHelper
    {
        public static JsonResponse ReturnBadRequestResponse(string message)
        {
            var response = new JsonResponse(new BasicResponse(message), new DefaultJsonSerializer());
            response.StatusCode = HttpStatusCode.BadRequest;;
            return response;
        }


        public class BasicResponse
        {
            public string Message { get; set; }

            public BasicResponse(string message)
            {
                Message = message;
            }
        }
    }
}