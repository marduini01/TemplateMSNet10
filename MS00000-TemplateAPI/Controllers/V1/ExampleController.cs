using Asp.Versioning;
using INPS.ServiceDefault.Logger;
using INPS.ServiceDefault.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using WsDatiPensioni;

namespace MS00000_TemplateAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ExampleController : ControllerBase
{
    private readonly IApplicationLogger logger;
    private readonly IWsDatiPensioniConsumer wsDatiPensioniConsumer;

    public ExampleController(IApplicationLogger logger, IWsDatiPensioniConsumer wsDatiPensioniConsumer)
    {
        this.logger = logger;
        this.wsDatiPensioniConsumer = wsDatiPensioniConsumer;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        AdditionalDataLogDto additionalDataLog = new AdditionalDataLogDto
        {
            AdditionalDataLogID = 1,
            CorrelationId = HttpContext.TraceIdentifier,
            RequestPath = HttpContext.Request.Path,
            FilePath = "IndexController.cs",
            AdditionalData = "Esempio di dati aggiuntivi per il log",
            Exception = null
        };

        logger.Information("Hello from IndexController!");
        await logger.DebugAsync("Messaggio di prova debug", additionalDataLog);

        GetDatiECodiciVariRequest requestCf = wsDatiPensioniConsumer.PreparaRicercaConCodiceFiscale("PNPGNS31S66H914M");
        GetDatiECodiciVariRequest requestChiave = wsDatiPensioniConsumer.PreparaRicercaConChiavePensione("001740010004266");

        try
        {
            GetDatiECodiciVariResponse response = await wsDatiPensioniConsumer.GetDatiECodiciVariAsync(requestCf);
            Console.WriteLine($"[OK] Risposta ricevuta dal servizio SOAP");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRORE] Chiamata SOAP fallita: {ex.Message}");
        }


        return Ok("Hello from IndexController!");
    }
}
