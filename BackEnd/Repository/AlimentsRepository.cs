using BackEnd.Models;

namespace BackEnd.Repository
{
    public class AlimentsRepository
    {
        private readonly AlimentContext _context;

        public AlimentsRepository(AlimentContext context)
        {
            _context = context;
        }
    }
}