using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class FileInfo
    {
        [Key]
        public int Id { get; set; }

        public String? Title { get; set; }

        public String? Description { get; set; }

        public string? Icon { get; set;}
    }
}
