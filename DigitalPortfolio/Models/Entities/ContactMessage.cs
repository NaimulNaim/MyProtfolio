using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }

        public String? Name { get; set; }

        public String? Email { get; set; }

        public String? Subject { get; set; }

        public String? Message{ get; set; }

        public Boolean IsSeen { get; set; }
    }
}
