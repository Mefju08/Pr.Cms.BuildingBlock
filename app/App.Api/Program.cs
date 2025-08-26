using App.Api.Controllers;
using App.Api.DAL;
using Pr.Cms.BuildingBlock.Infrastructure;
using Pr.Cms.BuildingBlock.Infrastructure.Controllers;
using Pr.Cms.BuildingBlock.Infrastructure.DomainEvents;
using Pr.Cms.BuildingBlock.Infrastructure.Exceptions;

namespace App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<ICarRepository, CarRepository>();


            // automatyczna konwersja odpowiedzi api do formatu {"data":...}
            builder.Services.AddApiResponseWrapper();

            // rejestracje obs�ugi wyj�tk�w
            builder.Services.RegisterGlobalExceptionHandler();

            // rejestracja podstawowych wsp�dzielonych funkcji
            builder.Services.RegisterSharedInfrastructure(builder.Configuration);

            // rejestracja event�w domenowych
            builder.Services.RegisterDomainEventHandlers(builder.Host, typeof(BaseController).Assembly);

            // dodawanie bazy
            builder.Services.AddPostgres<Db>("test_connection_string");

            var app = builder.Build();

            //// u�uwanie obs�ugi wyj�tk� (middleware)
            app.UseGlobalExceptionHandler();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
