using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using BackEnd.Repository;
using BackEnd.Models;

namespace BackEnd.Controllers;

[ApiController]
[Route("/")]
public class webScrapController : Controller
{
    private readonly IAlimentsRepository _repository;
    public webScrapController(IAlimentsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult get()
    {
        WebScrap webScrap = new WebScrap();

        var response = webScrap.scrap();

        return Ok(response);
    }

    [Route("addAliment")]
    [HttpGet]
    public IActionResult addAliment()
    {
        WebScrap webScrap = new WebScrap();
        var response = webScrap.scrap();
    
        var test = new IAliment
        {
            AlimentId = response[0].AlimentId,
            name = response[0].name,
            scientificName = response[0].scientificName,
            group = response[0].group,
            brand = response[0].brand
        };

        return Created("", _repository.AddAliment(test));
    }
}
