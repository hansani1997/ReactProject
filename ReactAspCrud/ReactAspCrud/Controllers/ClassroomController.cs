using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly StudentsDbContext _studentDbContext;

        public ClassroomController(StudentsDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetClass")]
        public async Task<IEnumerable<ClassRoom>> GetClass()
        {
            return await _studentDbContext.ClassRoom.ToListAsync();
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<ClassRoom> AddClass(ClassRoom objClass)
        {
            _studentDbContext.ClassRoom.Add(objClass);
            await _studentDbContext.SaveChangesAsync();
            return objClass;
        }

        [HttpPatch]
        [Route("UpdateClass/{id}")]
        public async Task<ClassRoom> UpdateClass(ClassRoom objClass)
        {
            _studentDbContext.Entry(objClass).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objClass;
        }

        [HttpDelete]
        [Route("DeleteClass/{id}")]
        public bool DeleteClass(int id) 
        { 
            bool isDelete = false;
            var classRoom = _studentDbContext.ClassRoom.Find(id);

            if (classRoom != null)
            {
                isDelete = true;
                _studentDbContext.Entry(classRoom).State = EntityState.Deleted;
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
