using System;

namespace Service.Base
{
    public class BaseDtoEditModel
    {
        public long InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public long? LastUpdateUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int Status { get; set; }

    }
}
