using CommonType;

namespace CommonType
{
    public class UserProfile
    {
        public static long CurrentUserId => Current.UserID;
        public static UserAuthModel Current
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["User"] != null)
                {
                    return HttpContext.Current.Items["User"] as UserAuthModel;
                }
                return null;
            }
            set { HttpContext.Current.Items["User"] = value; }
        }
    }
}