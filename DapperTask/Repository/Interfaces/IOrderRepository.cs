using DapperTask.Models;

namespace DapperTask.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetTorder();
        public Task<Order> GetOrder(int id);
        public Task<int> CreateOrder(Order order);
        public Task<int> UpdateOrder(Order company);
        public Task<int> DeleteOrder(int id);
    }
}
