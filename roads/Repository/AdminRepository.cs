using roads.Data;

namespace roads.Repository
{
    public class AdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
