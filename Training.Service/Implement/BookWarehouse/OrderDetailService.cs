using AutoMapper;
using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Implement.BookWarehouse
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public List<OrderDetailViewModel> GetAll()
        {
            List<OrderDetail> datas = _orderDetailRepository.FindAll().ToList();
            List<OrderDetailViewModel> result = _mapper.Map<List<OrderDetail>, List<OrderDetailViewModel>>(datas);
            return result;
        }
    }
}