using Application.Features.BasketItems.Rules;
using Application.Features.Files.Rules;
using Application.Features.ProductImages.Rules;
using Application.Features.Products.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.BasketService;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegestration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<ProductImageBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<BasketItemBusinessRules>();
            services.AddScoped<FileBusinessRules>();


            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(AuthorizationBehavior<,>));


            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IBasketService,BasketManager>();
        }
    }
}
