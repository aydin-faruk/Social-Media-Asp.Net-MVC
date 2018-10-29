using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface IMessageDal
    {
        Message Add(Message entity);
        List<Message> GetAll(Expression<Func<Message, bool>> predicate);
    }
}
