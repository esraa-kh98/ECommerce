using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { set; get; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Not Identical!")]
        public string ConfirmPassword { set; get; }
    }
}
