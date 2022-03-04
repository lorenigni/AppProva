using AppProva.Imp;
using AppProva.Repository;
using AppProva.Repository.Impl;
using AppProva.Services;
using AppProva.Services.Impl;
using System.Text.Json.Serialization;

namespace API
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)         //     Defines a class that provides the mechanisms to configure an application's request
                                                                                        //     pipeline , // Provides information about the web hosting environment an application is running in

        {
            if (env.IsDevelopment())                    //     Checks if the current host environment name is Microsoft.Extensions.Hosting.EnvironmentName.Development.
            {
                app.UseSwagger();                       //     Register the Swagger middleware
                app.UseSwaggerUI();                     
            }


            app.UseRouting();                           // aggiunge la corrispondenza di route alla pipeline middleware
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>               // aggiunge l'esecuzione dell'endpoint alla pipeline middleware
            {
                endpoints.MapControllers();             //     Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
                                                        //     without specifying any routes.

            });


        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton<IUser, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IProduct, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IShoppingCart, ShoppingCartService>();
            services.AddSingleton<IShoppinCartRepository, ShoppingCartRepository>();




        }



    }
}
