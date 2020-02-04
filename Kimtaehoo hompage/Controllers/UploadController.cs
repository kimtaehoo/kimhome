using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Kimtaehoo_hompage.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment; // asp.net core에 있는 환경이나 환경을 추적할 수 있는 매개체가 되는 역할 

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost, Route("api/upload")]
        public IActionResult ImageUpload(IFormFile file) // 특정 파일을 선택했을 때 input 박스에 담긴 파일을 전송 버튼을 눌렀을때 file에 담김
        {
            // # 이미지나 파일을 업로드 할 때 필요한 구성
            // 1. path(경로) - 어디에다 저장할지 결정
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // 2. name(이름) - DateTime, GUID *GUID 전역 고유 식별자 
            var fileName = file.FileName;
            // 3. Extension(확장자) - jpg, png ... txt
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok();

            // # URL 접근 방식
            // ASP.NET - 호스트명/ + api/upload
            //JavaScript - 호스트명 + api/upload => http://www.example.comapi/upload

        }
    }
}