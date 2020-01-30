using Kimtaehoo_hompage.DataContext;
using Kimtaehoo_hompage.Models;
using Kimtaehoo_hompage.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq - 메서드 체이딩 (연결 시켜주는 것)
                    // ==> : A go to B
                    //var user = db.Users
                    //.FirstOrDefault(u => u.UserId == model.UserId && u.UserPassWord == model.UserPassWord);
                    var user = db.Users
                         .FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassWord.Equals(model.UserPassWord));
                    if (user != null)
                    {
                        //로그인에 성공했을 때
                        //HttpContext.Session.SetInt32(key,value);  //key는 식별자가 필요하다. value : 실제 데이터 값 (사용자 번호)
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "home");
                    }
                    //로그인에 실패했을 때
                    //사용자 ID 자체가 회원가입이 안되는 경우
                }
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "home");

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
