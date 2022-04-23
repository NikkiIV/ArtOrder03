using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Commission
{
    public class AddCommissionFormModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Type { get; set; }

        [Required]
        [MinLength(3)]
        public string Details { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }
    }
}
