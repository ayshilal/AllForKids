
using EntityLibrary.Model;

namespace WebApi.Models.Category
{
    //[Validator(typeof(BankEditModelValidator))]
    public class CategoryEditModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
