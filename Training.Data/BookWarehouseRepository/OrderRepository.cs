using Microsoft.EntityFrameworkCore;
using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;

namespace Training.Repository.BookWarehouseRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetOrderByLibrariansName(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderByMemberName(string keyword)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAllWithJoin()
        {
             var datas = _context.Orders
                                .Include(x => x.librarian)
                                .Include(y => y.orderDetails)
                                .ThenInclude(y => y.book)
                                .Include(z => z.member);

            return (IQueryable<Order>)datas;
        }
    }
}