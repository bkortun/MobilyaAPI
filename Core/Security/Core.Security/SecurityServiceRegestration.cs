using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public static class SecurityServiceRegestration
    {
        public static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper,JwtHelper>();
        }
    }
}
