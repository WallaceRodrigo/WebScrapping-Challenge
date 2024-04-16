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
  public ActionResult<IEnumerable<IAliment>> get()
  {
    WebScrap webScrap = new WebScrap();

    var scrapResponse = webScrap.Scrap();

    return Ok(scrapResponse);
  }

  [HttpPost("addAliment")]
  public IActionResult addAliment()
  {
    WebScrap webScrap = new WebScrap();
    var scrapResponse = webScrap.Scrap();

    if (scrapResponse == null)
    {
      return BadRequest();
    }

    var dbResponse = scrapResponse.Select(a =>
    {
      var aliment = new IAliment
      {
        AlimentId = a.AlimentId,
        name = a.name,
        scientificName = a.scientificName,
        group = a.group,
        brand = a.brand,
        components = a.components
      };

      _repository.AddAliment(aliment);

      return CreatedAtAction(nameof(get), new { id = aliment.AlimentId }, aliment);
    });

    return Created("", dbResponse);
  }
}
