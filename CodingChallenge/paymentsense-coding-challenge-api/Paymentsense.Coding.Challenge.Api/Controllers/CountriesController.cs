using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Api.DataTransfer;
using LoggerService;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILoggerManager _logger;
       
        public CountriesController(ILoggerManager logger)
        {
            _logger = logger;
            _countryService = new CountryService(_logger);
        }
 


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _countryService.GetCountriesAsync();

                if (results == null || results.Count == 0)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch(Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("GetCountriesDetails")]
        public async Task<IActionResult> GetCountriesDetails()
        {
            try
            {
                var results = await _countryService.GetCountriesDetailsAsync();

                if (results == null || results.Count == 0)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
            
        }

        

        [HttpGet]
        [Route("GetCountriesFilteredDetails")]
        public async Task<IActionResult> GetCountriesFilteredDetails()
        {
            try
            {
                var results = await _countryService.GetCountriesFilteredDetailsAsync();

                if (results == null || results.Count == 0)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("GetCountryDetailsByName/{name}")]
        public async Task<IActionResult> GetCountryDetailsByName(string name)
        {
            try
            {
                var results = await _countryService.GetCountryDetailsAsync(name);

                if (results == null || results.Count == 0)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("GetCountryDetailsByFullName/{name}")]
        public async Task<IActionResult> GetCountryDetailsByFullName(string name)
        {
            try
            {
                var results = await _countryService.GetCountryDetailsByFullNameAsync(name);
               
                if (results == null || results.Count == 0)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch (Exception)
            {
                return new NotFoundObjectResult(name);
            }
        }

    }
}
