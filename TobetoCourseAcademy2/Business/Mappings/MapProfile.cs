using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CreateCategoryRequest>().ReverseMap(); 
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Category, GetCategoryResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetCategoryResponse>>().ReverseMap();


            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, UpdateCourseRequest>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();
            CreateMap<Course, GetCourseResponse>().ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetCourseResponse>>().ReverseMap();


            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetInstructorResponse>>().ReverseMap();
        }
    }
}
