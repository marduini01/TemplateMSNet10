# Markdown File

==================================================
DELETE EXAMPLE FUNCTION
==================================================

La cartella Commands contiene anche i comandi dedicati all'eliminazione dei dati.

Come esempio, per la funzionalità ExampleFunction, possiamo definire un comando chiamato DeleteExampleFunctionCommand.

Questo comando rappresenta l'azione di eliminazione di un elemento esistente.

Un esempio di comando di delete:

```csharp
using MediatR;

namespace Application.Features.ExampleFunction.DeleteExampleFunction;

public sealed record DeleteExampleFunctionCommand(DeleteExampleFunctionInput Input) : IRequest<DeleteExampleFunctionResponse>;
```
Poi sarà necessario aggiungere l'handler per gestire l'esecuzione del comando di delete.
```csharp
using MediatR;
using Application.Interfaces;

namespace Application.Features.ExampleFunction.DeleteExampleFunction;

public sealed class DeleteExampleFunctionCommandHandler : IRequestHandler<DeleteExampleFunctionCommand, DeleteExampleFunctionResponse>
{
    private readonly IExampleFunctionRepository _exampleFunctionRepository;

    public DeleteExampleFunctionCommandHandler(IExampleFunctionRepository exampleFunctionRepository)
    {
        _exampleFunctionRepository = exampleFunctionRepository;
    }

    public async Task<DeleteExampleFunctionResponse> Handle(DeleteExampleFunctionCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;

        var exampleFunction = await _exampleFunctionRepository.GetByIdAsync(input.Id, cancellationToken);

        if (exampleFunction is null)
        {
            throw new KeyNotFoundException(
                $"ExampleFunction con id '{input.Id}' non trovata.");
        }

        await _exampleFunctionRepository.DeleteAsync(exampleFunction, cancellationToken);

        await _exampleFunctionRepository.SaveChangesAsync(cancellationToken);

        return new DeleteExampleFunctionResponse(input.Id, true, "ExampleFunction eliminata correttamente.");
    }
}
```
