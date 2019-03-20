using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbServer.Api.DTO;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DbServer.Api.Extentions;

namespace DbServer.Api.Controllers
{
    /// <summary>
    /// Post stest
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public PostController(IPostRepository postRepository, IPostService postService, IMapper mapper)
        {
            _postRepository = postRepository;
            _postService = postService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new Post
        /// </summary>
        /// <param name="item">Origin Account, Destination Account and transaction value</param> 
        [HttpPost("CreatePost")]
        public IActionResult Post([FromBody] PostDTO item)
        {
            try
            {               
                var obj = this._postService.Insert(item.Mapp<PostDTO, Post>(this._mapper));
                return new ObjectResult(obj.Mapp<Post, PostDTO>(this._mapper));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}