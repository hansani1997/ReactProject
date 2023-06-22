using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentsDbContext _studentDbContext;

        public SubjectController(StudentsDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetSubjects")]
        public async Task<IEnumerable<Subjects>> GetSubjects()
        {
            return await _studentDbContext.Subjects.ToListAsync();
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<Subjects> AddSubject(Subjects objSubject)
        {
            _studentDbContext.Subjects.Add(objSubject);
            await _studentDbContext.SaveChangesAsync();
            return objSubject;
        }

        [HttpPatch]
        [Route("UpdateSubject/{id}")]
        public async Task<Subjects> UpdateSubject(Subjects objSubject)
        {
            _studentDbContext.Entry(objSubject).State= EntityState.Modified;
            _studentDbContext.SaveChangesAsync();
            return objSubject;
        }

        [HttpDelete]
        [Route("DeleteSubject/{id}")]
        public bool DeleteSubject(int id) 
        {
            bool isDelete = false;
            var subject = _studentDbContext.Subjects.Find(id);
            if (subject != null)
            {
                isDelete = true;
                _studentDbContext.Entry(subject).State= EntityState.Deleted;
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
