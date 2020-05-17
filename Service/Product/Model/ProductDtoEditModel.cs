
using Service.Base;

namespace Service.Product.Model
{
    public class ProductDtoEditModel : BaseDtoEditModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
