namespace Example.Api.Foo.UpdateFoo;

internal partial class Operation
{
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var a = new Response.OK200();
        throw new NotImplementedException();
    }
}