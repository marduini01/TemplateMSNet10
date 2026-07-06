# Markdown File

==================================================
EXAMPLE FUNCTION NOTIFICATION
==================================================

La cartella Notification contiene gli eventi applicativi pubblicati tramite MediatR.

A differenza di Command e Query, una Notification non restituisce una risposta diretta al chiamante, ma consente di notificare uno o più handler quando si verifica un evento.

Come esempio, per la funzionalità ExampleFunction, possiamo definire una notification chiamata ExampleFunctionCreatedNotification.

Questa notification rappresenta l'evento di avvenuta creazione di un elemento.

Un esempio di notification:

```csharp
using MediatR;

namespace Application.Features.ExampleFunction.Notification;

public sealed record ExampleFunctionCreatedNotification(Guid Id, string Code, string Description) : INotification;
```

Poi sarà necessario aggiungere uno o più handler per gestire la notification pubblicata.

```csharp
using MediatR;
using INPS.ServiceDefault.Logger;

namespace Application.Features.ExampleFunction.Notification;

public sealed class ExampleFunctionCreatedNotificationHandler : INotificationHandler<ExampleFunctionCreatedNotification>
{
	private readonly IApplicationLogger _logger;

	public ExampleFunctionCreatedNotificationHandler(IApplicationLogger logger)
	{
		_logger = logger;
	}

	public async Task Handle(ExampleFunctionCreatedNotification notification, CancellationToken cancellationToken)
	{
		await _logger.DebugAsync(
			$"ExampleFunction creata con Id '{notification.Id}' e codice '{notification.Code}'.");
	}
}
```

La pubblicazione della notification può avvenire, ad esempio, al termine di un command handler:

```csharp
await _mediator.Publish(
	new ExampleFunctionCreatedNotification(exampleFunction.Id, exampleFunction.Code, exampleFunction.Description),
	cancellationToken);
```

Questo approccio è utile per separare la logica principale da attività secondarie come logging, invio notifiche, audit o sincronizzazioni verso altri sistemi.