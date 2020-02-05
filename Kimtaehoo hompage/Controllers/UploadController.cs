using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ImageUpload(IFormFile file) // 특정 파일을 선택했을 때 input 박스에 담긴 파일을 전송 버튼을 눌렀을때 file에 담김
        {
            // # 이미지나 파일을 업로드 할 때 필요한 구성
            // 1. path(경로) - 어디에다 저장할지 결정
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // 2. name(이름) - DateTime, GUID *GUID 전역 고유 식별자 
            // 파일 이름 image.jpg
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";
            // 3. Extension(확장자) - jpg, png ... txt
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            } 
            return Ok(new { file= "/images/upload/" + fileName, success = true});

            // # URL 접근 방식
            // ASP.NET - 호스트명/ + api/upload
            //JavaScript - 호스트명 + api/upload => http://www.example.comapi/upload

        }
    }
}