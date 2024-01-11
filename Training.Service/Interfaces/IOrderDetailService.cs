using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Interfaces
{
    public interface IOrderDetailService
    {
        List<OrderDetailViewModel> GetAll();
    }
}