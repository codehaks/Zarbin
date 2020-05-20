using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Docs;

namespace Portal.Web.Configs
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
 
            services.AddTransient<IDocService, DocService>();
 

        }
    }
}
