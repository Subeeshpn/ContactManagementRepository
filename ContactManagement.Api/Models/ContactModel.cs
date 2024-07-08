using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Api.Models
{
    public class ContactModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string emailid { get; set; }
    }
}
