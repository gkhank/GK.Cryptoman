using GK.Cryptoman.Utilities.Extensions;
using GK.Cryptoman.Utilities.Shared.Middleware.Exception;
using GK.Cryptoman.Utilities.Shared.Middleware.Validation;
using GK.Cryptoman.Hub.Validators;
using GK.Cryptoman.Model.Request;
using System.Reflection;
using FluentValidation;

internal class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logger
        builder.Logging.AddConsole();
        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Register binance http services
        builder.Services.RegisterBinanceHttpClients(builder.Configuration);

        //Register backend validators
        builder.Services.RegisterValidators(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<IValidator<SpotRequest>, SpotRequestValidator>();

        //Register service repositories
        builder.Services.RegisterRepositories();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<CustomErrorHandlerMiddleware>();
        app.UseMiddleware<CustomValidationHandlerMiddleware>();


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}