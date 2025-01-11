using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool Subscribed { get; set;}
    }
}
