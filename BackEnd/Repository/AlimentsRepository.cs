using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class AlimentsRepository : DbContext, IAlimentsRepository
    {
        private readonly AlimentContext _context;

        public AlimentsRepository(AlimentContext context)
        {
            _context = context;
        }
        public async Task<IAliment>AddAliment(IAliment aliment)
        {
            _context.aliment.Add(new IAliment
            {
                id = aliment.id,
                name = aliment.name,
                scientificName = aliment.scientificName,
                group = aliment.group,
                brand = aliment.brand,
            });

            await _context.SaveChangesAsync();
            return aliment;
        }

        // public async Task<List<Aliment>> GetAliments()
        // {
        //     return await _context.Aliments.ToListAsync();
        // }

        // public async Task<Aliment> GetAliment(int id)
        // {
        //     return await _context.Aliments.FindAsync(id);
        // }
    }
}