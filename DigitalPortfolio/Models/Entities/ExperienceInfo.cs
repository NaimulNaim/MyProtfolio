using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class ExperienceInfo
    {
        [Key]
        public int Id { get; set; }

        public String? Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public String? Company { get; set; }

        public String? Department { get; set; }

        public String? Description { get; set; }
    }
}
