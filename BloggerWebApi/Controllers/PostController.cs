using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Retrieves all posts")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrieves a specific post by unique Id")]
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        [SwaggerOperation(Summary = "Add a new post")]
        [HttpPost]
        public IActionResult Create([FromBody]CreatePostDto dto)
        {
            var result = _postService.Create(dto);
            return Created($"api/post/{result.Id}", result);
        }

        [SwaggerOperation(Summary = "Update post by unique id")]
        [HttpPut]
        public ActionResult Update([FromBody] UpdatePostDto dto)
        {
            _postService.UpdatePost(dto);
            return NoContent();
        }
    }


}
