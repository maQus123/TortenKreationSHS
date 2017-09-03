namespace TortenKreationSHS {

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Net.Http.Headers;
    using TortenKreationSHS.Repositories;

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContextPool<DatabaseContext>(options => options.UseSqlite("Data Source=database.sqlite"));
            services.AddResponseCaching();
            services.AddMvc();
            services.Configure<RouteOptions>(options => { options.AppendTrailingSlash = true; options.LowercaseUrls = true; });
            services.AddScoped<ICakeRepository, CakeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            app.UseResponseCaching();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = ctx => {
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + 604800;
                }
            });
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "aboutMe",
                    template: "ueber-mich",
                    defaults: new { controller = "Home", action = "AboutMe" });
                routes.MapRoute(
                    name: "cakeList",
                    template: "torten",
                    defaults: new { controller = "Home", action = "CakeList" });
                routes.MapRoute(
                    name: "cakeDetail",
                    template: "torten/{slug}",
                    constraints: new { slug = @"^[a-z0-9-]+$" },
                    defaults: new { controller = "Home", action = "CakeDetail" });
            });
        }

    }

}