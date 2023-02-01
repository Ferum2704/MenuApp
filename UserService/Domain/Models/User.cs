using Newtonsoft.Json;

namespace UserService.Domain.Models
{
    public class User
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;
    }
}
