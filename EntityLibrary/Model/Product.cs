using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibrary.Model
{
    public partial class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? CompareAtPrice { get; set; }
        public byte[] Images { get; set; }
        //public string Badges { get; set; }
        public int Rating { get; set; }
        public int Reviews { get; set; }
        public string Availability { get; set; }
        //public Brand Brand { get; set; }
        //public Category[] Category { get; set; }
        //public ProductAttribute[] ProductAttribute { get; set; }
    }
}
