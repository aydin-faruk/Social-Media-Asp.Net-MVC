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
    public class CommentManager: ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal entity)
        {
            _commentDal = entity;
        }

        public Comment Add(Comment entity)
        {
            return _commentDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            return null;
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> predicate)
        {
            return _commentDal.GetAll(predicate);
        }

        public int Save(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
