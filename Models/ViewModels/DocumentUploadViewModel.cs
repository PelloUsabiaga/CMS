using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CMS02.Models
{
    public class DocumentUploadViewModel
    {
        [Required]
        [DisplayName("File to upload")]
        public IFormFile FileToUpload { get; set; }
        public Document Document { get; set; }
    }
}
