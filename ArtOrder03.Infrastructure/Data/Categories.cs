using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Infrastructure.Data
{
    public class Categories
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public IEnumerable<Products> Products { get; init; } = new List<Products>();
    }
}
