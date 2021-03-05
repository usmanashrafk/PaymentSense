using Paymentsense.Coding.Challenge.Api.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface ICountryService
    {
        Task<List<ResponseDto>> GetCountriesDetailsAsync();

        Task<IList<CountryDto>> GetCountriesAsync();

        Task<List<ResponseDto>> GetCountriesFilteredDetailsAsync();

        Task<IList<CountryDto>> GetCountryDetailsAsync(string countryName);
        Task<IList<CountryDto>> GetCountryDetailsByFullNameAsync(string countryName);
    }
}
