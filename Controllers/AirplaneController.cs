using DS_CSCI3110_Final.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

public class AirplaneController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
