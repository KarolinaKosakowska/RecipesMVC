using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.DTO
{
    public class RecipesDTO
    {
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name="Tytuł")]
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }

        public string Image { get; set; }
        [Required(ErrorMessage = "Body jest wymagane")]
        [Display(Name="Opis")]
        public string Body { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
