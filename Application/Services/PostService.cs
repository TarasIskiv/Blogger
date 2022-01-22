using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public PostDto Create(CreatePostDto dto)
        {
            if(string.IsNullOrEmpty(dto.Tittle))
            {
                throw new Exception("Post can not have an empty Tittle"); 
            }

            var post = _mapper.Map<Post>(dto);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            //if (post == null) throw new Exception("Bad unique id");
            _postRepository.Delete(post);
        }

        public IEnumerable<PostDto> GetAll()
        {
            var _posts = _postRepository.GetAll();
            if (_posts == null) return null;
            return _mapper.Map<IEnumerable<PostDto>>(_posts);
        }
        public PostDto GetById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto dto)
        {
            var currentPost = _postRepository.GetById(dto.Id);
            var updatedPost = _mapper.Map(dto, currentPost);
            _postRepository.Update(updatedPost);
        }
    }
}
