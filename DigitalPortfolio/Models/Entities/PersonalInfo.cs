using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]

        public String? Name { get; set; }
        [MaxLength(100)]

        public String? Profession { get; set; }

        public DateTime BirthDate { get; set; }
        [MaxLength(20)]

        public int Mobile { get; set; }
        [MaxLength(120)]

        public String? Email { get; set; }
        [MaxLength(120)]

        public String? Address { get; set; }
        [MaxLength(20)]

        public Double Age { get; set; }
        [MaxLength(120)]

        public String? Qualification { get; set; }
    }
}
