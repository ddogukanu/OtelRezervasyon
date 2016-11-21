namespace MVCOtel.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCOtel.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCOtel.Models.ApplicationDbContext ctx)
        {
           if(ctx.Roles.Where(x=>x.Name=="Admin").Count()==0)
            {
                var rstore = new RoleStore<IdentityRole>(ctx);
                var rmanager = new RoleManager<IdentityRole>(rstore);
                var role = new IdentityRole { Name = "Admin" };
                rmanager.Create(role);
            }

            //kullanýcý
            if (ctx.Users.Where(x => x.Email == "d@d.com").Count()==0) {
                var kmanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                var user = new ApplicationUser { UserName = "d@d.com", Email = "d@d.com" };
                kmanager.Create(user, "123456");
                kmanager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
