using Nancy;

namespace Eveo7.Api.Modules
{
    public class Auth : NancyModule
    {
        public Auth()
        {
            Get["/"] = _ => "Hello!";
        }
    }
}