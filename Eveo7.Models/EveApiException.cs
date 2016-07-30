using System;

namespace Eveo7.Models
{
    public class EveApiException : Exception
    {
        public EveApiException(string message) : base(message)
        {
            
        }
    }
}
