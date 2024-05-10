using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditUserViewModel
    {
        [Key]
        public string? Id { get; set; }


        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Не указан Email адрес")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Номер телефона обязателен для заполнения.")]
        [Display(Name = "Номер телефона")]
        public string? Phone { get; set; }
    }

}
