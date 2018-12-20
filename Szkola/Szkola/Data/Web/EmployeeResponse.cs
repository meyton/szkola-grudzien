using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Web
{
    public class EmployeeResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("data")]
        public Employee Data { get; set; }
    }

    public class Employee
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
