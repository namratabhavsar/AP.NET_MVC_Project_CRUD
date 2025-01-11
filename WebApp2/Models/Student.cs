using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebApp2.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name Can not be empty")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]

        public string Email { get; set; }

        [Required]
        [Range(0,10,ErrorMessage = "Please Enter correct phone number")]
        public string Phone { get; set; }

        [Required]
        public bool Subscribed { get; set;}
    }
}
