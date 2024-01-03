using eCommerceServer_.Context;
using eCommerceServer_.Models;

namespace eCommerceServer_.Repositories;

public class AppUserRepository
{
	private readonly ApplicationDbContext context;
    public AppUserRepository()
    {
		context = new();
    }
    public void add(AppUser user)
	{
		context.Users.Add(user);
		context.SaveChanges();
	}

	public bool isEmailExist(string email)
	{
		return context.Users.Any(u=> u.Email == email);
	}

	public AppUser? Login(string email, string password)
	{
		return context.Users.FirstOrDefault(p=> p.Email == email  && p.Password == password);
	}
}
