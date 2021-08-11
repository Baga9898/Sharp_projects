using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainAdiLink.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Имя")]
        public string CategoryName { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public List<Weblink> Weblinks { get; set; }

        public Category()
        {
            Weblinks = new List<Weblink>();
        }
    }
}
