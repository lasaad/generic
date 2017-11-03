using Generic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web.Configuration;

[assembly: OwinStartupAttribute(typeof(Generic.Startup))]
namespace Generic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createAdmin();
        }

        /// <summary>
        /// Création du compte d'administration  
        /// </summary>
        private void createAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Vérification de l'existence d'un administrateur 
            if (!roleManager.RoleExists("Administrateur"))
            {           
                // Création du rôle d'administrateur   
                var role = new IdentityRole("Administrateur");
                roleManager.Create(role);

                // Création d'un nouvel utilisateur 
                // Afin d'éviter toute erreur, UserName dois absolument correspondre à Email 
                var user = new ApplicationUser
                {
                    Nom = WebConfigurationManager.AppSettings["AdminNom"],
                    Prenom = WebConfigurationManager.AppSettings["AdminPrenom"],
                    UserName = WebConfigurationManager.AppSettings["AdminCourriel"],
                    Email = WebConfigurationManager.AppSettings["AdminCourriel"],
                };
                
                string password = WebConfigurationManager.AppSettings["AdminPwdDefault"];
                var chkUser = UserManager.Create(user, password);

                //Assignation du rôle d'administrateur en cas de succès de la création de compte
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Administrateur");
                }
            }
        }
    }
}
