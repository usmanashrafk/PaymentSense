using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.DataTransfer;
using LoggerService;
using Paymentsense.Coding.Challenge.Api.Services;
using RestSharp;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryService : ICountryService
    {
        private const string _COUNTRYDETAILURL = "https://restcountries.eu/rest/v2/all";

        private const string _COUNTRYNAMEURL = "https://restcountries.eu/rest/v2/all";

        private const string _FILTEREDDETAILURL = "https://restcountries.eu/rest/v2/all?fields=name;population;timezones;currencies;languages;capital;borders";


        private const string _DETAILSBYNAMEURL = "https://restcountries.eu/rest/v2/name/";
       
        private const string _CONTENTTYPE = "content-type";

        private const string _CONTENTTYPEVALUE = "application/json";

        private const string _NOTFOUND = "not found";

        private readonly ILoggerManager _logger;

        public CountryService(ILoggerManager logger)
        {
            _logger = logger;
        }

        #region Private Methods


        private void AddHeaders(RestRequest request)
        {

            request.AddHeader(_CONTENTTYPE, _CONTENTTYPEVALUE);

        }


        #endregion

        public async Task<List<ResponseDto>> GetCountriesDetailsAsync()
        {
            try
            {
               
                List<ResponseDto> responseDtos = new List<ResponseDto>();
                RestClient client = new RestClient(_COUNTRYDETAILURL);


                RestRequest request = new RestRequest(Method.GET);

                AddHeaders(request);


                IRestResponse response = await client.ExecuteAsync(request);


                responseDtos = JsonConvert.DeserializeObject<List<ResponseDto>>(response.Content);

                return responseDtos;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : string.Empty);
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name} ERROR: {errorMessage}");
                throw;
            }

        }

        public async Task<IList<CountryDto>> GetCountriesAsync()
        {
            try
            {
                
                List<CountryDto> names = new List<CountryDto>();
                RestClient client = new RestClient(_COUNTRYNAMEURL);

                RestRequest request = new RestRequest(Method.GET);

                AddHeaders(request);

                IRestResponse response =  await client.ExecuteAsync(request);

                names = JsonConvert.DeserializeObject<List<CountryDto>>(response.Content);


                return names;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : string.Empty);
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name} ERROR: {errorMessage}");
                throw;
            }
        }

        public async Task<List<ResponseDto>> GetCountriesFilteredDetailsAsync()
        {
            try
            {
                List<ResponseDto> responseDtos = new List<ResponseDto>();
                RestClient client = new RestClient(_FILTEREDDETAILURL);


                RestRequest request = new RestRequest(Method.GET);

                AddHeaders(request);


                IRestResponse response = await client.ExecuteAsync(request);


                responseDtos = JsonConvert.DeserializeObject<List<ResponseDto>>(response.Content);

                return responseDtos;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : string.Empty);
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name} ERROR: {errorMessage}");
                throw;
            }
        }

        public async Task<IList<CountryDto>> GetCountryDetailsAsync(string countryName)
        {
            try
            {

                List<CountryDto> countryDetails = new List<CountryDto>();
                RestClient client = new RestClient($"{_DETAILSBYNAMEURL}{countryName}");

                RestRequest request = new RestRequest(Method.GET);

                AddHeaders(request);

                IRestResponse response = await client.ExecuteAsync(request);

                countryDetails = JsonConvert.DeserializeObject<List<CountryDto>>(response.Content);


                return countryDetails;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : string.Empty);
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name} ERROR: {errorMessage}");
                throw;
            }
        }

        
              public async Task<IList<CountryDto>> GetCountryDetailsByFullNameAsync(string countryName)
        {
            try
            {

                List<CountryDto> countryDetails = new List<CountryDto>();
                RestClient client = new RestClient($"{_DETAILSBYNAMEURL}{countryName}?fullText=true");

                RestRequest request = new RestRequest(Method.GET);

                AddHeaders(request);

                IRestResponse response = await client.ExecuteAsync(request);

                if (!response.Content.Trim().ToLower().Contains(_NOTFOUND))
                {
                    countryDetails = JsonConvert.DeserializeObject<List<CountryDto>>(response.Content);
                }
                return countryDetails;






            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : string.Empty);
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name} ERROR: {errorMessage}");
                throw;
            }
        }

    }
}
