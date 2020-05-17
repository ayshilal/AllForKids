using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLibrary.Model
{
    public abstract class BaseModel
    {
        [Column(Order = 100)]
        public long InsertUserId { get; set; }
        [Column(Order = 101)]
        public DateTime InsertDate { get; set; }
        [Column(Order = 102)]
        public long? LastUpdateUserId { get; set; }
        [Column(Order = 103)]
        public DateTime? LastUpdateDate { get; set; }
        [Column(Order = 104)]
        public virtual int Status { get; set; }

        //public User InsertUser { get; set; }
        //public User LastUpdateUser { get; set; }

    }
}
