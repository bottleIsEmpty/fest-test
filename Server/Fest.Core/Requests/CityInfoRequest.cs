using System.ComponentModel.DataAnnotations;

namespace Fest.Core.DTOs
{
    public class CityInfoRequest
    {
        [Required]
        public string ZipCode { get; set; }
    }
}