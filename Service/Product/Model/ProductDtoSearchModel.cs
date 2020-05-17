
using Service.Base;

namespace Service.Product.Model
{
    public class ProductDtoSearchModel : BaseDtoSearchModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
