using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface IMemberRepository : IRepository<Member>
    {
        IQueryable<Member> GetMemberByName(string name);
    }
}