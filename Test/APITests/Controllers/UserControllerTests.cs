using Application.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Test.APITests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private WebApplicationFactory<API.Controllers.UserController> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<API.Controllers.UserController>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void Teardown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        [Test]
        public async Task RegisterUser_Success()
        {
            // Arrange: Förbered testdata, t.ex. användarens registreringsuppgifter.
            var registrationData = new
            {
                Username = "testuser1",
                Password = "testpassword1"
            };

            // Act: Skicka en POST-begäran till registreringsendpunkt.
            var response = await _client.PostAsJsonAsync("http://localhost/api/User/register", registrationData);

            // Assert: Kontrollera att servern svarar med en framgångsstatuskod.
            Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo("User registered successfully"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // Du kan även utföra ytterligare kontroller baserat på dina krav och implementering.
            // Till exempel, kontrollera att svaret innehåller förväntade data eller meddelanden.
        }

        [Test]
        public async Task CanRegisterAndLoginUser()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Register a user
            var registrationDto = new UserRegistrationDto
            {
                Username = "testuser",
                Password = "testpassword"
            };

            var registrationContent = new StringContent(JsonConvert.SerializeObject(registrationDto), Encoding.UTF8, "application/json");
            var registrationResponse = await client.PostAsync("/api/User/register", registrationContent);
            registrationResponse.EnsureSuccessStatusCode();

            // Login with the registered user
            var loginDto = new LoginRequest
            {
                Username = "testuser",
                Password = "testpassword"
            };

            var loginContent = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var loginResponse = await client.PostAsync("/api/User/login", loginContent);
            loginResponse.EnsureSuccessStatusCode();

            // Use the JWT token for subsequent requests
            var token = await loginResponse.Content.ReadAsStringAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Perform a request to a protected resource (if applicable)
            // ...

            // Assert
            Assert.That(loginResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // Add more assertions based on your specific requirements
        }
    }
}
