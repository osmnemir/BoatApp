﻿using N.Core.DTOs;
using N.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Core.Services;

public interface IProductService : IService<Product>
{
    Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();


}
