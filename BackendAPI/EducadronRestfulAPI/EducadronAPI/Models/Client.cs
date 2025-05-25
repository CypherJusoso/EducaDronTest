using Microsoft.EntityFrameworkCore;

namespace EducadronAPI.Models
{
    [Index("Name", IsUnique = true)]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
