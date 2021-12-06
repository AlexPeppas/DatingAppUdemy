using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UdemyDatingApp.AdvancedTechniques.Asynchronous_Programming;
using UdemyDatingApp.AdvancedTechniques.DocumentManipulation;
using UdemyDatingApp.AdvancedTechniques.Dynamics;
using UdemyDatingApp.AdvancedTechniques.ExceptionHandling;
using UdemyDatingApp.AdvancedTechniques.Extensions;
using UdemyDatingApp.API.Data;
using UdemyDatingApp.EventNotifier;


namespace UdemyDatingApp
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var docManip = new PdfMainClass();
            docManip.PdfFunctionality();

            var mAsync = new MainAsync();
            mAsync.MainFunctionality();

            var mException = new SimulateMainClass();
            mException.SecondaryFunctionality();
            var mDynamics = new MainClassSimulation();
            mDynamics.MainFunctionality();

            var m = new Main();
            m.MainFunctionality();
            //
            //testing Advanced C# Course
            var mainFUnc = new MainEventNotifier();
            mainFUnc.MainFunctionality();


            //var main = new MainClassSimulation();
            //main.MainSimulation();
            //testing Advanced C# Course
            //

            //CreateHostBuilder(args).Build().Run();
            //stops run to first create DataContext service and use it 
            //to seed the DB before run
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                //GetRequiredService to fetch the desired of your services before run
                var context = services.GetRequiredService<DataContext>();
                //if our database is dropped then just by restarting our app this migration will recreate our db
                await context.Database.MigrateAsync();
                //seed the db with SeedUsers() method
                await Seed.SeedUsers(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Error Occurred during migration");
            }
            await host.RunAsync();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
