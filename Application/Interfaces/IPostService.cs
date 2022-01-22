using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetAll();

        public PostDto GetById(int id);

        public PostDto Create(CreatePostDto dto);
    }
}
