# Markdown File

La cartella Commands contiene i comandi specifici per la funzionalità NomeFunzione. Ogni comando rappresenta un'azione che può essere eseguita all'interno dell'applicazione, come la creazione, l'aggiornamento o l'eliminazione di dati.
Come esempio prendiamo la gestione delle News. Potresti avere comandi come CreateNewsCommand, UpdateNewsCommand e DeleteNewsCommand all'interno di questa cartella.
Un esempio di comando: 

```csharp
using MediatR;

namespace Application.Features.ExampleFunction.CreateExampleFunction;

public sealed record CreateExampleFunctionCommand(CreateExampleFunctionInput Input) : IRequest<CreateExampleFunctionResponse>;
```
Ogni comando implementa l'interfaccia IRequest di MediatR, che consente di definire il tipo di risposta attesa quando il comando viene eseguito.
Puoi aggiungere ulteriori comandi in questa cartella in base alle esigenze della tua applicazione.

Poi sarà necessario aggiungere gli handler per gestire l'esecuzione dei comandi.
```
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.ExampleFunction.CreateExampleFunction;

public sealed class CreateExampleFunctionCommandHandler : IRequestHandler<CreateExampleFunctionCommand, CreateExampleFunctionResponse>
{
    private readonly IExampleFunctionRepository _exampleFunctionRepository;

    public CreateExampleFunctionCommandHandler(
        IExampleFunctionRepository exampleFunctionRepository)
    {
        _exampleFunctionRepository = exampleFunctionRepository;
    }

    public async Task<CreateExampleFunctionResponse> Handle(CreateExampleFunctionCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;

        var exampleFunction = new ExampleFunction
        {
            Id = Guid.NewGuid(),
            Code = input.Code,
            Description = input.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _exampleFunctionRepository.AddAsync(exampleFunction, cancellationToken);

        await _exampleFunctionRepository.SaveChangesAsync(cancellationToken);

        return new CreateExampleFunctionResponse(exampleFunction.Id, exampleFunction.Code, exampleFunction.Description, exampleFunction.CreatedAt);
    }
}
```