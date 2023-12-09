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
    public class InstructorManager:IInstructorService
    {
         private IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }
        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor=new Instructor();
            instructor.Id = Guid.NewGuid();
            instructor.Name=createInstructorRequest.Name;

            Instructor createdInstructor =await _instructorDal.AddAsync(instructor);

            CreatedInstructorResponse createdInstructorResponse = new CreatedInstructorResponse();
            createdInstructorResponse.Name = createInstructorRequest.Name;
            return createdInstructorResponse;
        }

        public async Task<Paginate<Instructor>> GetListAsync()
        {
            var result = await _instructorDal.GetListAsync();
            return result;
        }
    }
}
