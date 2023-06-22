using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.DTO;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //for read the data from database
        private readonly StudentsDbContext _studentDbContext; 

        public StudentController(StudentsDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudents")]

        public async Task<IEnumerable<Students>> GetStudents()
        {
            //get details about students through the database as a list
            return await _studentDbContext.Students.Include(x => x.ClassRoom).ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Students> AddStudent(StudentRequestDTO objStudent)
        {
            Students student = new Students();
            student.FirstName = objStudent.FirstName;
            student.LastName = objStudent.LastName;
            student.Email = objStudent.Email;
            student.ContactPerson = objStudent.ContactPerson;
            student.DateOfBirth = objStudent.DateOfBirth;
            student.ClassRoomId = objStudent.ClassId;
           

            _studentDbContext.Students.Add(student); //add into database created student
            await  _studentDbContext.SaveChangesAsync(); //save added student in db
            return student;
        }
        
        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Students> UpdateStudent(Students objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool isDelete = false;
            var student = _studentDbContext.Students.Find(id);
            if (student != null)
            {
                isDelete = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                isDelete= false;
            }

            return isDelete;
        }

    }
}
