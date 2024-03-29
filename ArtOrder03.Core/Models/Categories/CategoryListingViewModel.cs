﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtOrder03.Core.Models.Categories
{
    public class CategoryListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string ImageUrl { get; set; }

        public string Description { get; init; }
    }
}
