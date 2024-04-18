using BackEnd.Models;

namespace BackEnd.Repository
{
  public interface IAlimentsRepository
  {
    IAliment AddAliment(IAliment aliment);
    IEnumerable<IAliment> GetAliment(string name);
    IAliment GetAlimentById(string id);
  }
}