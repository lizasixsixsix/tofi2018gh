using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using tofi2018.Models;

[assembly: OwinStartupAttribute(typeof(tofi2018.Startup))]
namespace tofi2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateAdminAndRoles();
        }

        private void CreateAdminAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("User"))
            {

                var role = new IdentityRole
                {
                    Name = "User"
                };

                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {

                var role = new IdentityRole
                {
                    Name = "Admin"
                };

                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };

                string userPWD = "Aa~123";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
