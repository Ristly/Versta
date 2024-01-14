using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace VerstaWebApp.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string StatusCodeDescription => ReasonPhrases.GetReasonPhrase(StatusCode); 
    }
}
