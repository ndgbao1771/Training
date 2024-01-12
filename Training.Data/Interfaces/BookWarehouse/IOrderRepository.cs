using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllWithJoin();
        IQueryable<Order> GetOrderByMemberName(string keyword);
        IQueryable<Order> GetOrderByLibrariansName(string keyword);
        IQueryable<Order> GetListBookProgressOfMember(int id);
    }
}