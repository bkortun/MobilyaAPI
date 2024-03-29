﻿using Application.Features.BasketItems.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Files.Rules;
using Application.Features.Orders.Rules;
using Application.Features.ProductImages.Rules;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.BasketService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Validation;
using Core.Caching;
using FluentValidation;
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
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<OrderBusinessRules>();
            services.AddScoped<BasketItemBusinessRules>();
            services.AddScoped<FileBusinessRules>();


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));



            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IBasketService,BasketManager>();
        }
    }
}
