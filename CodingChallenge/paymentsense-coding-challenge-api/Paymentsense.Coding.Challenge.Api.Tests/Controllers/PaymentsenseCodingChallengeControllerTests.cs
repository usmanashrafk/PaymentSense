using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Xunit;
using Moq;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.DataTransfer;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoggerService;
using Paymentsense.Coding.Challenge.Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.ComponentModel;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class PaymentsenseCodingChallengeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly ILoggerManager _logger;
        private readonly CountriesController sut;



        public PaymentsenseCodingChallengeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
            _mockLogger = new Mock<ILoggerManager>();

            sut = new CountriesController(_mockLogger.Object);

        }


        [Trait("CheckStatus","ReturnsStatusOK")]
        [Fact]
        public async Task CountryHealthCheck_Should_Return_StatusOk()
        {
            var response = await _httpClient.GetAsync("/api/Countries");

            var status = response.StatusCode;

            status.Should().Be(HttpStatusCode.OK);

        }
        [Trait("CheckStatus", "ReturnsStatusOK")]
        [Fact]
        public void GetCountries_Should_Return_StatusOK()
        {
           var response = sut.Get().Result as OkObjectResult;
            
            response.Should().BeOfType<OkObjectResult>();
            

        }

        [Trait("CheckStatus", "ReturnsStatusOK")]
        [Fact]
        public void GetCountryDetails_Should_Return_StatusOK()
        {
            var response = sut.GetCountriesDetails().Result as OkObjectResult;
            response.Should().BeOfType<OkObjectResult>();

        }

        [Trait("CheckStatus", "ReturnsStatusOK")]
        [Fact]
        public void GetCountryDetailsByName_Should_Return_StatusOK()
        {
            string country = "United Kingdom";
            var response = sut.GetCountryDetailsByName(country).Result as OkObjectResult;
            response.Should().BeOfType<OkObjectResult>();

            // Assert.IsType<OkObjectResult>(response);

        }

        [Trait("CheckStatus", "ReturnsStatusOK")]
        [Fact]
        public void GetCountryDetailsByFullName_Should_Return_StatusOK()
        {
            string country = "Pakistan";
            var response = sut.GetCountryDetailsByFullName(country).Result as OkObjectResult;
            response.Should().BeOfType<OkObjectResult>();

        }

        [Trait("ValidResponseCheck", "ReturnsData")]
        [Fact]
        public void GetCountries_Should_Return_TotalCount250()
        {
            var expected = 250;
            var response = sut.Get().Result as OkObjectResult;
           
            Assert.NotNull(response);

            var countries = response.Value as List<CountryDto>;
            Assert.NotNull(countries);

            var actual = countries.Count;
            Assert.Equal(expected, actual);

        }

        [Trait("ValidResponseCheck", "ReturnsData")]
        [Fact]
        public void GetCountries_Should_Return_Data()
        {
           
            var response = sut.Get().Result as OkObjectResult;

            Assert.NotNull(response);

            var countries = response.Value as List<CountryDto>;
            Assert.NotNull(countries);

            var actual = countries.Count;

            actual.Should().BeGreaterThan(0);

        }

        [Trait("ValidResponseCheck", "ReturnsData")]
        [Fact]
        public void GetCountriesByName_Should_Return_Data()
        {
            string country = "United Kingdom";
            var response = sut.GetCountryDetailsByName(country).Result as OkObjectResult;
            response.Should().NotBeNull();

        }


        [Trait("ValidResponseCheck", "ReturnsData")]
        [Fact]
        public void GetCountriesByFullName_InvalidFullName_Should_Return_NULL()
        {
            string country = "United Kingdom";
            var response = sut.GetCountryDetailsByFullName(country).Result as OkObjectResult;
            response.Should().BeNull();

        }
        
    }
}
