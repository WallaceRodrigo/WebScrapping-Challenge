using BackEnd.Models;

namespace BackEnd.Repository
{
    public interface IAlimentsRepository
    {
        Task<IAliment> AddAliment(IAliment aliment);
        // Task<List<IAliment>> GetAliments();
        // Task<IAliment> GetAliment(int id);
    }
} 