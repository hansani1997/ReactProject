using ReactAspCrud.Models;
using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.DTO
{
    public class StudentRequestDTO
    {
       
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? ContactPerson { get; set; } = "";
        public int ContactNo { get; set; }
        public string? Email { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
    }
}
