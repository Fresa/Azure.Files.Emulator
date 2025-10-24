using Example.Api.Foo.UpdateFoo.Content._200;

namespace Example.Api.Foo.UpdateFoo;

internal partial class Operation
{
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var response = new Response.OK200
        {
            ApplicationJson = ApplicationJson.Create(
                name: request.Body.ApplicationJson?.Name)
        };
        return Task.FromResult<Response>(response);
    }
}