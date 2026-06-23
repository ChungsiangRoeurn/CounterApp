using System.Collections.Generic;

namespace CounterApp.Models
{
    public class OmdbResponse
    {
        public List<OmdbMovie> Search { get; set; } = new();
        public string TotalResults { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
    }
}