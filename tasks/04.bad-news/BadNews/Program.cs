using System.Linq;
using BadNews.Repositories.News;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BadNews
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeDataBase();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        private static void InitializeDataBase()
        {
            var generator = new NewsGenerator();
            var articles = generator.GenerateNewsArticles()
                .Take(100)
                .OrderBy(it => it.Id)
                .ToList();

            var repository = new NewsRepository();
            repository.InitializeDataBase(articles);
        }
    }
}
