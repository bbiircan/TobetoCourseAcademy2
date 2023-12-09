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
         private ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            Course course =new Course();
            course.Id = Guid.NewGuid();
            course.InstructorId = Guid.NewGuid();
            course.CategoryId = Guid.NewGuid();
            course.Description=createCourseRequest.Description;
            course.Name=createCourseRequest.Name;
            course.Price=createCourseRequest.Price;
            course.Url=createCourseRequest.Url;

            Course createdCourse= await _courseDal.AddAsync(course);

            CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            createdCourseResponse.Id = createdCourse.Id;
            createdCourseResponse.InstructorId = createdCourse.InstructorId;
            createdCourseResponse.CategoryId = createdCourse.CategoryId;
            createdCourseResponse.Price=createCourseRequest.Price;
            createdCourseResponse.Name=createCourseRequest.Name;
            createdCourseResponse.Price = createCourseRequest.Price;
            createdCourseResponse.Url=createCourseRequest.Url;
            return createdCourseResponse;

        }

        public async Task<Paginate<Course>> GetListAsync()
        {
            var result = await _courseDal.GetListAsync();
            return result;
        }
    }
}
