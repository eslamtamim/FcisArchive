using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Models
{
    public class StudentQuestionAnswer
    {
        [Required]
        public string studentsId { get; set; }

       [Required]
       public long questionId { get; set; }
        [Required]

        public long  answerId { get; set; }
        [Required]

        public virtual StudentUser student { get; set; }
        public virtual Question question { get; set; }
        public virtual Answer answer { get; set; }

    }
}
