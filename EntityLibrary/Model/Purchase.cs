using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibrary.Model
{
    public partial class Purchase : BaseModel
    {
        public Purchase()
        {
            //User = new HashSet<User>();
            //Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        //public ICollection<User> User { get; set; }
        //public ICollection<Product> Product { get; set; }
    }
}
