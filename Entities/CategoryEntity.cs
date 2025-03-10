using System.Text.Json.Serialization;

namespace Pratik__Survivor.Entities
{
    public class CategoryEntity:BaseEntity
    {

        public string Name { get; set; }

        //Esnek ve kapsüllenmiş aynı zamanda Entity Framework Core,veritabanı ilişlerini yönetirken ICollection interface kullanılır.
 
        public ICollection<CompetitorEntity> Competitors { get; set; }
    }
}
