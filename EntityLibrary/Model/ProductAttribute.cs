using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLibrary.Model
{
    public partial class ProductAttribute : BaseModel
    {
        public long ID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public bool Featured { get; set; }
        //public ProductAttributeValue[] Values { get; set; }
    }
}
