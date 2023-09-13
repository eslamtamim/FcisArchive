using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCISQuestionsHub.Core.Models.UploadingModels
{
    public class FileErrors
    {
        [Key]
        public int ErrorId { get; set; }
        [Required]
        public string ErrorMessage { get; set; }

        [Required]
        public string ErrorTitle { get; set; }
        [Required]
        public string ErrorDescription { get; set; }

        [ForeignKey(nameof(File))]
        public int FileId { get; set; }
        [Required]
        public virtual FileUpload File { get; set; }


    }
}