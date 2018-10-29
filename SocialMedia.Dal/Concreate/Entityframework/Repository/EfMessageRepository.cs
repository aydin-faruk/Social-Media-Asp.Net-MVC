using SocialMedia.Dal.Abstract;
using SocialMedia.Dal.Concrete.Entityfamework.Context;
using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SocialMedia.Dal.Concreate.Entityframework.Repository
{

    public class EfMessageRepository:IMessageDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public Message Add(Message entity)
        {
            try
            {
                _socialMediaDbContext.Messages.RemoveRange(_socialMediaDbContext.Messages.Local.Where(x => x.MessageID == 0).ToList());
                _socialMediaDbContext.Messages.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

        public List<Message> GetAll(Expression<Func<Message, bool>> predicate)
        {
            return _socialMediaDbContext.Messages.AsNoTracking().Where(predicate).OrderByDescending(x => x.Date).ToList();
        }

    }
}
