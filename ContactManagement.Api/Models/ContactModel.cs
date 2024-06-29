using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Api.Models
{
    public class ContactModel
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}
