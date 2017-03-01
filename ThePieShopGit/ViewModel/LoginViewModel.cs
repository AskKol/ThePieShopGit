using System.ComponentModel.DataAnnotations;
namespace ThePieShopGit.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        [Required][Display(Name="User name")]
        public string UserName { get; set; }

        [Required][DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}