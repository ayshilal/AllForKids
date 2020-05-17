
using EntityLibrary.Model;

namespace WebApi.Models.Product
{
    //[Validator(typeof(BankEditModelValidator))]
    public class ProductEditModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
