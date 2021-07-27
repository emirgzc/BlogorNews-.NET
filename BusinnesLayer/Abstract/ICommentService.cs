using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetCommentByBlog(int id);
        List<Comment> GetCommentByStatusTrue();
        List<Comment> GetCommentByStatusFalse();
        void CommentAdd(Comment comment);
        Comment GetByID(int id);
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
    }
}
