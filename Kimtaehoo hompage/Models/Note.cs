using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kimtaehoo_hompage.Models
{
    public class Note
    {
        [Key]
        public int NoteNo { get; set; }
        [Required]
        public string NoteTitle { get; set; }
        [Required]
        public string NoteContents { get; set; }
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")] //외래키 
        public virtual User user { get; set; } //프레임워크에서 다른 테이블의 데이터를 가져올 때 virtual 키워드 사용

    }
}
