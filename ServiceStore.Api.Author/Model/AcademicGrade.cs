using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Author.Model
{
    public class AcademicGrade
    {
        public int AcademicGradeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? GraduationDate { get; set; }
    }
}
