using KelloRepository.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kello.Models
{
    public class KelloUserManager : UserManager<KelloUser>
    {
        public KelloUserManager()
            : base(new UserStore<KelloUser>(new KelloContext()))
        {
        }
    }
}
