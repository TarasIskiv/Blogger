using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerDBContext _context;

        public PostRepository(BloggerDBContext context)
        {
            _context = context;
        }
        public void Add(Post post)
        {
            //post.Id = _context.Posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            _context.Posts.Update(post);
            _context.SaveChanges();

        }
    }
}
