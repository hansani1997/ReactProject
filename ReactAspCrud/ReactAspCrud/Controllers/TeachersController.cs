using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly StudentsDbContext _studentDbContext;

        public TeachersController(StudentsDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetTeachers")]
        public async Task<IEnumerable<Teachers>> GetTeachers()
        {
            return await _studentDbContext.Teachers.ToListAsync();
        }

        [HttpPost]
        [Route("AddTeacher")]
        public async Task<Teachers> AddTeacher(Teachers objTeacher)
        {
            _studentDbContext.Teachers.Add(objTeacher);
            await _studentDbContext.SaveChangesAsync();
            return objTeacher;
        }

        [HttpPatch]
        [Route("UpdateTeacher/{id}")]
        public async Task<Teachers> UpdateTeacher(Teachers objTeacher)
        {
            _studentDbContext.Entry(objTeacher).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objTeacher;
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public bool DeleteTeacher(int id)
        {
            bool isDelete = false;
            var teacher = _studentDbContext.Teachers.Find(id);
            if (teacher != null)
            {
                isDelete = true;
                _studentDbContext.Entry(teacher).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                isDelete = false;
            }

            return isDelete;
        }
    }
}
