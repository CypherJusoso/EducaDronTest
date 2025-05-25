using System.ComponentModel.DataAnnotations;

namespace EducadronAPI.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage ="A name is required")]
        public string Name { get; set; } = "";
    }
}
