using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();

        OrderViewModel Add(OrderViewModel orderViewModel);

        void Update(OrderViewModel orderViewModel);

        void Delete(int Id);
    }
}