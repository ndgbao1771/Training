using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface IMemberRepository : IRepository<Member>
    {
        List<Member> GetMemberByName(string name);
    }
}