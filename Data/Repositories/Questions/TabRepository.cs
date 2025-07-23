using Data.Repositories;
using Data.Repositories.Context;

namespace TabSpace
{
    public class TabRepository : GenericRepository<Tab>, ITabRepository
    {
        public TabRepository(YouDbContext youRepo) : base(youRepo)
        {
        }
    }
}
