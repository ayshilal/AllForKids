using System.Collections.Generic;

namespace CommonType
{
    public class UserAuthModel
    {
        public UserAuthModel()
        {
            SiteActions = new List<string>();
        }
        public long UserID { get; set; }
        public List<string> SiteActions { get; set; }
    }
}
