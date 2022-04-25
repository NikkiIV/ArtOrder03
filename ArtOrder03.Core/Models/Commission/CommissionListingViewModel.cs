using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Commission
{
    public class CommissionListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Details { get; set; }

        public string Description { get; set; }
    }
}
