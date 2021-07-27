using BusinnesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void BlogAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogDal.List(x=>x.CatId==id);
        }

        public List<Blog> GetBlogByDate()
        {
            return _blogDal.List().OrderByDescending(x=>x.BlogDate).ToList();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.List(x=>x.BlogId==id);
        }

        public List<Blog> GetBlogByRating()
        {
            return _blogDal.List().OrderByDescending(x => x.BlogRating).ToList();
        }

        public List<Blog> GetBlogByStatus()
        {
            return _blogDal.List(x=>x.Status==true);
        }

        public Blog GetByID(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public List<Blog> GetListBlogByWriter(int id)
        {
            return _blogDal.List(x=>x.WriterId==id);
        }
    }
}
