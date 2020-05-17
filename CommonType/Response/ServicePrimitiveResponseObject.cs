
namespace CommonTypes.Response
{

    public class ServicePrimitiveResponseObject<T> : ServicePrimitiveResponse where T : class
    {
        public ServicePrimitiveResponseObject()
        {
        }

        public T Data
        {
            get;
            set;
        }
    }
}
