using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        public IEnumerable<Post> GetAll();

        public Post GetById(int id);

        public void Delete(Post post);

        public void Update(Post id);

        public void Add(Post post);

    }
}
