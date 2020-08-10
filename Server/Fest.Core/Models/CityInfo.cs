using System;

namespace Fest.Core.Models
{
    public class CityInfo
    {
        public int? Id { get; set; }

        public string Temperature { get; set; }

        public string CityName { get; set; }

        public string ZipCode { get; set; }

        public string TimezoneName { get; set; }

        public int TimezoneOffset { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}