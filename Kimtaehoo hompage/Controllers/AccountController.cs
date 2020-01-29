using Kimtaehoo_hompage.DataContext;
using Kimtaehoo_hompage.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kimtaehoo_hompage.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [HttpGet] 
        public IActionResult Login() // 로그인
        {
            return View();
        }
        public IActionResult Register() //회원가입
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid) // 사용자에게 필수 입력 내용들이 모두 입력을 받았는지 확인하는 명령
            {
                using (var db = new AspnetNoteDbContext()) //false가 나오면 using문 사용 불가 / model로 돌아간다
                {
                    db.Users.Add(model); // 메모리로 올리는 것
                    db.SaveChanges(); // 실제 sql에 저장하는 명령 
                }
                return RedirectToAction("Index", "Home"); // 다른 뷰로 전달 할 때 홈 컨트롤러에 있는 인덱스 뷰로 전달을 하는 명령
            }
            return View(model);
        }

    }
}
