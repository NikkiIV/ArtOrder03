using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Commission
{
    public class UserCommissionViewModel
    {
        public string UserId { get; init; }

        public IEnumerable<CommissionListingViewModel>? Commissions { get; set; }
    }
}
