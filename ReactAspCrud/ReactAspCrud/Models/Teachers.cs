using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAspCrud.Models
{
    public class Teachers
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public virtual List<Subjects> SubjectId { get; set; }
    }
}
