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
      });

      if (aliment.components != null)
      {
        _context.SingleComponent.AddRange(aliment.components);
      }

      _context.SaveChanges();

      return response.Entity;
    }

    public IAliment GetAliment(string name)
    {
      var aliment = _context.Aliments.Select(a => new IAliment()
      {
        AlimentId = a.AlimentId,
        name = a.name,
        scientificName = a.scientificName,
        group = a.group,
        brand = a.brand,
        components = _context.SingleComponent.Where(c => c.AlimentId == a.AlimentId).ToList()
      }).FirstOrDefault(a => a.name == name);

      if (aliment == null)
      {
        throw new RequestFailedException("Aliment not found");
      }

      return aliment;
    }
  }
}