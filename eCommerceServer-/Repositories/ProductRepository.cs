using eCommerceServer_.Context;
using eCommerceServer_.Models;

namespace eCommerceServer_.Repositories;

public sealed class ProductRepository
{
	private ApplicationDbContext context;
    public ProductRepository()
    {
        context = new();
    }

    public IEnumerable<Product> GetAll()
    {
        return context.Products.OrderBy(p=> p.Name).ToList();
    }
}
