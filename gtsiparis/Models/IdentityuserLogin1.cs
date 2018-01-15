using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace gtsiparis.Models
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {

        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }

    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {

        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.RoleId);
        }

    }
}