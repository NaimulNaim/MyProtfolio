using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class EducationInfo
    {
        [Key]
        public int Id { get; set; }

        public String? Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String? Institution { get; set; }

        public String? Department { get; set; }

        public String? Description { get; set; }

        public Double? Grade { get; set; }

    }
}
