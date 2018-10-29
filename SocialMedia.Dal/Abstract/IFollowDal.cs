using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface IFollowDal
    {
        Follow Add(Follow entity);
        List<Follow> GetAll(Expression<Func<Follow, bool>> predicate);
        List<User> GetFollow(int userId);

        bool Delete(Follow entity);
        bool Delete(int id);
    }
}
