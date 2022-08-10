using Dapper;
using DapperTask.Models;
using DapperTask.NewFolder;
using DapperTask.Repository.Interfaces;

namespace DapperTask.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;
        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(Order order)
        {
            int result = 0;
            var query = @"INSERT INTO Torder (OrderCode,CustomerName,mobile_no,shippingAddress,billingAddress,totalAmount) 
                          VALUES (@OrderCode,@CustomerName,@mobile_no,@shippingAddress,@billingAddress,@totalAmount);
                          SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, order);
                return result;
            }
        }

        public async Task<int> DeleteOrder(int id)
        {
            int result = 0;
            var query = @"Delete from Torder WHERE Id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }

        public Task<int> deleteorderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(int id)
        {
            var query = "SELECT * FROM Torder where Id=@id";
            using (var connection = _context.CreateConnection())
            {
                var orders = await connection.QueryAsync<Order>(query, new { id = id });
                return orders.FirstOrDefault();
            }
        }
        public async Task<IEnumerable<Order>> GetTorder()
        {
            var query = "SELECT * FROM Torder";
            using (var connection = _context.CreateConnection())
            {
                var orders = await connection.QueryAsync<Order>(query);
                return orders.ToList();
            }
        }

        public async Task<int> UpdateOrder(Order order)
        {
            int result = 0;
            var query = @"UPDATE Torder SET OrderCode=@OrderCode,CustomerName=@CustomerName,
                        mobile_no=@mobile_no,shippingAddress=@shippingAddress,billingAddress=@billingAddress,
                        totalAmount=@totalAmount
                           WHERE Id=@Id";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, order);
                return result;
            }
        }

    }
}
