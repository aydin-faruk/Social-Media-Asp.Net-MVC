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

    public class EfShareFileRepository:IShareFileDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public ShareFile Add(ShareFile entity)
        {
            try
            {
                _socialMediaDbContext.ShareFiles.RemoveRange(_socialMediaDbContext.ShareFiles.Local.Where(x => x.FileID == 0).ToList());
                _socialMediaDbContext.ShareFiles.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

    }
}
