using AtkTennisApp.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static AtkTennisApp.Program; 

namespace AtkTennisApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            try
            {
                var IpAdress = configuration.GetSection("MyIpAdress");
                IpAdress.Bind(set);
                set.MyIpAdress = IpAdress.Value;

                Mutuals.DbUrl = Configuration.GetValue<string>("DbUrl");
                Mutuals.IdUrl = Configuration.GetValue<string>("IdUrl");
                Mutuals.AdminUrl = Configuration.GetValue<string>("AdminURL");

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[1];
                Mutuals.MyIp = ipAddress.ToString();

                //Worker.SettingsWorker.getSettings();
                //Worker.SettingsWorker.StartTimers();

                
                Mutuals.monitizer.startSuccesful = 1;
                Mutuals.monitizer.AddLog(Mutuals.monitizer.appName + " application started successfully.");
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.startSuccesful = -1;
                Mutuals.monitizer.AddLog("Configuration string read error.");
                Mutuals.monitizer.AddException(ex);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddDbContext<AppIdentityDbContext>(
                options =>options.UseSqlServer(Configuration.GetValue<string>("DbUrl") , options=> { options.EnableRetryOnFailure(); }));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>(options=> {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DefaultFilesOptions DefaultFile = new DefaultFilesOptions();
            DefaultFile.DefaultFileNames.Clear();
            DefaultFile.DefaultFileNames.Add("Index.html");
            app.UseDefaultFiles(DefaultFile);
            app.UseStaticFiles();
        }
    }
}
