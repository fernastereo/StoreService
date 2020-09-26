using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Model
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<AcademicGrade> AcademicGradesList { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
