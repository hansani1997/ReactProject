using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAspCrud.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? ContactPerson { get; set; } = "";
        public int ContactNo { get; set;  }
        public string? Email { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public int ClassRoomId { get; set; }
        public int Age
        {
            get
            {
                // Calculate the age based on the current date and the DateOfBirth
                int age = DateTime.Today.Year - DateOfBirth.Year;

                // Check if the birthday has already occurred this year
                if (DateTime.Today < DateOfBirth.Date.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }
     }
}
