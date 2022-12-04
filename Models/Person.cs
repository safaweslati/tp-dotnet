using System.ComponentModel.DataAnnotations;

namespace tp3dotnet.Models
{
    public class Person
    {
        public int id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public DateTime Date_birth { get; set; }
        public string? image { get; set; }
        public string? country { get; set; }

    }
}
