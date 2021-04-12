using Newtonsoft.Json;
using System;

namespace MF.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(ErrorCollection errorCollection)
             : base(JsonConvert.SerializeObject(errorCollection.GetErrors()))
        {
        }

        public CustomValidationException(ErrorModel error)
             : base(JsonConvert.SerializeObject(error))
        {
        }
    }
}
