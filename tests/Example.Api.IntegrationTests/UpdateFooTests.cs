using System.Net;
using System.Text;
using AwesomeAssertions;

namespace Example.Api.IntegrationTests;

public class UpdateFooTests(FooApplicationFactory app) : IClassFixture<FooApplicationFactory>
{
    [Fact]
    public async Task When_Updating_Foo_It_Should_Return_Updated_Foo()
    {
        using var client = app.CreateClient();
        var result = await client.PutAsync("/foo",
            new StringContent(
                """
                {
                    "Name": "test"
                }
                """, encoding: Encoding.UTF8, mediaType: "application/json"));
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}