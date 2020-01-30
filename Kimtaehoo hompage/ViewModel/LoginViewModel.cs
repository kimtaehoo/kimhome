using System.ComponentModel.DataAnnotations;
namespace Kimtaehoo_hompage.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="사용자 ID를 입력하세요.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 ID를 입력하세요.")]
        public string UserPassWord { get; set; }
    }
}
