using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Models.UploadingModels
{
    public class PdfUploads
    {
        [Key]
        [Required]
        public string RequestId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime TimeUploaded { get; set; } = DateTime.UtcNow;
        public virtual List<FileUpload> Files { get; set; }

    }
}
