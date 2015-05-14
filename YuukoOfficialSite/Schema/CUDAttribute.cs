using System.Security.Principal;

namespace CodeComb.Yuuko.Schema
{
    public class CUDAttribute : AccessToAttribute
    {
        public override bool AccessCore(IPrincipal User, PortAction Action)
        {
            if (Action == PortAction.Retrieve)
                return true;
            if (User.Identity.IsAuthenticated)
                return true;
            return false;
        }
    }
}