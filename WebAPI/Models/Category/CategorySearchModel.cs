using EntityLibrary.Model;

namespace WebApi.Models.Category { 
    public class CategorySearchModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? EftCode { get; set; }
        public bool? IsTransferred { get; set; }
    }
}
