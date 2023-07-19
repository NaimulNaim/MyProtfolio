using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Models.Entities
{
    public class SocialMediaInfo
    {
        [Key]
        public int Id { get; set; }

        public String? PersonalInfoId { get; set; }

        public String? SocialMediaName { get; set; }

        public String? SocialMediaUrl { get; set; }

    }
}
