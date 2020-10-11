using ServiceStore.Api.Author.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceStore.Api.Book.Tests
{
    class AuthorServiceTest
    {
        public int AuthorBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<AcademicGrade> AcademicGradesList { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
