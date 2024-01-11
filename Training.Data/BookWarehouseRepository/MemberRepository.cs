using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Member> GetMemberByName(string name)
        {
            return _context.Members.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}