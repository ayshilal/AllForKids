
using Service.Base;

namespace Service.Category.Model
{
    public class CategoryDtoSearchModel : BaseDtoSearchModel
    {
        public long ID { get; set; }
        public string Slug { get; set; }
    }
}
