using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webOdevi.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Session'dan kullanıcı bilgilerini alıp ViewData'ya atıyoruz
            ViewData["UserEmail"] = HttpContext.Session.GetString("UserEmail");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            base.OnActionExecuting(context);
        }
    }
}
