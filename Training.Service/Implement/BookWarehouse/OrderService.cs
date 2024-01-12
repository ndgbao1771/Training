using AutoMapper;
using Training.Model;
using Training.Model.Entities;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Interfaces;
using Training.Service.ViewModel.BookWarehouse;

namespace Training.Service.Implement.BookWarehouse
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, AppDbContext context)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _context = context;
        }

        public OrderViewModel Add(OrderViewModel orderViewModel)
        {
            var datas = _mapper.Map<OrderViewModel, Order>(orderViewModel);
            _orderRepository.Add(datas);
            _orderRepository.Commit();
            return orderViewModel;
        }

        public void Delete(int Id)
        {
            _orderRepository.Delete(Id);
            _orderRepository.Commit();
        }

        public List<OrderViewModel> GetAll()
        {
            List<Order> datas = _orderRepository.GetAllWithJoin().ToList();
            List<OrderViewModel> dataView = _mapper.Map<List<Order>, List<OrderViewModel>>(datas);
            return dataView;
        }

        public List<OrderViewModel> GetListBookProgressOfMember(int id)
        {
            List<Order> datas = _orderRepository.GetListBookProgressOfMember(id).ToList();
            List<OrderViewModel> dataView = _mapper.Map<List<Order>, List<OrderViewModel>>(datas);
            return dataView;
        }

        public void Update(OrderViewModel orderViewModel)
        {
            if(orderViewModel.Id != 0)
            {
                var datas = _mapper.Map<OrderViewModel, Order>(orderViewModel);
                _orderRepository.Update(datas);
                _orderRepository.Commit();
            }
        }
    }
}