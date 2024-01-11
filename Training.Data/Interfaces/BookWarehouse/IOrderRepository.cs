using Training.Model.Entities;

namespace Training.Repository.Interfaces.BookWarehouse
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllWithJoin();
        List<Order> GetOrderByMemberName(string keyword);
        List<Order> GetOrderByLibrariansName(string keyword);
    }
}