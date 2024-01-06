﻿using eCommerceServer_.Context;
using eCommerceServer_.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceServer_.Repositories;

public sealed class ShoppingCartRepository
{
	private ApplicationDbContext context;
    public ShoppingCartRepository()
    {
        context = new();
    }

    public IEnumerable<ShoppingCart> GetAllByUserId(int userId)
    {
	    return context.ShoppingCarts
            .Where(p => p.UserId == userId)
            .Include(p => p.Product)
            .ToList();
	}

    public ShoppingCart? GetByUserIdAndPRoductId(int userId,int productId)
    {
        return context.ShoppingCarts.Where(p => p.UserId == userId && p.ProductId == productId).FirstOrDefault();
	}

	public ShoppingCart? GetById(int id)
	{
		return context.ShoppingCarts
			.Find(id);
	}

	public void Add(ShoppingCart cart)
    {
        context.ShoppingCarts.Add(cart);
        context.SaveChanges();
    }

	public void Update(ShoppingCart cart)
	{
		context.ShoppingCarts.Update(cart);
		context.SaveChanges();
	}

	public void Remove(ShoppingCart cart)
	{
		context.ShoppingCarts.Remove(cart);
		context.SaveChanges();
	}

	public void RemoveRange(IEnumerable<ShoppingCart> carts)
	{
		context.RemoveRange(carts);
		context.SaveChanges();
	}
}
