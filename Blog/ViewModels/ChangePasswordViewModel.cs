using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Key]
        public string? Id { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Не указан Email адрес")]
        public string? Email { get; set; }
        [Display(Name = "Старый пароль")]
        [Required(ErrorMessage = "Не указан старый пароль")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        [Display(Name = "Новый пароль")]
        [Required(ErrorMessage = "Не указан новый пароль")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        [MinLength(5, ErrorMessage = "Пароль должен быть не менее 5 символов.")]
        [Display(Name = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? NewPasswordConfirm { get; set; }
    }

}
