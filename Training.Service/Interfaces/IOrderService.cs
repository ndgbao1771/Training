using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();

        List<OrderViewModel> GetListBookProgressOfMember(int id);

        OrderViewModel Add(OrderViewModel orderViewModel);

        void Update(OrderViewModel orderViewModel);

        void Delete(int Id);
    }
}