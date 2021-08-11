using System.ComponentModel.DataAnnotations;

namespace MainAdiLink.Models
{
    public class Weblink
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        /*[RegularExpression(@"", ErrorMessage = "Некорректное имя")]*/
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Имя")]
        public string NameOfLink { get; set; }

        /*[RegularExpression(@"", ErrorMessage = "Некорректный адрес")]*/
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        /*[DataType(DataType.Url)]*/
        [Display(Name = "Адрес")]
        public string Url { get; set; }

        [Display(Name = "Короткое описание")]
        public string ShortDescription { get; set; }

        [Display(Name = "Длинное описание")]
        public string LongDescription { get; set; }
        
        [Display(Name = "Избранное")]
        public bool IsFavorite { get; set; }

        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public virtual Category Category { get; set; }
    }
}
