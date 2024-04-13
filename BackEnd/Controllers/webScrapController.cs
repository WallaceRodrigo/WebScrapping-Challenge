using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;

namespace BackEnd.Controllers;

[ApiController]
[Route("/")]
public class webScrapController : Controller
{
    [HttpGet]
    public IActionResult get()
    {
        WebScrap webScrap = new WebScrap();

        var response = webScrap.scrap();

        return Ok(response);
    }
}
