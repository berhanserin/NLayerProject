using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Web.DTOs;

namespace NLayerProject.Web.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
