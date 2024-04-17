using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using BackEnd.Repository;
using BackEnd.Models;
using Azure;

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

  [HttpGet("getAllAliments/{pagina}/{atualD}")]
  public ActionResult<IEnumerable<IAliment>> getAllAliments(int pagina, int atualD)
  {
    WebScrap webScrap = new WebScrap();

    var scrapResponse = webScrap.Scrap(pagina, atualD);

    return Ok(scrapResponse);
  }

  [HttpPost("addAliment/{pagina}/{atualD}")]
  public IActionResult addAliment(int pagina, int atualD)
  {
    WebScrap webScrap = new WebScrap();
    var scrapResponse = webScrap.Scrap(pagina, atualD);

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

      return CreatedAtAction(nameof(getAllAliments), new { id = aliment.AlimentId }, aliment);
    });

    return Created("", dbResponse);
  }

  [HttpGet("getAliment/{name}")]
  public ActionResult<IAliment> getAliment(string name)
  {
    try
    {
      var aliment = _repository.GetAliment(name);

      return Ok(aliment);
    }
    catch (RequestFailedException e)
    {
      return NotFound(e.Message);
    }
  }
}
