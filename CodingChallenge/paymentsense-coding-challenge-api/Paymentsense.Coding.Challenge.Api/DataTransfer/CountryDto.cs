using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.DataTransfer
{
    public class CountryDto
    {
        public string name { get; set; }
        public string capital { get; set; }
        public int population { get; set; }
        public List<string> timezones { get; set; }
        public List<Currency> currencies { get; set; }
        public List<Language> languages { get; set; }
        public List<string> borders { get; set; }

        public string flag { get; set; }



    }
}
