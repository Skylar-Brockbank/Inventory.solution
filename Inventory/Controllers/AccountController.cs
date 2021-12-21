using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AccountController : Controller
    {

      [HttpGet("/Accounts")]
      public ActionResult Index()
      {
        return View();
      }

    }
}