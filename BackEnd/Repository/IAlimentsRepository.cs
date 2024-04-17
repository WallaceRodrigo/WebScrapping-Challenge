using BackEnd.Models;

namespace BackEnd.Repository
{
  public interface IAlimentsRepository
  {
    IAliment AddAliment(IAliment aliment);
    IAliment GetAliment(string name);
  }
}