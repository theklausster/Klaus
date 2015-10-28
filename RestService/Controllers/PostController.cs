
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestService.Controllers
{
    public class PostController : ApiController
    {
        private PostRepository postRepo = new PostRepository();
        // GET: api/sss/5
       
        public IHttpActionResult GetPost(int id)
        {
            Post post = postRepo.ReadEntity(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }
        
        [ResponseType(typeof(Post))]
        public IHttpActionResult PutPost(Post post)
        {
            Post createdPost = postRepo.CreateEntity(post);
            return Ok(createdPost);
        }
    }
}
