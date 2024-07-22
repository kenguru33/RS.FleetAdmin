using Microsoft.AspNetCore.Mvc;

namespace RS.FleetAdmin.Gateway.Controllers;

public class GatewayController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}