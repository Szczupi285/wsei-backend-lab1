using Microsoft.AspNetCore.Mvc.Testing;
namespace Integration
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            await using var app = new WebApplicationFactory<Program>();
            using var clietn = app.CreateClient();

            var result = client.GetFromJsonAsync<Quiz>("/api/vi/user/quizzes/1");

           Assert.NotNull(result);
           Assert.Equal(1, result.Id);
        }
    }
}