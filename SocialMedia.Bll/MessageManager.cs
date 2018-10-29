using SocialMedia.Dal.Abstract;
using SocialMedia.Entity.Models;
using SocialMedia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SocialMedia.Bll
{
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal entity)
        {
            _messageDal = entity;
        }

        public Message Add(Message entity)
        {
            return _messageDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Message Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            return null;
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> predicate)
        {
            return _messageDal.GetAll(predicate);
        }

        public int Save(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
