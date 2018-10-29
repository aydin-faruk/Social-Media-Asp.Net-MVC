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

    public class EfCommentRepository : ICommentDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public Comment Add(Comment entity)
        {
            try
            {
                _socialMediaDbContext.Comments.RemoveRange(_socialMediaDbContext.Comments.Local.Where(x => x.CommentID == 0).ToList());
                _socialMediaDbContext.Comments.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> predicate)
        {
            return _socialMediaDbContext.Comments.AsNoTracking().Where(predicate).OrderByDescending(x => x.Date).ToList();
        }

    }
}
