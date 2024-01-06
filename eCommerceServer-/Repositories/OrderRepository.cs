using eCommerceServer_.Context;
using eCommerceServer_.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceServer_.Repositories;

public sealed class OrderRepository
{
	ApplicationDbContext context;
    public OrderRepository()
    {
        context = new();
    }

    public IEnumerable<Order> GetAllByUserId(int userId)
    {
        return context.Orders
            .Where(o => o.UserId == userId)
            .Include(p=> p.Details)!
            .ThenInclude(p=> p.Product)
            .OrderByDescending(p=> p.Id)
            .ToList();
    }

    public void Add(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }
}
