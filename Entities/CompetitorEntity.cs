using System.Text.Json.Serialization;

namespace Pratik__Survivor.Entities
{
    public class CompetitorEntity:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public CategoryEntity Category { get; set; }
    }
}
