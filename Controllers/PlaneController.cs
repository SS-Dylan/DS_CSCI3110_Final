using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

public class PlaneController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
