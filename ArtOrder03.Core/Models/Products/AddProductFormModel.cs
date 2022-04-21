using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Products
{
    public class AddProductFormModel
    {
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }        

        public string Price { get; set; }
    }
}
