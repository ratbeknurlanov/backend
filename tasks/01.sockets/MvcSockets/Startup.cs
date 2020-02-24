using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MvcSockets
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 404 NotFound для неизвестных страниц работает из коробки
            // Отдача статики из wwwroot подключается одной строчкой UseStaticFiles
            // Views с шаблонизатор Razor
            // Query string параметры становятся параметрами методов контроллера
            // Защита от XSS за счет автоматического использование html-сущностей
            // Специальный CookieHelper для задания Cookie и [Cookie] для их получения
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    defaults: new { controller = "Main", action = "Hello" },
                    pattern: "{action}");
            });
        }
    }
}
