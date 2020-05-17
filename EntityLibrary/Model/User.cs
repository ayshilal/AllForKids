using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibrary.Model
{
    public partial class User : BaseModel
    {
        public User()
        {
            //CustomerInsertuser = new HashSet<Customer>();
            //CustomerLastupdateuser = new HashSet<Customer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        //public ICollection<Customer> CustomerLastupdateuser { get; set; }
        //public ICollection<Customer> CustomerInsertuser { get; set; }
    }
}
