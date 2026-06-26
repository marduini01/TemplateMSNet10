using INPS.ServiceDefault.Extensions;

namespace MS00000_TemplateAPI;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.AddServiceDefaults();
        builder.AddServiceDefaultsApiVersioning();
        builder.AddServiceDefaultsSwagger();
        builder.AddWsDatiPensioneServices();

        WebApplication app = builder.Build();

        app.UseServiceDefaults();
        app.UseServiceDefaultsSwagger();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
