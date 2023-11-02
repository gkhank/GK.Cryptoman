using Microsoft.Extensions.Hosting;
using Coravel;
using Microsoft.Extensions.DependencyInjection;
using GK.Cryptoman.BackgroundWorker.CronTasks;

internal class Program
{
    private static void Main(string[] args)
    {
        var build = CreateHostBuilder(args)
            .Build();

        build.Services.UseScheduler(scheduler =>
        {
            scheduler
                .Schedule<TestTask>()
                .EveryFiveSeconds()
                .Weekday();
        });

        build.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureHostOptions((hostContext, options) =>
            {
                Console.WriteLine(hostContext.HostingEnvironment.ApplicationName);
                Console.WriteLine(hostContext.HostingEnvironment.EnvironmentName);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<TestTask>();
                services.AddScheduler();
            });
}