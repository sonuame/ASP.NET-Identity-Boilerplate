using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(AppDbContext context)
            : base(context)
        {
        }
    }
