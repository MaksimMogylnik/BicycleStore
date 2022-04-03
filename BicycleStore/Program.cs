using BicycleStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<BicycleContext>();
                    if(!context.Bicycles.Any())
                    {
                        #region tovari
                        context.AddRange(
                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 1",
                                BicycleWeight = 15,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#7a7373",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 3",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#ffffff",
                                BicycleWheelDiameter = "27 inches",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Продам гараж",
                                BicycleWeight = 99999,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#9c5814",
                                BicycleWheelDiameter = "Просторный",
                                BicycleAdditionalInfo = "Продам просторный гараж. все удобства предусмотрены, по вопросам звонить на номер: +380932532902",
                                BicyclePrice = 5500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "SUPA Bicycle",
                                BicycleWeight = 20,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#000000",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Thats a real estate",
                                BicyclePrice = 900
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 2",
                                BicycleWeight = 15,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "26 inches",
                                BicyclePrice = 350
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 1",
                                BicycleWeight = 14,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "21 inch",
                                BicyclePrice = 250
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 2",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#bfb4b4",
                                BicycleWheelDiameter = "26 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 1",
                                BicycleWeight = 15,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#7a7373",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 3",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#ffffff",
                                BicycleWheelDiameter = "27 inches",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Продам гараж",
                                BicycleWeight = 99999,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#9c5814",
                                BicycleWheelDiameter = "Просторный",
                                BicycleAdditionalInfo = "Продам просторный гараж. все удобства предусмотрены, по вопросам звонить на номер: +380932532902",
                                BicyclePrice = 5500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "SUPA Bicycle",
                                BicycleWeight = 20,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#000000",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Thats a real estate",
                                BicyclePrice = 900
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 2",
                                BicycleWeight = 15,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "26 inches",
                                BicyclePrice = 350
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 1",
                                BicycleWeight = 14,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "21 inch",
                                BicyclePrice = 250
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 2",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#bfb4b4",
                                BicycleWheelDiameter = "26 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 1",
                                BicycleWeight = 15,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#7a7373",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 3",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#ffffff",
                                BicycleWheelDiameter = "27 inches",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Продам гараж",
                                BicycleWeight = 99999,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#9c5814",
                                BicycleWheelDiameter = "Просторный",
                                BicycleAdditionalInfo = "Продам просторный гараж. все удобства предусмотрены, по вопросам звонить на номер: +380932532902",
                                BicyclePrice = 5500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "SUPA Bicycle",
                                BicycleWeight = 20,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#000000",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Thats a real estate",
                                BicyclePrice = 900
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 2",
                                BicycleWeight = 15,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "26 inches",
                                BicyclePrice = 350
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 1",
                                BicycleWeight = 14,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "21 inch",
                                BicyclePrice = 250
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 2",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#bfb4b4",
                                BicycleWheelDiameter = "26 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 1",
                                BicycleWeight = 15,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#7a7373",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 3",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#ffffff",
                                BicycleWheelDiameter = "27 inches",
                                BicyclePrice = 600
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Продам гараж",
                                BicycleWeight = 99999,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#9c5814",
                                BicycleWheelDiameter = "Просторный",
                                BicycleAdditionalInfo = "Продам просторный гараж. все удобства предусмотрены, по вопросам звонить на номер: +380932532902",
                                BicyclePrice = 5500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "SUPA Bicycle",
                                BicycleWeight = 20,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#000000",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Thats a real estate",
                                BicyclePrice = 900
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 2",
                                BicycleWeight = 15,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "26 inches",
                                BicyclePrice = 350
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Auchan Bike 1",
                                BicycleWeight = 14,
                                BicycleMaterial = "Aluminium",
                                BicycleColor = "#cc2525",
                                BicycleWheelDiameter = "21 inch",
                                BicyclePrice = 250
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Bicycle 2",
                                BicycleWeight = 16,
                                BicycleMaterial = "Metal - Aluminium",
                                BicycleColor = "#bfb4b4",
                                BicycleWheelDiameter = "26 inches",
                                BicycleAdditionalInfo = "Default all-terrain bicycle",
                                BicyclePrice = 500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "Продам гараж",
                                BicycleWeight = 99999,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#9c5814",
                                BicycleWheelDiameter = "Просторный",
                                BicycleAdditionalInfo = "Продам просторный гараж. все удобства предусмотрены, по вопросам звонить на номер: +380932532902",
                                BicyclePrice = 5500
                            },

                            new Bicycle()
                            {
                                BicycleTitle = "SUPA Bicycle",
                                BicycleWeight = 20,
                                BicycleMaterial = "Metal",
                                BicycleColor = "#000000",
                                BicycleWheelDiameter = "28 inches",
                                BicycleAdditionalInfo = "Thats a real estate",
                                BicyclePrice = 900
                            });
                        #endregion

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Seeding DB error");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
