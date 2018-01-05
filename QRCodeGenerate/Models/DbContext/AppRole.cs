using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class AppRole : IdentityRole
    {
        public AppRole()
        {

        }

        public AppRole(string RoleName) : base(RoleName)
        {

        }
    }
