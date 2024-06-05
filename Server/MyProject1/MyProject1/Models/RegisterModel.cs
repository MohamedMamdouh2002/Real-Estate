using System.ComponentModel.DataAnnotations;

namespace MyProject1.Models
{
    public class RegisterModel
    {
        [StringLength(100)]
        public string FullName { get; set; }
        public string Username { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }
        [MinLength(11),MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Range(21, 150)]
        public int Age { get; set; }
    }
}