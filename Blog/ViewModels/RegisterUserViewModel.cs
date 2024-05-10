using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class RegisterUserViewModel
    {
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


        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(5, ErrorMessage = "Пароль должен быть не менее 5 символов.")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string? PasswordConfirm { get; set; }


        public string? Code { get; set; }
    }

}
