using AutoMapper;
using N.Core.DTOs;
using N.Core.Models;
using N.Core.Repositories;
using N.Core.Services;
using N.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Service.Services;

public class ProductService : Service<Product>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, 
        IProductRepository productRepository) : base(repository, unitOfWork)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
    {
        var products = await _productRepository.GetProductsWitCategory();

        var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
        return productsDto;

    }
}
