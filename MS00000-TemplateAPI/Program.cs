using Flowify.Extensions;
using INPS.ServiceDefault.Extensions;

namespace MS00000_TemplateAPI;

public class Program
{
    public static void Main(string[] args)
    {
        BuildApp(args).Run();
    }

    internal static WebApplication BuildApp(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Inserire i services necessari per l'applicazione

        builder.Services.AddControllers();
        builder.Services.AddFlowify(new[] { typeof(Program).Assembly });

        builder.AddServiceDefaults();

        builder.AddServiceDefaultsApiVersioning();
        builder.AddServiceDefaultsSwagger();
        builder.AddWsDatiPensioneServices();

        WebApplication app = builder.Build();

        app.UseServiceDefaults();

        app.UseServiceDefaultsSwagger();

        // Inserire qui eventuali middleware personalizzati

        app.UseAuthorization();


        app.MapControllers();

        return app;
    }
}
