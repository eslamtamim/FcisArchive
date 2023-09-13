using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCISQuestionsHub.Core.Models.UploadingModels
{
    public class FileUpload
    {
        [Key]
        public int FileId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public int FileSize { get; set; }


        [Required]
        [ForeignKey(nameof(PdfUpload))]
        public string RequestID { get; set; }
        public virtual PdfUploads PdfUpload { get; set; }

        public virtual List<FileErrors>  FileErrors { get; set; }

    }
}