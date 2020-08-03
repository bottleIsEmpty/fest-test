using System.ComponentModel.DataAnnotations;

namespace Fest.Core.Requests
{
    public class CityInfoRequest
    {
        [Required]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }
    }
}