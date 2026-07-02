# Markdown File

Come esempio, per la funzionalità ExampleFunction, possiamo definire un comando chiamato UpdateExampleFunctionCommand.
Questo comando rappresenta l'azione di aggiornamento di un elemento già esistente.
Un esempio di comando di update:
```csharp
using MediatR;

namespace Application.Features.ExampleFunction.UpdateExampleFunction;

public sealed record UpdateExampleFunctionCommand(UpdateExampleFunctionInput Input) : IRequest<UpdateExampleFunctionResponse>;

```
Il comando riceve un oggetto complesso chiamato UpdateExampleFunctionInput, che contiene i dati necessari per eseguire l'aggiornamento.
Poi sarà necessario aggiungere l'handler per gestire l'esecuzione del comando di update.
```
using MediatR;
using Application.Interfaces;

namespace Application.Features.ExampleFunction.UpdateExampleFunction;

public sealed class UpdateExampleFunctionCommandHandler : IRequestHandler<UpdateExampleFunctionCommand, UpdateExampleFunctionResponse>
{
    private readonly IExampleFunctionRepository _exampleFunctionRepository;

    public UpdateExampleFunctionCommandHandler(IExampleFunctionRepository exampleFunctionRepository)
    {
        _exampleFunctionRepository = exampleFunctionRepository;
    }

    public async Task<UpdateExampleFunctionResponse> Handle(UpdateExampleFunctionCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;

        var exampleFunction = await _exampleFunctionRepository.GetByIdAsync(input.Id, cancellationToken);

        if (exampleFunction is null)
        {
            throw new KeyNotFoundException($"ExampleFunction con id '{input.Id}' non trovata.");
        }

        exampleFunction.Code = input.Code;
        exampleFunction.Description = input.Description;
        exampleFunction.UpdatedAt = DateTime.UtcNow;

        await _exampleFunctionRepository.UpdateAsync(exampleFunction, cancellationToken);

        await _exampleFunctionRepository.SaveChangesAsync(cancellationToken);

        return new UpdateExampleFunctionResponse(
            exampleFunction.Id,
            exampleFunction.Code,
            exampleFunction.Description,
            exampleFunction.UpdatedAt.Value);
    }
}
```
