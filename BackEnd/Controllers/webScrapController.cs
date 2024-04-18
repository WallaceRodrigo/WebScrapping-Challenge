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

  [HttpGet("getAllAliments/{pagina}")]
  public ActionResult<IEnumerable<IAliment>> getAllAliments(int pagina)
  {
    WebScrap webScrap = new WebScrap();

    var scrapResponse = webScrap.Scrap(pagina);

    return Ok(scrapResponse);
  }

  [HttpPost("addAliment/{pagina}")]
  public IActionResult addAliment(int pagina)
  {
    WebScrap webScrap = new WebScrap();
    var scrapResponse = webScrap.Scrap(pagina);

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
  public ActionResult<IEnumerable<IAliment>> getAliment(string name)
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

  [HttpGet("GetAlimentById/{id}")]
  public ActionResult<IAliment> GetAlimentById(string id)
  {
    try
    {
      var aliment = _repository.GetAlimentById(id);

      return Ok(aliment);
    }
    catch (RequestFailedException e)
    {
      return NotFound(e.Message);
    }
  }
}
