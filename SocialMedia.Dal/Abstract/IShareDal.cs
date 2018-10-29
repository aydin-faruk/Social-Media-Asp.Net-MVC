using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface IShareDal
    {
        Share Add(Share entity);
        List<Share> GetAll(Expression<Func<Share, bool>> predicate);
    }
}
