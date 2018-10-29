using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface ICommentDal
    {
        Comment Add(Comment entity);
        List<Comment> GetAll(Expression<Func<Comment, bool>> predicate);
    }
}
