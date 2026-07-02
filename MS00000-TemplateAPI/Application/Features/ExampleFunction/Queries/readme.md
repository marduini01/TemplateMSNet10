# Markdown File

==================================================
GET EXAMPLE FUNCTION
==================================================

La cartella Queries contiene le query dedicate alla lettura dei dati.

A differenza dei Command, che modificano lo stato dell'applicazione, le Query hanno il solo scopo di recuperare informazioni.

Come esempio, per la funzionalità ExampleFunction, possiamo definire una query chiamata GetExampleFunctionQuery.

Questa query rappresenta l'azione di lettura di un elemento esistente.

Un esempio di query:

```csharp
using MediatR;

namespace Application.Features.ExampleFunction.GetExampleFunction;

public sealed record GetExampleFunctionQuery(GetExampleFunctionInput Input) : IRequest<GetExampleFunctionResponse>;
```
Poi sarà necessario aggiungere l'handler per gestire l'esecuzione della query.
```
using MediatR;
using Application.Interfaces;

namespace Application.Features.ExampleFunction.GetExampleFunction;

public sealed class GetExampleFunctionQueryHandler : IRequestHandler<GetExampleFunctionQuery, GetExampleFunctionResponse>
{
    private readonly IExampleFunctionRepository _exampleFunctionRepository;

    public GetExampleFunctionQueryHandler(IExampleFunctionRepository exampleFunctionRepository)
    {
        _exampleFunctionRepository = exampleFunctionRepository;
    }

    public async Task<GetExampleFunctionResponse> Handle(GetExampleFunctionQuery request, CancellationToken cancellationToken)
    {
        var input = request.Input;

        var exampleFunction = await _exampleFunctionRepository.GetByIdAsync(input.Id, cancellationToken);

        if (exampleFunction is null)
        {
            throw new KeyNotFoundException(
                $"ExampleFunction con id '{input.Id}' non trovata.");
        }

        return new GetExampleFunctionResponse(exampleFunction.Id, exampleFunction.Code, exampleFunction.Description, exampleFunction.CreatedAt, exampleFunction.UpdatedAt);
    }
}
```
