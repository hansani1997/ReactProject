using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public virtual Teachers Teachers { get; set; }
        public int TeacherId { get; set; }
    }
}