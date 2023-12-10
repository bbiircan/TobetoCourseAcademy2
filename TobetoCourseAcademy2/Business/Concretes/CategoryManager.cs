using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;    
            _mapper = mapper;
        }
        public async Task AddAsync(CreateCategoryRequest createCategoryRequest)
        { 
            var category = _mapper.Map<Category>(createCategoryRequest);
            await _categoryDal.AddAsync(category);
        }

        public async Task<Paginate<GetCategoryResponse>> GetListAsync()
        {
            var categories = await _categoryDal.GetListAsync();
            var mappedCategories=_mapper.Map<Paginate<GetCategoryResponse>>(categories);
            return mappedCategories;
        }
    }
}
