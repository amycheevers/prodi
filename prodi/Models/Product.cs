using System.ComponentModel.DataAnnotations.Schema;

namespace prodi.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }
    }
}
