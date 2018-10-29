using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface ILikeDal
    {
        Like Add(Like entity);
        List<Like> GetAll(Expression<Func<Like, bool>> predicate);
    }
}
