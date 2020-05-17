using System;
using System.Collections.Generic;

namespace CommonTypes.Response
{
    public class ServicePrimitiveResponse
    {
        public ServicePrimitiveResponse()
        {
            Errors = new List<string>();
        }
        public string ResponseCode { get; set; }
        public string EntityPrimaryKey { get; set; }
        public Exception InnerException { get; set; }
        public IList<string> Errors { get; set; }
    }
}
