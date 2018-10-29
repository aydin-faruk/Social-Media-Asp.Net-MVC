using SocialMedia.Entity.Models;
using SocialMedia.Entity.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface IUserDal
    {
        User Login(User user);
        User Add(User entity);

        List<User> GetAll(Expression<Func<User, bool>> predicate);

        List<PocoNoFollowUser> GetUsers(int userId);
    }
}
