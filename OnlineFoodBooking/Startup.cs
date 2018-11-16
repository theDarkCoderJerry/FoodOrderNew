using Hangfire;
using Microsoft.Owin;
using Ninject.Web.Common;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineFoodBooking.Startup))]
namespace OnlineFoodBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseNinjectActivator(new Bootstrapper().Kernel);
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            
        }
    }
}
