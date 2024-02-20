﻿using N.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Core.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWitCategory();

}
