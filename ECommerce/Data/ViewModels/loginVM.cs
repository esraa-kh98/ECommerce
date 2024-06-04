using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.ViewModels
{
    public class loginVM
    {
        [Display(Name="Email Address")]
        [Required(ErrorMessage ="This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { set; get; }
        [Required(ErrorMessage ="This Field is Required!")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
