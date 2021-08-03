using System.Collections.Generic;

namespace Bicicletaria_ploomes.Models.Interface
{
  public interface IUserRepository
  {
    void Create(User user);
    User DisableUser(int userId);
    User EnableUser(int userId);
    List<User> GetAll();
    User GetById(int id);
  }
}