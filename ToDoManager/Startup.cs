using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDoManager.DataModel;
using ToDoManager.Infrastructure;
using ToDoManager.Repository;
using ToDoManager.Service;
using FluentValidation.AspNetCore;
using ToDoManager.Models;
using FluentValidation;
using AutoMapper;
using ToDoManager.Infrastructure.Middleware;

namespace ToDoManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddCors();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ModelValidationFilterAttribute());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                //options.SuppressConsumesConstraintForFormFileParameters = true;
                //options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<ToDoManagerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IAccessTokenGenerator, JWTAccessTokenGenerator>();
            services.AddScoped<IPasswordGenerator, PBKDF2PasswordGenerator>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            ConfigureJWTAuthentication(services, appSettingsSection);

            RegisterValidators(services);
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<LoginModel>, LoginValidator>();
            services.AddTransient<IValidator<RegistrationModel>, RegistrationValidator>();
            services.AddTransient<IValidator<CreateUpdateTaskListModel>, CreateTaskListValidator>();
        }

        private void ConfigureJWTAuthentication(IServiceCollection services, IConfigurationSection appSettingsSection)
        {
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();

        }
    }
}
