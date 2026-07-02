# Markdown File

==================================================
CONTROLLER - GET EXAMPLE FUNCTION
==================================================

Il controller ha il compito di ricevere la richiesta HTTP, costruire la query e inviarla a MediatR.

L'esempio seguente mostra come richiamare la query GetExampleFunctionQuery da un endpoint HTTP GET.

```csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ExampleFunction.GetExampleFunction;

namespace Api.Controllers;

[ApiController]
[Route("api/example-function")]
public sealed class ExampleFunctionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleFunctionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetExampleFunctionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetExampleFunctionResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var input = new GetExampleFunctionInput(id);

        var query = new GetExampleFunctionQuery(input);

        var response = await _mediator.Send(query, cancellationToken);

        return Ok(response);
    }
}
```
==================================================
CONTROLLER - CREATE EXAMPLE FUNCTION
==================================================

Il controller ha il compito di ricevere la richiesta HTTP, costruire il command e inviarlo a MediatR.

L'esempio seguente mostra come richiamare il command CreateExampleFunctionCommand da un endpoint HTTP POST.

```csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ExampleFunction.CreateExampleFunction;

namespace Api.Controllers;

[ApiController]
[Route("api/example-function")]
public sealed class ExampleFunctionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleFunctionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateExampleFunctionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateExampleFunctionResponse>> Create([FromBody] CreateExampleFunctionRequest request, CancellationToken cancellationToken)
    {
        var input = new CreateExampleFunctionInput(request.Code, request.Description);

        var command = new CreateExampleFunctionCommand(input);

        var response = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetExampleFunctionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetExampleFunctionResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var input = new GetExampleFunctionInput(id);

        var query = new GetExampleFunctionQuery(input);

        var response = await _mediator.Send(query, cancellationToken);

        return Ok(response);
    }
}
```
==================================================
CONTROLLER - UPDATE EXAMPLE FUNCTION
==================================================

Il controller ha il compito di ricevere la richiesta HTTP, costruire il command e inviarlo a MediatR.

L'esempio seguente mostra come richiamare il command UpdateExampleFunctionCommand da un endpoint HTTP PUT.

```csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ExampleFunction.UpdateExampleFunction;

namespace Api.Controllers;

[ApiController]
[Route("api/example-function")]
public sealed class ExampleFunctionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleFunctionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateExampleFunctionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UpdateExampleFunctionResponse>> Update(Guid id, [FromBody] UpdateExampleFunctionRequest request, CancellationToken cancellationToken)
    {
        var input = new UpdateExampleFunctionInput(id, request.Code, request.Description);

        var command = new UpdateExampleFunctionCommand(input);

        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}
```
==================================================
CONTROLLER - DELETE EXAMPLE FUNCTION
==================================================

Il controller ha il compito di ricevere la richiesta HTTP, costruire il command e inviarlo a MediatR.

L'esempio seguente mostra come richiamare il command DeleteExampleFunctionCommand da un endpoint HTTP DELETE.

```csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ExampleFunction.DeleteExampleFunction;

namespace Api.Controllers;

[ApiController]
[Route("api/example-function")]
public sealed class ExampleFunctionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleFunctionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(DeleteExampleFunctionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeleteExampleFunctionResponse>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var input = new DeleteExampleFunctionInput(id);

        var command = new DeleteExampleFunctionCommand(input);

        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}
```
