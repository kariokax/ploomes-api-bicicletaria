using System;
using System.Collections.Generic;
using System.Linq;
using Bicicletaria_ploomes.Data;
using Bicicletaria_ploomes.Models;
using Bicicletaria_ploomes.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace Bicicletaria_ploomes.Repository
{
  public class UserRepository : IUserRepository
  {
    private DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
      _context.Database.EnsureCreated();
    }
    public void Create(User user)
    {
      user.DateCreate = DateTime.Now;
      user.ActiveUser();

      _context.User.Add(user);
      _context.SaveChanges();
    }

    public User EnableUser(int userId)
    {
      var user = _context.User.Where(u => u.Id == userId).FirstOrDefault();

      user.ActiveUser();
      _context.Entry<User>(user).State = EntityState.Modified;
      _context.SaveChanges();

      return user;
    }

    public User DisableUser(int userId)
    {
      var user = _context.User.Where(u => u.Id == userId).FirstOrDefault();

      user.DisableUser();
      _context.Entry<User>(user).State = EntityState.Modified;
      _context.SaveChanges();

      return user;
    }

    public List<User> GetAll()
    {
      return _context.User.ToList();
    }

    public User GetById(int id)
    {
      return _context.User.Where(u => u.Id == id).FirstOrDefault();
    }
  }
}