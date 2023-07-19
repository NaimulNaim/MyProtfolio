using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class CategoryInfo
    {
        [Key]
        public int Id { get; set; }

        public String? Name { get; set; }
    }
}
