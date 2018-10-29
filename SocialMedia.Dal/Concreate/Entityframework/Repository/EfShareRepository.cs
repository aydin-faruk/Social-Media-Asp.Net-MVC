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

    public class EfShareRepository:IShareDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public Share Add(Share entity)
        {
            try
            {
                _socialMediaDbContext.Shares.RemoveRange(_socialMediaDbContext.Shares.Local.Where(x => x.ShareID == 0).ToList());
                _socialMediaDbContext.Shares.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

        public List<Share> GetAll(Expression<Func<Share, bool>> predicate)
        {
            return _socialMediaDbContext.Shares.AsNoTracking().Where(predicate).OrderByDescending(x => x.Date).ToList();
        }

    }
}
