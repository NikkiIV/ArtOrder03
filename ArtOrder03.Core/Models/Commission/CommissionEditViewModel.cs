using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Commission
{
    public class CommissionEditViewModel
    {
        public int Id { get; init; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
