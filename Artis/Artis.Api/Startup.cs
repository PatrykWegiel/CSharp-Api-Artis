using Artis.Api.HealthChecks;
using Artis.Data.Sql;
using Artis.Data.Sql.Migrations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using FluentValidation.AspNetCore;
using FluentValidation;
using Artis.Api.BindingModels;
using Artis.Api.Validation;
using Artis.IServices.User;
using Artis.IData.User;
using Artis.Data.Sql.User;
using Artis.Services.User;
using Artis.IServices.Item;
using Artis.Services.Item;
using Artis.IData.Item;
using Artis.Data.Sql.Item;
using Artis.IServices.Bid;
using Artis.IData.Bid;
using Artis.Services.Bid;
using Artis.Data.Sql.Bid;
using Artis.Api.Middlewares;

namespace Artis.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private const string MySqlHealthCheckName = "mysql";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ArtisDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("ArtisDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).AddFluentValidation();
            services.AddTransient<IValidator<EditUser>, EditUserValidator>();
            services.AddTransient<IValidator<CreateUser>, CreateUserValidator>();
            services.AddTransient<IValidator<EditAuctionItem>, EditAuctionItemValidator>();
            services.AddTransient<IValidator<CreateAuctionItem>, CreateAuctionItemValidator>();
            services.AddTransient<IValidator<EditBid>, EditBidValidator>();
            services.AddTransient<IValidator<CreateBid>, CreateBidValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IBidRepository, BidRepository>();

            services.AddHealthChecks().AddMySql(
        Configuration.GetConnectionString("ArtisDbServer"),
        4,
        10,
        MySqlHealthCheckName);

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.UseApiBehavior = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //wystawienie pod adresem /healthy stanu healthchecków
            app.UseHealthChecks("/healthy");

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ArtisDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                //sprawdzenie czy health check siê powiód³
                var healthCheck = serviceScope.ServiceProvider.GetRequiredService<HealthCheckService>();
                if (healthCheck.CheckHealthAsync().Result?.Entries[MySqlHealthCheckName].Status
                    == HealthCheckResult.Healthy().Status)
                {
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    //databaseSeed.Seed();
                }
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
