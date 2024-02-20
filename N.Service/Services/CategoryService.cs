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
public class CategoryService : Service<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, 
        IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
    {
        var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);

        var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

        return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
    }
}