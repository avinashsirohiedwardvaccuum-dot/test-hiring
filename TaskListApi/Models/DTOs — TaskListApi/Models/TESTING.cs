[Fact]
public async Task GetTask_ReturnsNotFound_WhenIdDoesNotExist()
{
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/api/tasks/999999");

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
}

[Fact]
public async Task PostTask_ReturnsBadRequest_WhenTitleIsMissing()
{
    var client = _factory.CreateClient();
    var payload = new { Title = "" };

    var response = await client.PostAsJsonAsync("/api/tasks", payload);

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
}

{

var resv
