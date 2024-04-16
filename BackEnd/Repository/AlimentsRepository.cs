using Azure;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
  public class AlimentsRepository : IAlimentsRepository
  {
    protected readonly WebScrappingDbContext _context;
    public AlimentsRepository(WebScrappingDbContext context)
    {
      _context = context;
    }

    public IAliment AddAliment(IAliment aliment)
    {
      var response = _context.Aliments.Add(new IAliment()
      {
        AlimentId = aliment.AlimentId,
        name = aliment.name,
        scientificName = aliment.scientificName,
        group = aliment.group,
        brand = aliment.brand,
        //components = aliment.components,
      });

      // _context.SingleComponent.AddRange(aliment.components);

      _context.SaveChanges();

      return response.Entity;
    }
  }
}