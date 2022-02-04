using AspNetCoreHero.ToastNotification;
using Castle.Core.Logging;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WeblawyersBox.Data;
using WeblawyersBox.Email;
using WeblawyersBox.Models;
using WeblawyersBox.Pages.EmaiSservice;
using WeblawyersBox.servicos;
using static System.Net.Mime.MediaTypeNames;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox
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
           
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies()
               .UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
               

            options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
               new TokenProviderDescriptor(
                   typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            })      .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultUI()
                 .AddDefaultTokenProviders()
            .AddErrorDescriber<IdentityPortugueseMessages>();//traduzio erros para portugues
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddLocalization();
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            services.AddRazorPages();
            //Email
            var emailConfig = Configuration
         .GetSection("EmailConfiguration")
         .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddSingleton<IEmailSenders, EnviarEmailCliente>();

            //services.AddSingleton<IEnviarJobes, Enviarnotfica>();

           
            //services.Configure<EmailOpions>(Configuration);
            services.ConfigureApplicationCookie(o => {
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
                o.LoginPath = "/Autenticar/";
                o.Cookie.HttpOnly = true;
            });
            services.Configure<DataProtectionTokenProviderOptions>(o =>
      o.TokenLifespan = TimeSpan.FromHours(3));

           

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

          //tarefas diarias

            services.AddHangfireServer();
          


            /////tarefas fim

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }
      
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        { 


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //      // app.UseDatabaseErrorPage();
            //    app.UseDirectoryBrowser();



            //}
            //else
            //{ 
            //RecurringJobManager.AddOrUpdate(
            //   "Corre acad minuto",
            //   () => serviceProvider.GetService<IPrintJob>().Print(),"",
            //   "* * * * *"
            //   );
         
         
            app.UseHangfireDashboard();
          //  app.UseHangfireServer();
            // notyf.Information("entrar para producao");
            app.UseExceptionHandlerMiddleware();
           //  app.UseExceptionHandler("/Error");
               
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
       // }



            app.UseMigrationsEndPoint();

            app.UseHttpsRedirection();
            // Security - Registered before static files to always set header
            app.UseHsts(hsts => hsts.MaxAge(365));
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());

            app.UseStaticFiles();

            // Security - Registered after static files, for dynamic content.
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXfo(xfo => xfo.Deny());
            app.UseRedirectValidation();


            app.UseRouting();
            var defaultDateCulture = "pt";
            var ci = new CultureInfo(defaultDateCulture);
            

            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
            {
                ci,
            },
                SupportedUICultures = new List<CultureInfo>
            {
                ci,
            }
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });
        }

        
    }
}
