using System.ComponentModel.DataAnnotations;

namespace Kimtaehoo_hompage.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key] // PK 설정
        public int UserNo { get; set; }
        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage ="사용자 이름을 입력하세요")]  // Not Null 설정 / 반드시 사용자에게 입력을 받아야함
        public string UserName { get; set; }
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "사용자 ID를 입력하세요")]  // Not Null 설정
        public string UserId { get; set; }
        /// <summary>
        /// 사용자 PassWord
        /// </summary>
        [Required(ErrorMessage = "사용자 PassWord를 입력하세요")]  // Not Null 설정
        public string UserPassWord { get; set; }
    }
}
