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
    public class CourseManager:ICourseService
    {
        private readonly ICourseDal _courseDal;
        private readonly IMapper _mapper;

        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper=mapper;
        }
        public async Task AddAsync(CreateCourseRequest createCourseRequest)
        {
            var course=_mapper.Map<Course>(createCourseRequest);
            await _courseDal.AddAsync(course);
        }
        public async Task<Paginate<GetCourseResponse>> GetListAsync()
        {
            var courses =await _courseDal.GetListAsync();
            return _mapper.Map<Paginate<GetCourseResponse>>(courses);
        }
    }
}
